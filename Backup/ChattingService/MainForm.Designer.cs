namespace ChattingService
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.imgList24Bit = new System.Windows.Forms.ImageList(this.components);
			this.tabcStart = new System.Windows.Forms.TabControl();
			this.tabServerStart = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtOpenPort = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnServerStart = new System.Windows.Forms.Button();
			this.tabClientStart = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtServerIP = new System.Windows.Forms.TextBox();
			this.txtNick = new System.Windows.Forms.TextBox();
			this.txtServerPort = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnClientStart = new System.Windows.Forms.Button();
			this.imgList8Bit = new System.Windows.Forms.ImageList(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.tabService = new System.Windows.Forms.TabPage();
			this.cbxClients = new System.Windows.Forms.ComboBox();
			this.lbMain = new System.Windows.Forms.Label();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtSend = new System.Windows.Forms.TextBox();
			this.txtChat = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lbxClients = new System.Windows.Forms.ListBox();
			this.tabcService = new System.Windows.Forms.TabControl();
			this.cbxFunc = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tabcStart.SuspendLayout();
			this.tabServerStart.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabClientStart.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabService.SuspendLayout();
			this.tabcService.SuspendLayout();
			this.SuspendLayout();
			// 
			// imgList24Bit
			// 
			this.imgList24Bit.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList24Bit.ImageStream")));
			this.imgList24Bit.TransparentColor = System.Drawing.Color.Magenta;
			this.imgList24Bit.Images.SetKeyName(0, "");
			this.imgList24Bit.Images.SetKeyName(1, "");
			this.imgList24Bit.Images.SetKeyName(2, "");
			this.imgList24Bit.Images.SetKeyName(3, "Find.bmp");
			// 
			// tabcStart
			// 
			this.tabcStart.Controls.Add(this.tabServerStart);
			this.tabcStart.Controls.Add(this.tabClientStart);
			this.tabcStart.ImageList = this.imgList8Bit;
			this.tabcStart.Location = new System.Drawing.Point(12, 12);
			this.tabcStart.Name = "tabcStart";
			this.tabcStart.SelectedIndex = 0;
			this.tabcStart.Size = new System.Drawing.Size(542, 101);
			this.tabcStart.TabIndex = 0;
			// 
			// tabServerStart
			// 
			this.tabServerStart.Controls.Add(this.groupBox1);
			this.tabServerStart.ImageIndex = 0;
			this.tabServerStart.Location = new System.Drawing.Point(4, 23);
			this.tabServerStart.Name = "tabServerStart";
			this.tabServerStart.Padding = new System.Windows.Forms.Padding(3);
			this.tabServerStart.Size = new System.Drawing.Size(534, 74);
			this.tabServerStart.TabIndex = 0;
			this.tabServerStart.Text = "서버";
			this.tabServerStart.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtOpenPort);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnServerStart);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(522, 60);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "채팅 서버 정보입력";
			// 
			// txtOpenPort
			// 
			this.txtOpenPort.Location = new System.Drawing.Point(242, 23);
			this.txtOpenPort.Mask = "99999";
			this.txtOpenPort.Name = "txtOpenPort";
			this.txtOpenPort.Size = new System.Drawing.Size(53, 21);
			this.txtOpenPort.TabIndex = 1;
			this.txtOpenPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtOpenPort.ValidatingType = typeof(int);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(230, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "서비스에 사용할 포트번호 (1025 ~ 65535)";
			// 
			// btnServerStart
			// 
			this.btnServerStart.Location = new System.Drawing.Point(441, 16);
			this.btnServerStart.Name = "btnServerStart";
			this.btnServerStart.Size = new System.Drawing.Size(75, 33);
			this.btnServerStart.TabIndex = 2;
			this.btnServerStart.Text = "시작";
			this.btnServerStart.UseVisualStyleBackColor = true;
			this.btnServerStart.Click += new System.EventHandler(this.btnServiceStart_Click);
			// 
			// tabClientStart
			// 
			this.tabClientStart.Controls.Add(this.groupBox2);
			this.tabClientStart.ImageIndex = 1;
			this.tabClientStart.Location = new System.Drawing.Point(4, 23);
			this.tabClientStart.Name = "tabClientStart";
			this.tabClientStart.Padding = new System.Windows.Forms.Padding(3);
			this.tabClientStart.Size = new System.Drawing.Size(534, 74);
			this.tabClientStart.TabIndex = 1;
			this.tabClientStart.Text = "클라이언트";
			this.tabClientStart.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtServerIP);
			this.groupBox2.Controls.Add(this.txtNick);
			this.groupBox2.Controls.Add(this.txtServerPort);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.btnClientStart);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(522, 60);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "채팅 클라이언트 정보입력";
			// 
			// txtServerIP
			// 
			this.txtServerIP.Location = new System.Drawing.Point(41, 23);
			this.txtServerIP.MaxLength = 14;
			this.txtServerIP.Name = "txtServerIP";
			this.txtServerIP.Size = new System.Drawing.Size(106, 21);
			this.txtServerIP.TabIndex = 1;
			this.txtServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtNick
			// 
			this.txtNick.Location = new System.Drawing.Point(294, 23);
			this.txtNick.MaxLength = 8;
			this.txtNick.Name = "txtNick";
			this.txtNick.Size = new System.Drawing.Size(117, 21);
			this.txtNick.TabIndex = 5;
			this.txtNick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtServerPort
			// 
			this.txtServerPort.Location = new System.Drawing.Point(188, 23);
			this.txtServerPort.Mask = "99999";
			this.txtServerPort.Name = "txtServerPort";
			this.txtServerPort.Size = new System.Drawing.Size(53, 21);
			this.txtServerPort.TabIndex = 3;
			this.txtServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtServerPort.ValidatingType = typeof(int);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(247, 26);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 12);
			this.label5.TabIndex = 4;
			this.label5.Text = "대화명";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(153, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 2;
			this.label4.Text = "포트";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "서버";
			// 
			// btnClientStart
			// 
			this.btnClientStart.Location = new System.Drawing.Point(441, 16);
			this.btnClientStart.Name = "btnClientStart";
			this.btnClientStart.Size = new System.Drawing.Size(75, 33);
			this.btnClientStart.TabIndex = 6;
			this.btnClientStart.Text = "시작";
			this.btnClientStart.UseVisualStyleBackColor = true;
			this.btnClientStart.Click += new System.EventHandler(this.btnServiceStart_Click);
			// 
			// imgList8Bit
			// 
			this.imgList8Bit.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList8Bit.ImageStream")));
			this.imgList8Bit.TransparentColor = System.Drawing.Color.White;
			this.imgList8Bit.Images.SetKeyName(0, "MYCOMP.BMP");
			this.imgList8Bit.Images.SetKeyName(1, "NETHOOD.BMP");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(254, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "사용할 포트번호를 입력하세요 (1025 ~ 65535)";
			// 
			// tabService
			// 
			this.tabService.Controls.Add(this.button1);
			this.tabService.Controls.Add(this.cbxFunc);
			this.tabService.Controls.Add(this.cbxClients);
			this.tabService.Controls.Add(this.lbMain);
			this.tabService.Controls.Add(this.btnSend);
			this.tabService.Controls.Add(this.txtSend);
			this.tabService.Controls.Add(this.txtChat);
			this.tabService.Controls.Add(this.label8);
			this.tabService.Controls.Add(this.label9);
			this.tabService.Controls.Add(this.lbxClients);
			this.tabService.ImageIndex = 2;
			this.tabService.Location = new System.Drawing.Point(4, 23);
			this.tabService.Name = "tabService";
			this.tabService.Padding = new System.Windows.Forms.Padding(3);
			this.tabService.Size = new System.Drawing.Size(534, 330);
			this.tabService.TabIndex = 1;
			this.tabService.Text = "서비스";
			this.tabService.UseVisualStyleBackColor = true;
			// 
			// cbxClients
			// 
			this.cbxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxClients.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cbxClients.FormattingEnabled = true;
			this.cbxClients.Items.AddRange(new object[] {
            "모두에게"});
			this.cbxClients.Location = new System.Drawing.Point(98, 266);
			this.cbxClients.Name = "cbxClients";
			this.cbxClients.Size = new System.Drawing.Size(130, 20);
			this.cbxClients.TabIndex = 3;
			// 
			// lbMain
			// 
			this.lbMain.AutoSize = true;
			this.lbMain.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbMain.ForeColor = System.Drawing.Color.SaddleBrown;
			this.lbMain.Location = new System.Drawing.Point(6, 9);
			this.lbMain.Name = "lbMain";
			this.lbMain.Size = new System.Drawing.Size(41, 12);
			this.lbMain.TabIndex = 1;
			this.lbMain.Text = "준비...";
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(297, 260);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(71, 61);
			this.btnSend.TabIndex = 5;
			this.btnSend.Text = "보내기";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtSend
			// 
			this.txtSend.BackColor = System.Drawing.Color.Gainsboro;
			this.txtSend.Font = new System.Drawing.Font("돋움체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.txtSend.Location = new System.Drawing.Point(6, 297);
			this.txtSend.Name = "txtSend";
			this.txtSend.Size = new System.Drawing.Size(285, 22);
			this.txtSend.TabIndex = 4;
			this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
			// 
			// txtChat
			// 
			this.txtChat.BackColor = System.Drawing.SystemColors.Control;
			this.txtChat.Font = new System.Drawing.Font("돋움체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.txtChat.Location = new System.Drawing.Point(6, 31);
			this.txtChat.Multiline = true;
			this.txtChat.Name = "txtChat";
			this.txtChat.ReadOnly = true;
			this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChat.Size = new System.Drawing.Size(362, 223);
			this.txtChat.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label8.ImageIndex = 1;
			this.label8.ImageList = this.imgList24Bit;
			this.label8.Location = new System.Drawing.Point(442, 3);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(86, 25);
			this.label8.TabIndex = 6;
			this.label8.Text = "현재접속자";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label9.ImageIndex = 0;
			this.label9.ImageList = this.imgList24Bit;
			this.label9.Location = new System.Drawing.Point(306, 3);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(62, 25);
			this.label9.TabIndex = 0;
			this.label9.Text = "대화창";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbxClients
			// 
			this.lbxClients.Font = new System.Drawing.Font("돋움체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbxClients.FormattingEnabled = true;
			this.lbxClients.Location = new System.Drawing.Point(374, 31);
			this.lbxClients.Name = "lbxClients";
			this.lbxClients.Size = new System.Drawing.Size(154, 290);
			this.lbxClients.TabIndex = 7;
			// 
			// tabcService
			// 
			this.tabcService.Controls.Add(this.tabService);
			this.tabcService.ImageList = this.imgList24Bit;
			this.tabcService.Location = new System.Drawing.Point(12, 125);
			this.tabcService.Name = "tabcService";
			this.tabcService.SelectedIndex = 0;
			this.tabcService.Size = new System.Drawing.Size(542, 357);
			this.tabcService.TabIndex = 1;
			// 
			// cbxFunc
			// 
			this.cbxFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxFunc.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cbxFunc.FormattingEnabled = true;
			this.cbxFunc.Items.AddRange(new object[] {
            "대화",
            "파일전송",
            "대화명변경"});
			this.cbxFunc.Location = new System.Drawing.Point(6, 266);
			this.cbxFunc.Name = "cbxFunc";
			this.cbxFunc.Size = new System.Drawing.Size(86, 20);
			this.cbxFunc.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.ImageIndex = 3;
			this.button1.ImageList = this.imgList24Bit;
			this.button1.Location = new System.Drawing.Point(234, 260);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(57, 31);
			this.button1.TabIndex = 8;
			this.button1.Text = "파일";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 494);
			this.Controls.Add(this.tabcStart);
			this.Controls.Add(this.tabcService);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "소켓을 이용한 객체 전송 TCP 채팅 서버 / 클라이언트";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.tabcStart.ResumeLayout(false);
			this.tabServerStart.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabClientStart.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabService.ResumeLayout(false);
			this.tabService.PerformLayout();
			this.tabcService.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabcStart;
		private System.Windows.Forms.TabPage tabServerStart;
		private System.Windows.Forms.TabPage tabClientStart;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnServerStart;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnClientStart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox txtOpenPort;
		private System.Windows.Forms.MaskedTextBox txtServerPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNick;
		private System.Windows.Forms.ImageList imgList24Bit;
		private System.Windows.Forms.ImageList imgList8Bit;
		private System.Windows.Forms.TextBox txtServerIP;
		private System.Windows.Forms.TabPage tabService;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtSend;
		private System.Windows.Forms.TextBox txtChat;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ListBox lbxClients;
		private System.Windows.Forms.TabControl tabcService;
		private System.Windows.Forms.Label lbMain;
		private System.Windows.Forms.ComboBox cbxClients;
		private System.Windows.Forms.ComboBox cbxFunc;
		private System.Windows.Forms.Button button1;
	}
}

