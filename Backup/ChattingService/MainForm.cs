using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

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
			txtServerIP.Text = Dns.GetHostAddresses(Dns.GetHostName())[0] + "";

			// ----------------------- ChatUI 연동 -----------------------
			ui = new ChatUI(this, lbMain, txtChat, cbxClients, lbxClients);
			ui.HookServerUI(txtOpenPort);
			ui.HookClientUI(txtServerIP, txtServerPort, txtNick);
			// ----------------------- ChatUI 연동 -----------------------
		}

		private void btnServiceStart_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			Service s = btn.Name == "btnServerStart" ?
					Service.Server : Service.Client;

			if( btn.Text == "시작" )
			{				
				ServiceStart(s);
				btn.Text = "종료";
			}
			else
			{
				ServiceStop(s);
				btn.Text = "시작";
			}
		}

		private void ServiceStart(Service type)
		{
			if( type == Service.Server )
			{
				if( !MainFormTools.CheckPort(txtOpenPort.Text) ) return;

				SetTabPages(true, tabServerStart);
				ui.SetServerUI(true);

				service = new ChattingServer(ui);
				service.Start();

				tabService.Text = "서버 서비스";
			}
			else
			{
				if( !MainFormTools.CheckPort(txtServerPort.Text) ||
				!MainFormTools.CheckIPAddress(txtServerIP.Text) ) return;

				SetTabPages(true, tabClientStart);
				ui.SetClientUI(true);

				service = new ChattingClient(ui);
				service.Start();

				tabService.Text = "클라이언트 서비스";
			}

			txtSend.Focus();
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
	}
}