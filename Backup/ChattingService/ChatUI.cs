using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace ChattingService
{
	public interface IChatUI
	{
		Label StartInfo { get; }
		TextBox ChatBox { get; }
		ComboBox WhisperList { get; }
		ListBox ClientList { get; }
		void GetMsg(QueueData d);
	}

	public interface IChatServerUI : IChatUI
	{
		int Port { get; }
	}

	public interface IChatClientUI : IChatUI
	{		
		IPEndPoint Server { get; }
		string Nick { get; }
	}

	public class ChatUI : IChatServerUI, IChatClientUI
	{
		// 크로스 스레드 작업을 위함
		private Form main;

		// IChatUI
		private Label myInfoLabel;
		private TextBox chatBox;
		private ComboBox whisperList;
		private ListBox clientList;

		// IChatServerUI
		private MaskedTextBox openPort;

		// IChatClientUI
		private TextBox serverIP;
		private MaskedTextBox serverPort;		
		private TextBox nick;

		public ChatUI
			(Form main, Label myInfoLabel, TextBox chatBox, ComboBox cbClients, ListBox clientList)
		{
			this.main = main;
			this.myInfoLabel = myInfoLabel;
			this.chatBox = chatBox;
			this.whisperList = cbClients;
			this.clientList = clientList;
		}

		public void HookServerUI(MaskedTextBox openPort)
		{
			this.openPort = openPort;
		}

		public void HookClientUI(TextBox serverIP, MaskedTextBox serverPort, TextBox nick)
		{
			this.serverIP = serverIP;
			this.serverPort = serverPort;
			this.nick = nick;
		}
		
		public void SetServerUI(bool isStart)
		{
			if( isStart ) 
			{
				openPort.ReadOnly = true;
				openPort.BackColor = Color.Khaki;
				whisperList.SelectedIndex = 0;
			}
			else
			{
				openPort.ReadOnly = false;
				openPort.BackColor = SystemColors.Control;
				chatBox.Text = "";
				clientList.Items.Clear();
				whisperList.Items.Clear();
				whisperList.Items.Add("모두에게");
			}
		}

		public void SetClientUI(bool isStart)
		{
			if( isStart )
			{
				serverIP.ReadOnly = true;
				serverPort.ReadOnly = true;
				nick.ReadOnly = true;
				serverIP.BackColor = Color.Khaki;
				serverPort.BackColor = Color.Khaki;
				nick.BackColor = Color.Khaki;
				whisperList.SelectedIndex = 0;
			}
			else
			{
				serverIP.ReadOnly = false;
				serverPort.ReadOnly = false;
				nick.ReadOnly = false;
				serverIP.BackColor = SystemColors.Control;
				serverPort.BackColor = SystemColors.Control;
				nick.BackColor = SystemColors.Control;
				chatBox.Clear();
				clientList.Items.Clear();
				whisperList.Items.Clear();
				whisperList.Items.Add("모두에게");
			}
		}

		public void GetMsg(QueueData d)
		{
			dQueueData o = null;

			switch( d.code )
			{
				case ChatCode.Sys:
					o = new dQueueData(WriteSystemMsg);	break;
				case ChatCode.StartInfo:
					o = new dQueueData(WriteStartInfo); break;
				case ChatCode.UserList:
					o = new dQueueData(WriteUserList);	break;
				case ChatCode.LogIn:
					o = new dQueueData(WriteLogIn);		break;
				case ChatCode.LogOut:
					o = new dQueueData(WriteLogOut);	break;
				case ChatCode.Msg:
					o = new dQueueData(WriteChat);		break;			
				case ChatCode.Whisper:
					o = new dQueueData(WriteWhisper);	break;					
				case ChatCode.Nick:
					o = new dQueueData(ChangeNick);		break;
				case ChatCode.File:
					o = new dQueueData(ReceiveFile);	break;
			}

			if( o != null ) main.Invoke(o, d);
		}

		public void WriteSystemMsg(QueueData d)
		{
			chatBox.AppendText("- " + d.msg + "\r\n");
		}

		public void WriteStartInfo(QueueData d)
		{
			myInfoLabel.Text = d.msgFrom;
			nick.Text = d.msgFrom;
		}

		public void WriteUserList(QueueData d)
		{
			foreach( string who in ((Dictionary<string, string>)d.msg).Keys )
			{
				clientList.Items.Add(who);
				whisperList.Items.Add(who);
			}
		}

		public void WriteLogIn(QueueData d)
		{
			clientList.Items.Add(d.msgFrom);
			whisperList.Items.Add(d.msgFrom);
			chatBox.AppendText("> " + d.msgFrom + " 님이 입장하셨습니다\r\n");
		}

		public void WriteLogOut(QueueData d)
		{
			clientList.Items.Remove(d.msgFrom);
			chatBox.AppendText("> " + d.msgFrom + " 님이 퇴장하셨습니다\r\n");
		}

		public void WriteChat(QueueData d)
		{
			chatBox.AppendText("[" + d.msgFrom + "] " + d.msg + "\r\n");
		}

		public void WriteWhisper(QueueData d)
		{
			chatBox.AppendText("(귓말) [" + d.msgFrom + "] " + d.msg + "\r\n");
		}

		public void ChangeNick(QueueData d)
		{
			int idx = clientList.Items.IndexOf(d.msgFrom);
			clientList.Items[idx] = d.msg;
		}

		public void ReceiveFile(QueueData d)
		{
			
		}

		// IChatUI 구현	  
		public Label StartInfo
		{	get { return myInfoLabel; }		}
		public TextBox ChatBox
		{	get { return chatBox; }			}
		public ComboBox WhisperList
		{	get { return whisperList; }		}
		public ListBox ClientList
		{	get { return ClientList; }		}

		// IChatServerUI 구현
		public int Port
		{
			get
			{
				return int.Parse(openPort.Text);
			}
		}

		// IChatClientUI 구현
		public IPEndPoint Server
		{
			get
			{
				return new IPEndPoint
					(IPAddress.Parse(serverIP.Text), int.Parse(serverPort.Text));
			}
		}
		public string Nick
		{
			get
			{
				return nick.Text;
			}
		}
	}
}
