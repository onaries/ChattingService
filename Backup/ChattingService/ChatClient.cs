using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChattingService
{
	public class ChattingClient : TCPTransfer, IChat
	{
		private IChatClientUI ui;
		private TcpClient tcpc;
		private Thread t;
		private event dQueueData SendToUI;

		public ChattingClient(IChatClientUI ui)
		{
			this.ui = ui;
			SendToUI += new dQueueData(this.ui.GetMsg);
			tcpc = new TcpClient();
			t = new Thread(Receive);
		}

		public void Start()
		{
			try
			{
				tcpc.Connect(ui.Server);
				base.HookSocket(tcpc.Client);
				t.Start();
				base.Send(new QueueData(ChatCode.LogIn, ui.Nick));
			}
			catch
			{
				SendToUI(new QueueData("연결실패\r\n서버정보를 다시 입력하세요"));
			}
		}

		public void Stop()
		{
			base.Send(new QueueData(ChatCode.LogOut, ui.Nick));
			t.Abort();
			if( tcpc != null ) tcpc.Close();			
		}		

		public override void Send(QueueData d)
		{
			if( d.code == ChatCode.Msg && (string)d.msg == "" ) return;
			base.Send(d);
		}

		public new void Receive()
		{
			while( tcpc.Connected )
				SendToUI(base.Receive());
		}	
	}
}
