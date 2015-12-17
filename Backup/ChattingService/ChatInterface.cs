using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChattingService
{
	public delegate void dStringMsg(string msgFrom);
	public delegate void dQueueData(QueueData d);

	public enum ChatCode
	{
		Sys, StartInfo, UserList, LogIn, LogOut,
		Msg, Whisper, Nick, File
	}

	[Serializable]
	public class QueueData
	{
		public ChatCode code;
		public string msgFrom;
		public string msgTo;
		public object msg;

		public QueueData(object serverMsg)
		{
			this.code = ChatCode.Sys;
			this.msg = serverMsg;
		}

		public QueueData(ChatCode code, string msgFrom)
		{
			this.code = code;
			this.msgFrom = msgFrom;
		}

		public QueueData(ChatCode code, object msg)
		{
			this.code = code;
			this.msg = msg;
		}

		public QueueData(ChatCode code, string msgFrom, string msgTo, object msg)
		{
			this.code = code;
			this.msgFrom = msgFrom;
			this.msgTo = msgTo;					
			this.msg = msg;
		}
	}

	public interface IChat
	{
		void Start();
		void Stop();
		void Send(QueueData d);
	}

	public class TCPTransfer
	{
		private Socket s;
		private NetworkStream sendStm, recvStm;

		public void HookSocket(Socket s)
		{
			this.s = s;
			sendStm = new NetworkStream(s);
			recvStm = new NetworkStream(s);
		}

		public Socket MySocket
		{	get {	return s;	}	}

		public virtual void Send(QueueData d)
		{			
			BinaryFormatter bf = new BinaryFormatter();
			
			try
			{							
				bf.Serialize(sendStm, d);
				sendStm.Flush();
			}
			catch
			{
				return;
			}
		}

		public virtual QueueData Receive()
		{			
			QueueData d = null;
			BinaryFormatter bf = new BinaryFormatter();		
			
			try
			{
				d = (QueueData)bf.Deserialize(recvStm);
				recvStm.Flush();
			}
			catch(Exception e)
			{
				return new QueueData
					(e.Message + "\r\n전송문제로 데이터를 수신받지 못했습니다");
			}

			return d;
		}
	}

	class MessageQueue
	{
		private Queue<QueueData> que;

		public MessageQueue()
		{	que = new Queue<QueueData>();	}

		public void Enqueue(QueueData item)
		{	lock( que ) que.Enqueue(item);	}

		public QueueData Dequeue()
		{	lock( que )	return que.Count != 0 ? que.Dequeue() : null;	}

		public void Clear()
		{	lock( que ) que.Clear();		}
	}
}