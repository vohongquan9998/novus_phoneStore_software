namespace QLDIENTHOAI.view.FormBanHang
{
    partial class FormDienThoai
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDienThoai));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbosort = new System.Windows.Forms.ComboBox();
            this.lbNum = new System.Windows.Forms.Label();
            this.cboHDH = new System.Windows.Forms.ComboBox();
            this.cboRam = new System.Windows.Forms.ComboBox();
            this.btnVsmart = new System.Windows.Forms.Button();
            this.btnOppo = new System.Windows.Forms.Button();
            this.btnSamsung = new System.Windows.Forms.Button();
            this.btnIphone = new System.Windows.Forms.Button();
            this.lbMaxGia = new System.Windows.Forms.Label();
            this.lbMinGia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad256 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rad128 = new System.Windows.Forms.RadioButton();
            this.rad64 = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.rad32 = new System.Windows.Forms.RadioButton();
            this.tbGia = new System.Windows.Forms.TrackBar();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnInfoSP = new System.Windows.Forms.Button();
            this.btnAddSP = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.dgvDSDT = new System.Windows.Forms.DataGridView();
            this.lbNumSP = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGia)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelMenu);
            this.panel1.Controls.Add(this.btnCart);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.dgvDSDT);
            this.panel1.Controls.Add(this.lbNumSP);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 695);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Controls.Add(this.cbosort);
            this.panel2.Controls.Add(this.lbNum);
            this.panel2.Controls.Add(this.cboHDH);
            this.panel2.Controls.Add(this.cboRam);
            this.panel2.Controls.Add(this.btnVsmart);
            this.panel2.Controls.Add(this.btnOppo);
            this.panel2.Controls.Add(this.btnSamsung);
            this.panel2.Controls.Add(this.btnIphone);
            this.panel2.Controls.Add(this.lbMaxGia);
            this.panel2.Controls.Add(this.lbMinGia);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.tbGia);
            this.panel2.Location = new System.Drawing.Point(129, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 109);
            this.panel2.TabIndex = 109;
            // 
            // cbosort
            // 
            this.cbosort.FormattingEnabled = true;
            this.cbosort.Items.AddRange(new object[] {
            "Giá cao đến thấp",
            "Giá thấp đến cao"});
            this.cbosort.Location = new System.Drawing.Point(407, 74);
            this.cbosort.Name = "cbosort";
            this.cbosort.Size = new System.Drawing.Size(136, 21);
            this.cbosort.TabIndex = 110;
            this.cbosort.Text = "Sắp xếp theo";
            this.cbosort.SelectedIndexChanged += new System.EventHandler(this.cbosort_SelectedIndexChanged);
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNum.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbNum.Location = new System.Drawing.Point(7, 6);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(40, 17);
            this.lbNum.TabIndex = 109;
            this.lbNum.Text = "0000";
            // 
            // cboHDH
            // 
            this.cboHDH.FormattingEnabled = true;
            this.cboHDH.Items.AddRange(new object[] {
            "Android",
            "IOS"});
            this.cboHDH.Location = new System.Drawing.Point(407, 45);
            this.cboHDH.Name = "cboHDH";
            this.cboHDH.Size = new System.Drawing.Size(136, 21);
            this.cboHDH.TabIndex = 108;
            this.cboHDH.Text = "Hệ điều hành";
            this.cboHDH.SelectedIndexChanged += new System.EventHandler(this.cboHDH_SelectedIndexChanged);
            // 
            // cboRam
            // 
            this.cboRam.FormattingEnabled = true;
            this.cboRam.Items.AddRange(new object[] {
            "2 GB",
            "3 GB",
            "4 GB",
            "6 GB",
            "8 GB",
            "12 GB"});
            this.cboRam.Location = new System.Drawing.Point(407, 16);
            this.cboRam.Name = "cboRam";
            this.cboRam.Size = new System.Drawing.Size(136, 21);
            this.cboRam.TabIndex = 108;
            this.cboRam.Text = "RAM";
            this.cboRam.SelectedIndexChanged += new System.EventHandler(this.cboRam_SelectedIndexChanged);
            // 
            // btnVsmart
            // 
            this.btnVsmart.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnVsmart.FlatAppearance.BorderSize = 0;
            this.btnVsmart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVsmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVsmart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnVsmart.Location = new System.Drawing.Point(224, 60);
            this.btnVsmart.Name = "btnVsmart";
            this.btnVsmart.Size = new System.Drawing.Size(80, 32);
            this.btnVsmart.TabIndex = 107;
            this.btnVsmart.Text = "Vsmart";
            this.btnVsmart.UseVisualStyleBackColor = false;
            this.btnVsmart.Click += new System.EventHandler(this.btnVsmart_Click);
            // 
            // btnOppo
            // 
            this.btnOppo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnOppo.FlatAppearance.BorderSize = 0;
            this.btnOppo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOppo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOppo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOppo.Location = new System.Drawing.Point(310, 60);
            this.btnOppo.Name = "btnOppo";
            this.btnOppo.Size = new System.Drawing.Size(80, 32);
            this.btnOppo.TabIndex = 107;
            this.btnOppo.Text = "Oppo";
            this.btnOppo.UseVisualStyleBackColor = false;
            this.btnOppo.Click += new System.EventHandler(this.btnOppo_Click);
            // 
            // btnSamsung
            // 
            this.btnSamsung.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSamsung.FlatAppearance.BorderSize = 0;
            this.btnSamsung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSamsung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSamsung.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSamsung.Location = new System.Drawing.Point(310, 20);
            this.btnSamsung.Name = "btnSamsung";
            this.btnSamsung.Size = new System.Drawing.Size(80, 32);
            this.btnSamsung.TabIndex = 107;
            this.btnSamsung.Text = "Samsung";
            this.btnSamsung.UseVisualStyleBackColor = false;
            this.btnSamsung.Click += new System.EventHandler(this.btnSamsung_Click);
            // 
            // btnIphone
            // 
            this.btnIphone.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnIphone.FlatAppearance.BorderSize = 0;
            this.btnIphone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIphone.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnIphone.Location = new System.Drawing.Point(224, 20);
            this.btnIphone.Name = "btnIphone";
            this.btnIphone.Size = new System.Drawing.Size(80, 32);
            this.btnIphone.TabIndex = 107;
            this.btnIphone.Text = "iPhone";
            this.btnIphone.UseVisualStyleBackColor = false;
            this.btnIphone.Click += new System.EventHandler(this.btnIphone_Click);
            // 
            // lbMaxGia
            // 
            this.lbMaxGia.AutoSize = true;
            this.lbMaxGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxGia.ForeColor = System.Drawing.Color.White;
            this.lbMaxGia.Location = new System.Drawing.Point(132, 86);
            this.lbMaxGia.Name = "lbMaxGia";
            this.lbMaxGia.Size = new System.Drawing.Size(14, 15);
            this.lbMaxGia.TabIndex = 3;
            this.lbMaxGia.Text = "n";
            // 
            // lbMinGia
            // 
            this.lbMinGia.AutoSize = true;
            this.lbMinGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinGia.ForeColor = System.Drawing.Color.White;
            this.lbMinGia.Location = new System.Drawing.Point(7, 86);
            this.lbMinGia.Name = "lbMinGia";
            this.lbMinGia.Size = new System.Drawing.Size(14, 15);
            this.lbMinGia.TabIndex = 3;
            this.lbMinGia.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn mức giá phù hợp với bạn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad256);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rad128);
            this.groupBox1.Controls.Add(this.rad64);
            this.groupBox1.Controls.Add(this.radAll);
            this.groupBox1.Controls.Add(this.rad32);
            this.groupBox1.Location = new System.Drawing.Point(559, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rad256
            // 
            this.rad256.AutoSize = true;
            this.rad256.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rad256.Location = new System.Drawing.Point(47, 89);
            this.rad256.Name = "rad256";
            this.rad256.Size = new System.Drawing.Size(58, 17);
            this.rad256.TabIndex = 0;
            this.rad256.TabStop = true;
            this.rad256.Text = "256GB";
            this.rad256.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bộ nhớ trong";
            // 
            // rad128
            // 
            this.rad128.AutoSize = true;
            this.rad128.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rad128.Location = new System.Drawing.Point(47, 66);
            this.rad128.Name = "rad128";
            this.rad128.Size = new System.Drawing.Size(58, 17);
            this.rad128.TabIndex = 0;
            this.rad128.TabStop = true;
            this.rad128.Text = "128GB";
            this.rad128.UseVisualStyleBackColor = true;
            // 
            // rad64
            // 
            this.rad64.AutoSize = true;
            this.rad64.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rad64.Location = new System.Drawing.Point(47, 43);
            this.rad64.Name = "rad64";
            this.rad64.Size = new System.Drawing.Size(52, 17);
            this.rad64.TabIndex = 0;
            this.rad64.TabStop = true;
            this.rad64.Text = "64GB";
            this.rad64.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.radAll.Location = new System.Drawing.Point(6, 57);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(14, 13);
            this.radAll.TabIndex = 0;
            this.radAll.TabStop = true;
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Visible = false;
            // 
            // rad32
            // 
            this.rad32.AutoSize = true;
            this.rad32.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rad32.Location = new System.Drawing.Point(47, 20);
            this.rad32.Name = "rad32";
            this.rad32.Size = new System.Drawing.Size(52, 17);
            this.rad32.TabIndex = 0;
            this.rad32.TabStop = true;
            this.rad32.Text = "32GB";
            this.rad32.UseVisualStyleBackColor = true;
            // 
            // tbGia
            // 
            this.tbGia.LargeChange = 1000000;
            this.tbGia.Location = new System.Drawing.Point(35, 61);
            this.tbGia.Maximum = 35000000;
            this.tbGia.Minimum = 1000000;
            this.tbGia.Name = "tbGia";
            this.tbGia.Size = new System.Drawing.Size(139, 45);
            this.tbGia.TabIndex = 0;
            this.tbGia.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbGia.Value = 35000000;
            this.tbGia.Scroll += new System.EventHandler(this.tbGia_Scroll);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelMenu.Controls.Add(this.btnInfoSP);
            this.panelMenu.Controls.Add(this.btnAddSP);
            this.panelMenu.Location = new System.Drawing.Point(603, 620);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(372, 75);
            this.panelMenu.TabIndex = 108;
            this.panelMenu.Visible = false;
            // 
            // btnInfoSP
            // 
            this.btnInfoSP.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnInfoSP.FlatAppearance.BorderSize = 0;
            this.btnInfoSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoSP.ForeColor = System.Drawing.Color.Black;
            this.btnInfoSP.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoSP.Image")));
            this.btnInfoSP.Location = new System.Drawing.Point(195, 12);
            this.btnInfoSP.Name = "btnInfoSP";
            this.btnInfoSP.Size = new System.Drawing.Size(165, 52);
            this.btnInfoSP.TabIndex = 107;
            this.btnInfoSP.UseVisualStyleBackColor = false;
            this.btnInfoSP.Click += new System.EventHandler(this.btnInfoSP_Click);
            this.btnInfoSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnInfoSP_MouseMove);
            // 
            // btnAddSP
            // 
            this.btnAddSP.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAddSP.FlatAppearance.BorderSize = 0;
            this.btnAddSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSP.ForeColor = System.Drawing.Color.Black;
            this.btnAddSP.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSP.Image")));
            this.btnAddSP.Location = new System.Drawing.Point(15, 12);
            this.btnAddSP.Name = "btnAddSP";
            this.btnAddSP.Size = new System.Drawing.Size(166, 52);
            this.btnAddSP.TabIndex = 107;
            this.btnAddSP.UseVisualStyleBackColor = false;
            this.btnAddSP.Click += new System.EventHandler(this.btnAddSP_Click);
            this.btnAddSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAddSP_MouseMove);
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.ForeColor = System.Drawing.Color.Black;
            this.btnCart.Image = ((System.Drawing.Image)(resources.GetObject("btnCart.Image")));
            this.btnCart.Location = new System.Drawing.Point(902, 9);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(66, 52);
            this.btnCart.TabIndex = 107;
            this.btnCart.UseVisualStyleBackColor = false;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.DarkCyan;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(825, 9);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(71, 110);
            this.btnFind.TabIndex = 107;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Teal;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(12, 67);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(111, 52);
            this.btnReset.TabIndex = 106;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Teal;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.ForeColor = System.Drawing.Color.Black;
            this.btnback.Image = ((System.Drawing.Image)(resources.GetObject("btnback.Image")));
            this.btnback.Location = new System.Drawing.Point(12, 10);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(111, 52);
            this.btnback.TabIndex = 106;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // dgvDSDT
            // 
            this.dgvDSDT.AllowUserToAddRows = false;
            this.dgvDSDT.AllowUserToDeleteRows = false;
            this.dgvDSDT.AllowUserToResizeColumns = false;
            this.dgvDSDT.AllowUserToResizeRows = false;
            this.dgvDSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSDT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSDT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDSDT.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dgvDSDT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDSDT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvDSDT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSDT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSDT.ColumnHeadersHeight = 50;
            this.dgvDSDT.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSDT.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSDT.EnableHeadersVisualStyles = false;
            this.dgvDSDT.GridColor = System.Drawing.Color.DarkCyan;
            this.dgvDSDT.Location = new System.Drawing.Point(-1, 125);
            this.dgvDSDT.Name = "dgvDSDT";
            this.dgvDSDT.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSDT.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSDT.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSDT.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSDT.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDSDT.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvDSDT.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDSDT.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDSDT.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvDSDT.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDSDT.RowTemplate.Height = 40;
            this.dgvDSDT.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSDT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDSDT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSDT.Size = new System.Drawing.Size(976, 570);
            this.dgvDSDT.TabIndex = 105;
            this.dgvDSDT.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSDT_CellDoubleClick);
            this.dgvDSDT.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSDT_CellEnter);
            // 
            // lbNumSP
            // 
            this.lbNumSP.BackColor = System.Drawing.Color.DarkCyan;
            this.lbNumSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbNumSP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbNumSP.Location = new System.Drawing.Point(916, 47);
            this.lbNumSP.Name = "lbNumSP";
            this.lbNumSP.Size = new System.Drawing.Size(37, 69);
            this.lbNumSP.TabIndex = 110;
            this.lbNumSP.Text = "//";
            this.lbNumSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNumSP.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormDienThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDienThoai";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDienThoai";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGia)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDSDT;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnInfoSP;
        private System.Windows.Forms.Button btnAddSP;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar tbGia;
        private System.Windows.Forms.Label lbMaxGia;
        private System.Windows.Forms.Label lbMinGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad256;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rad128;
        private System.Windows.Forms.RadioButton rad64;
        private System.Windows.Forms.RadioButton rad32;
        private System.Windows.Forms.Label lbNumSP;
        private System.Windows.Forms.Button btnVsmart;
        private System.Windows.Forms.Button btnOppo;
        private System.Windows.Forms.Button btnSamsung;
        private System.Windows.Forms.Button btnIphone;
        private System.Windows.Forms.ComboBox cboHDH;
        private System.Windows.Forms.ComboBox cboRam;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.ComboBox cbosort;
    }
}