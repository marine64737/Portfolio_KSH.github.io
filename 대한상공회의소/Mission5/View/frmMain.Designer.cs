namespace Mission5
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpMemberInfo = new System.Windows.Forms.GroupBox();
            this.btnSearchMember = new System.Windows.Forms.Button();
            this.lblOverdueFee = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblDaysOfOverdue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNumOfOverdue = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNumOfAvailable = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNumOfCheckOut = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.grpBookInfo = new System.Windows.Forms.GroupBox();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtBookCopyCode = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dgvBookList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBookList = new System.Windows.Forms.Button();
            this.grpMemberInfo.SuspendLayout();
            this.grpBookInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookList)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMemberInfo
            // 
            this.grpMemberInfo.Controls.Add(this.btnSearchMember);
            this.grpMemberInfo.Controls.Add(this.lblOverdueFee);
            this.grpMemberInfo.Controls.Add(this.label15);
            this.grpMemberInfo.Controls.Add(this.lblDaysOfOverdue);
            this.grpMemberInfo.Controls.Add(this.label11);
            this.grpMemberInfo.Controls.Add(this.lblNumOfOverdue);
            this.grpMemberInfo.Controls.Add(this.label13);
            this.grpMemberInfo.Controls.Add(this.lblNumOfAvailable);
            this.grpMemberInfo.Controls.Add(this.label7);
            this.grpMemberInfo.Controls.Add(this.lblNumOfCheckOut);
            this.grpMemberInfo.Controls.Add(this.label9);
            this.grpMemberInfo.Controls.Add(this.lblPhoneNo);
            this.grpMemberInfo.Controls.Add(this.label5);
            this.grpMemberInfo.Controls.Add(this.lblMemberName);
            this.grpMemberInfo.Controls.Add(this.label2);
            this.grpMemberInfo.Controls.Add(this.txtMemberId);
            this.grpMemberInfo.Controls.Add(this.label1);
            this.grpMemberInfo.Controls.Add(this.linkLabel1);
            this.grpMemberInfo.Location = new System.Drawing.Point(15, 16);
            this.grpMemberInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMemberInfo.Name = "grpMemberInfo";
            this.grpMemberInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMemberInfo.Size = new System.Drawing.Size(285, 300);
            this.grpMemberInfo.TabIndex = 0;
            this.grpMemberInfo.TabStop = false;
            this.grpMemberInfo.Text = "회원 정보";
            // 
            // btnSearchMember
            // 
            this.btnSearchMember.Location = new System.Drawing.Point(194, 20);
            this.btnSearchMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearchMember.Name = "btnSearchMember";
            this.btnSearchMember.Size = new System.Drawing.Size(73, 29);
            this.btnSearchMember.TabIndex = 19;
            this.btnSearchMember.Text = "조 회";
            this.btnSearchMember.UseVisualStyleBackColor = true;
            this.btnSearchMember.Click += new System.EventHandler(this.btnSearchMember_Click);
            // 
            // lblOverdueFee
            // 
            this.lblOverdueFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOverdueFee.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOverdueFee.Location = new System.Drawing.Point(107, 256);
            this.lblOverdueFee.Name = "lblOverdueFee";
            this.lblOverdueFee.Size = new System.Drawing.Size(114, 26);
            this.lblOverdueFee.TabIndex = 16;
            this.lblOverdueFee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Yellow;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(8, 256);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 26);
            this.label15.TabIndex = 15;
            this.label15.Text = "연체료";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDaysOfOverdue
            // 
            this.lblDaysOfOverdue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDaysOfOverdue.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDaysOfOverdue.Location = new System.Drawing.Point(107, 226);
            this.lblDaysOfOverdue.Name = "lblDaysOfOverdue";
            this.lblDaysOfOverdue.Size = new System.Drawing.Size(114, 26);
            this.lblDaysOfOverdue.TabIndex = 14;
            this.lblDaysOfOverdue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Yellow;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(8, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 26);
            this.label11.TabIndex = 13;
            this.label11.Text = "총 연체일";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumOfOverdue
            // 
            this.lblNumOfOverdue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumOfOverdue.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumOfOverdue.Location = new System.Drawing.Point(107, 196);
            this.lblNumOfOverdue.Name = "lblNumOfOverdue";
            this.lblNumOfOverdue.Size = new System.Drawing.Size(114, 26);
            this.lblNumOfOverdue.TabIndex = 12;
            this.lblNumOfOverdue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Yellow;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label13.Location = new System.Drawing.Point(8, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 26);
            this.label13.TabIndex = 11;
            this.label13.Text = "총 연체권수";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumOfAvailable
            // 
            this.lblNumOfAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumOfAvailable.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumOfAvailable.Location = new System.Drawing.Point(107, 165);
            this.lblNumOfAvailable.Name = "lblNumOfAvailable";
            this.lblNumOfAvailable.Size = new System.Drawing.Size(114, 26);
            this.lblNumOfAvailable.TabIndex = 10;
            this.lblNumOfAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(8, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 26);
            this.label7.TabIndex = 9;
            this.label7.Text = "대출가능";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumOfCheckOut
            // 
            this.lblNumOfCheckOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumOfCheckOut.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumOfCheckOut.Location = new System.Drawing.Point(107, 134);
            this.lblNumOfCheckOut.Name = "lblNumOfCheckOut";
            this.lblNumOfCheckOut.Size = new System.Drawing.Size(114, 26);
            this.lblNumOfCheckOut.TabIndex = 8;
            this.lblNumOfCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Yellow;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(8, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 26);
            this.label9.TabIndex = 7;
            this.label9.Text = "총 대출";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPhoneNo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPhoneNo.Location = new System.Drawing.Point(107, 84);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(160, 26);
            this.lblPhoneNo.TabIndex = 5;
            this.lblPhoneNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(8, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "전화번호";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMemberName
            // 
            this.lblMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMemberName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMemberName.Location = new System.Drawing.Point(107, 52);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(160, 26);
            this.lblMemberName.TabIndex = 3;
            this.lblMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "이 름";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMemberId.Location = new System.Drawing.Point(107, 21);
            this.txtMemberId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMemberId.MaxLength = 10;
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(79, 25);
            this.txtMemberId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "회원 아이디";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel1.Location = new System.Drawing.Point(6, 109);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(252, 15);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "                                                 ";
            // 
            // grpBookInfo
            // 
            this.grpBookInfo.Controls.Add(this.btnSearchBook);
            this.grpBookInfo.Controls.Add(this.lblPublisher);
            this.grpBookInfo.Controls.Add(this.label27);
            this.grpBookInfo.Controls.Add(this.lblTitle);
            this.grpBookInfo.Controls.Add(this.label29);
            this.grpBookInfo.Controls.Add(this.txtBookCopyCode);
            this.grpBookInfo.Controls.Add(this.label30);
            this.grpBookInfo.Location = new System.Drawing.Point(306, 16);
            this.grpBookInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpBookInfo.Name = "grpBookInfo";
            this.grpBookInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpBookInfo.Size = new System.Drawing.Size(344, 132);
            this.grpBookInfo.TabIndex = 17;
            this.grpBookInfo.TabStop = false;
            this.grpBookInfo.Text = "도서 정보";
            // 
            // btnSearchBook
            // 
            this.btnSearchBook.Location = new System.Drawing.Point(251, 19);
            this.btnSearchBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(73, 29);
            this.btnSearchBook.TabIndex = 18;
            this.btnSearchBook.Text = "조 회";
            this.btnSearchBook.UseVisualStyleBackColor = true;
            this.btnSearchBook.Click += new System.EventHandler(this.btnSearchBook_Click);
            // 
            // lblPublisher
            // 
            this.lblPublisher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPublisher.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPublisher.Location = new System.Drawing.Point(120, 84);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(204, 26);
            this.lblPublisher.TabIndex = 5;
            this.lblPublisher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Yellow;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label27.Location = new System.Drawing.Point(8, 84);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(105, 26);
            this.label27.TabIndex = 4;
            this.label27.Text = "출 판 사";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(120, 52);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 26);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Yellow;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label29.Location = new System.Drawing.Point(8, 52);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(105, 26);
            this.label29.TabIndex = 2;
            this.label29.Text = "도 서 명";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBookCopyCode
            // 
            this.txtBookCopyCode.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBookCopyCode.Location = new System.Drawing.Point(120, 21);
            this.txtBookCopyCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookCopyCode.MaxLength = 9;
            this.txtBookCopyCode.Name = "txtBookCopyCode";
            this.txtBookCopyCode.Size = new System.Drawing.Size(124, 25);
            this.txtBookCopyCode.TabIndex = 1;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Yellow;
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label30.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label30.Location = new System.Drawing.Point(8, 21);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(105, 26);
            this.label30.TabIndex = 0;
            this.label30.Text = "도서등록번호";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvBookList
            // 
            this.dgvBookList.AllowUserToAddRows = false;
            this.dgvBookList.AllowUserToDeleteRows = false;
            this.dgvBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvBookList.Location = new System.Drawing.Point(15, 336);
            this.dgvBookList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvBookList.MultiSelect = false;
            this.dgvBookList.Name = "dgvBookList";
            this.dgvBookList.ReadOnly = true;
            this.dgvBookList.RowHeadersWidth = 51;
            this.dgvBookList.RowTemplate.Height = 23;
            this.dgvBookList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookList.Size = new System.Drawing.Size(703, 188);
            this.dgvBookList.TabIndex = 18;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CheckOutId";
            this.Column1.HeaderText = "대출ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BookCopyCode";
            this.Column2.FillWeight = 110F;
            this.Column2.HeaderText = "도서등록번호";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 110;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Title";
            this.Column3.HeaderText = "도서명";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CheckOutDate";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm";
            dataGridViewCellStyle1.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "대출일자";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DueDate";
            this.Column5.FillWeight = 80F;
            this.Column5.HeaderText = "반납예정";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "OverdueDays";
            this.Column6.FillWeight = 80F;
            this.Column6.HeaderText = "연체일";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "OverdueCharge";
            this.Column7.FillWeight = 65F;
            this.Column7.HeaderText = "연체료";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 65;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckOut.Image")));
            this.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.Location = new System.Drawing.Point(366, 191);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(114, 78);
            this.btnCheckOut.TabIndex = 19;
            this.btnCheckOut.Text = "대  출";
            this.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(499, 191);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(114, 78);
            this.btnReturn.TabIndex = 20;
            this.btnReturn.Text = "반  납";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(320, 538);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 42);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "닫 기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnBookList
            // 
            this.btnBookList.Location = new System.Drawing.Point(656, 35);
            this.btnBookList.Name = "btnBookList";
            this.btnBookList.Size = new System.Drawing.Size(75, 23);
            this.btnBookList.TabIndex = 22;
            this.btnBookList.Text = "책 목록";
            this.btnBookList.UseVisualStyleBackColor = true;
            this.btnBookList.Click += new System.EventHandler(this.btnBookList_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 595);
            this.Controls.Add(this.btnBookList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.dgvBookList);
            this.Controls.Add(this.grpBookInfo);
            this.Controls.Add(this.grpMemberInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "도서 대출/반납";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpMemberInfo.ResumeLayout(false);
            this.grpMemberInfo.PerformLayout();
            this.grpBookInfo.ResumeLayout(false);
            this.grpBookInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMemberInfo;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblOverdueFee;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblDaysOfOverdue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNumOfOverdue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblNumOfAvailable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNumOfCheckOut;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpBookInfo;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtBookCopyCode;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridView dgvBookList;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnSearchMember;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btnBookList;
    }
}