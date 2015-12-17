using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace ChattingService
{
	public partial class MainForm : Form
	{
		private IChat service;
		private ChatUI ui;

		private enum Service {	Server, Client	};

		public MainForm()
		{
			InitializeComponent();
			tabcService.Hide();
			this.Size = new Size(this.Size.Width, this.Size.Height-370);
            IPAddress ipAddress = GetExternalIPAddress();
            try
            {
                txtServerIP.Text = ipAddress.ToString();
            }
            catch (NullReferenceException ex)
            {

            }
            Random r = new Random();
            txtNick.Text = "손님" + r.Next(1, 100);

            // ----------------------- ChatUI 연동 -----------------------
            ui = new ChatUI(this, lbMain, txtChat1, cbxClients, lbxClients);
			ui.HookServerUI(txtOpenPort);
			ui.HookClientUI(txtServerIP, txtServerPort, txtNick);
			// ----------------------- ChatUI 연동 -----------------------
		}

        private IPAddress GetExternalIPAddress()
        {
            IPHostEntry myIPHostEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress myIPAddress in myIPHostEntry.AddressList)
            {
                byte[] ipBytes = myIPAddress.GetAddressBytes();

                if (myIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    if (!IsPrivateIP(myIPAddress))
                    {
                        return myIPAddress;
                    }
                }
            }

            return null;
        }

        private bool IsPrivateIP(IPAddress myIPAddress)
        {
            if (myIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                byte[] ipBytes = myIPAddress.GetAddressBytes();

                // 10.0.0.0/24 
                if (ipBytes[0] == 10)
                {
                    return true;
                }
                // 172.16.0.0/16
                else if (ipBytes[0] == 172 && ipBytes[1] == 16)
                {
                    return true;
                }
                // 192.168.0.0/16
                else if (ipBytes[0] == 192 && ipBytes[1] == 168)
                {
                    return true;
                }
                // 169.254.0.0/16
                else if (ipBytes[0] == 169 && ipBytes[1] == 254)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CompareIpAddress(IPAddress IPAddress1, IPAddress IPAddress2)
        {
            byte[] b1 = IPAddress1.GetAddressBytes();
            byte[] b2 = IPAddress2.GetAddressBytes();

            if (b1.Length == b2.Length)
            {
                for (int i = 0; i < b1.Length; ++i)
                {
                    if (b1[i] != b2[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private void btnServiceStart_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			Service s = btn.Name == "btnServerStart" ?
					Service.Server : Service.Client;

			if( btn.Text == "시작" )
			{				
				if (ServiceStart(s))           
                    btn.Text = "종료";
			}
			else
			{
				ServiceStop(s);
				btn.Text = "시작";
			}
		}

		private bool ServiceStart(Service type)
		{
			if( type == Service.Server )
			{
				if( !MainFormTools.CheckPort(txtOpenPort.Text) ) return false;

				SetTabPages(true, tabServerStart);
				ui.SetServerUI(true);

				service = new ChattingServer(ui);
				service.Start();

				tabService.Text = "서버 서비스";
			}
			else
			{
				if( !MainFormTools.CheckPort(txtServerPort.Text) ||
				!MainFormTools.CheckIPAddress(txtServerIP.Text) ) return false;

				SetTabPages(true, tabClientStart);
				ui.SetClientUI(true);

				service = new ChattingClient(ui);
				service.Start();

				tabService.Text = "클라이언트 서비스";
			}

			txtSend.Focus();
            return true;
		}

		private void ServiceStop(Service type)
		{		
			service.Stop();
			service = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();

			SetTabPages(false, null);
			ui.SetClientUI(false);
			ui.SetServerUI(false);

			if( type == Service.Client )
				tabcStart.SelectedIndex = 1;				
		}

		private void SetTabPages(bool isStart, TabPage tab)
		{
			if( isStart )
			{
				tabcService.Show();
				this.Size = new Size(this.Size.Width, this.Size.Height + 370);
				tabcStart.TabPages.Clear();
				tabcStart.TabPages.Add(tab);
			}
			else
			{
				tabcService.Hide();
				this.Size = new Size(this.Size.Width, this.Size.Height - 370);
				tabcStart.TabPages.Clear();
				tabcStart.TabPages.Add(tabServerStart);
				tabcStart.TabPages.Add(tabClientStart);
			}
		}

		private void btnSend_Click(object sender, EventArgs e)
		{	
			QueueData d;
			int msgTo = cbxClients.SelectedIndex;
			if( msgTo == 0 )
				d = new QueueData(ChatCode.Msg, ui.Nick, null, txtSend.Text);
			else
				d = new QueueData
					(ChatCode.Whisper, ui.Nick, cbxClients.Items[msgTo]+"", txtSend.Text);		

			service.Send(d);
			txtSend.Clear();
			txtSend.Focus();
		}

		private void txtSend_KeyDown(object sender, KeyEventArgs e)
		{
			if( e.KeyCode == Keys.Enter )
			{
				btnSend.PerformClick();
				txtSend.Clear();
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(service != null) service.Stop();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = "jpg";

            openfile.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            openfile.ShowDialog();
            
            if (openfile.FileNames.Length > 0)
            {
                foreach (string filename in openfile.FileNames)
                {
                    QueueData d;
                    int msgTo = cbxClients.SelectedIndex;
                    if (msgTo == 0)
                        d = new QueueData(ChatCode.Msg, ui.Nick, null, filename);
                    else
                        d = new QueueData
                            (ChatCode.Whisper, ui.Nick, cbxClients.Items[msgTo] + "", filename);
                    
                    service.Send(d);
                }
                
            } 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtChat1.Text = "";
        }
    }
}