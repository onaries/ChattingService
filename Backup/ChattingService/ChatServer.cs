using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ChattingService
{
	public class ChattingServer : IChat
	{
		private TcpListener tcpl;
		private ClientManager manager;
		private Thread t;
		private event dQueueData SendServerMsg, SendToUI;

		public ChattingServer(IChatServerUI ui)
		{	
			tcpl = new TcpListener(IPAddress.Any, ui.Port);
			manager = new ClientManager(WriteServerChat);
			SendServerMsg += new dQueueData(manager.SendToAll);
			SendToUI += new dQueueData(ui.GetMsg);
			t = new Thread(Listen);
			
			IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
			string msg = "> " + host.AddressList[0] + ":" + ui.Port;
			SendToUI(new QueueData(ChatCode.StartInfo, msg));
		}
		
		public void Start()
		{
			t.Start();			
		}

		public void Stop()
		{
			t.Abort();
			if( tcpl != null ) tcpl.Stop();
			if( manager != null ) manager.Close();
		}

		private void Listen()
		{
			try
			{
				tcpl.Start();
				while( true )
				{
					Socket s = tcpl.AcceptSocket();
					manager.Add(s);
				}	
			}
			catch(SocketException e)
			{
				SendToUI(new QueueData(e.Message));
				SendToUI(new QueueData("서버를 시작할 수 없습니다. 다른 포트를 입력하세요"));
				if( tcpl != null ) tcpl.Stop();
			}
		}

		public void Send(QueueData d)
		{
			d.code = ChatCode.Sys;
			WriteServerChat(d);			
			SendServerMsg(d);		
		}

		public void WriteServerChat(QueueData d)
		{
			SendToUI(d);
		}
	}

	class ClientManager
	{
		private Dictionary<string, Client> list;
		private Dictionary<string, string> nlist;
		private MessageQueue que;
		private event dQueueData SendToServer;
		
		public ClientManager(dQueueData sendToServer)
		{
			list = new Dictionary<string, Client>();
			nlist = new Dictionary<string,string>();
			que = new MessageQueue();
			this.SendToServer = sendToServer;
		}

		public void Add(Socket s)
		{
			Client c = new Client(s, que, Send);
			c.Send(new QueueData(ChatCode.UserList, nlist));
			list.Add(c.MyIP, c);			
			c.Start();		
		}

		public void Close()
		{
			SendToAll(new QueueData("서버가 종료되었습니다"));
			foreach( Client c in list.Values )
				c.Stop();
			list.Clear();
			nlist.Clear();
		}

		public void SendToAll(QueueData d)
		{
			foreach( Client c in list.Values )
				c.Send(d);
		}

		public void SendToAll(QueueData d, Client except)
		{
			foreach( Client c in list.Values )
				if( c != except ) c.Send(d);
		}

		public void SendToOne(QueueData d, Client c)
		{
			c.Send(d);
		}

		public bool NickCheck(string tryReg)
		{
			return nlist.ContainsKey(tryReg);
		}

		private void Send(string IPFrom)
		{
			QueueData d = que.Dequeue();
			
			switch(d.code)
			{
				case ChatCode.LogIn:
					int a = 0;
					while( NickCheck(d.msgFrom) )
					{
						d.msgFrom = "손님" + (list.Count + a);
						a++;
					}
					if( a > 0 )
					{
						string msg = "이미 등록된 대화명입니다\r\n" +
							"대화명은 자동으로 설정됩니다 : " +
							"[" + d.msgFrom + "]";
						list[IPFrom].Send(new QueueData(msg));
					}
					nlist.Add(d.msgFrom, IPFrom);
					list[IPFrom].Send(new QueueData(ChatCode.StartInfo, d.msgFrom));
					SendToAll(d);
					break;

				case ChatCode.LogOut:
					Client c = list[IPFrom];
					list.Remove(IPFrom);
					nlist.Remove(d.msgFrom);
					SendToServer(d);
					SendToAll(d);
					c.Stop();
					break;

				case ChatCode.Msg:
					SendToAll(d, list[IPFrom]);
					break;

				case ChatCode.Whisper:
					SendToOne(d, list[nlist[d.msgTo]]);
					break;

				case ChatCode.Nick:
					break;

				case ChatCode.File:
					break;				
			}

			SendToServer(d);
		}		
	}

	class Client : TCPTransfer
	{
		private Thread t;
		private MessageQueue que;
		private event dStringMsg SendToManager;

		public Client(Socket s, MessageQueue que, dStringMsg sendToManager)
		{
			this.que = que;
			this.SendToManager += sendToManager;
			t = new Thread(Receive);
			base.HookSocket(s);
		}

		public void Start()
		{
			t.Start();
		}

		public void Stop()
		{
			t.Abort();
		}

		public override void Send(QueueData d)
		{
			base.Send(d);
		}

		private new void Receive()
		{
			while( base.MySocket.Connected )
			{
				QueueData d = base.Receive();
				if( d.code != ChatCode.LogIn ) base.Send(d);
				que.Enqueue(d);
				SendToManager(MyIP);
			}	
		}

		public string MyIP
		{	get {	return (IPEndPoint)base.MySocket.RemoteEndPoint + "";	}	}
	}
}
