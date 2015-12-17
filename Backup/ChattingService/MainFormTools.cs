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
	public static class MainFormTools
	{
		public static bool CheckPort(string input)
		{
			int port;
			if( !int.TryParse(input, out port) || port < 1025 || port > 65535 )
			{
				InvalidPortError();
				return false;
			}

			return true;
		}

		public static bool CheckIPAddress(string input)
		{
			IPAddress ip;
			if( !IPAddress.TryParse(input, out ip) )
			{
				InvalidIPAddressError();
				return false;
			}

			return true;
		}

		public static void InvalidIPAddressError()
		{
			MessageBox.Show("IP 주소를 잘못 입력하셨습니다",
				"주소입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static void InvalidPortError()
		{
			MessageBox.Show("포트의 범위는 1025 ~ 65535 입니다", 
				"포트입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
