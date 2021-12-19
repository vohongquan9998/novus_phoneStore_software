namespace QLDIENTHOAI.view
{
    partial class FormTraCuuDT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTraCuuDT));
            this.label6 = new System.Windows.Forms.Label();
            this.txtMASP = new System.Windows.Forms.TextBox();
            this.txtDonGiaMax = new System.Windows.Forms.TextBox();
            this.txtDonGiaMin = new System.Windows.Forms.TextBox();
            this.txtTenDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rad256 = new System.Windows.Forms.RadioButton();
            this.rad64 = new System.Windows.Forms.RadioButton();
            this.rad128 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.rad32 = new System.Windows.Forms.RadioButton();
            this.grChitiet = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCT = new System.Windows.Forms.TextBox();
            this.dgvDSDT = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnQL = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radHetHang = new System.Windows.Forms.RadioButton();
            this.radConhang = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtNumItem = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.grChitiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDT)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "~";
            // 
            // txtMASP
            // 
            this.txtMASP.Location = new System.Drawing.Point(133, 14);
            this.txtMASP.Name = "txtMASP";
            this.txtMASP.Size = new System.Drawing.Size(154, 20);
            this.txtMASP.TabIndex = 1;
            // 
            // txtDonGiaMax
            // 
            this.txtDonGiaMax.Location = new System.Drawing.Point(159, 133);
            this.txtDonGiaMax.MaxLength = 10;
            this.txtDonGiaMax.Name = "txtDonGiaMax";
            this.txtDonGiaMax.Size = new System.Drawing.Size(82, 20);
            this.txtDonGiaMax.TabIndex = 1;
            this.txtDonGiaMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keypressNum);
            // 
            // txtDonGiaMin
            // 
            this.txtDonGiaMin.Location = new System.Drawing.Point(72, 133);
            this.txtDonGiaMin.MaxLength = 10;
            this.txtDonGiaMin.Name = "txtDonGiaMin";
            this.txtDonGiaMin.Size = new System.Drawing.Size(61, 20);
            this.txtDonGiaMin.TabIndex = 1;
            this.txtDonGiaMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keypressNum);
            // 
            // txtTenDT
            // 
            this.txtTenDT.Location = new System.Drawing.Point(133, 44);
            this.txtTenDT.Name = "txtTenDT";
            this.txtTenDT.Size = new System.Drawing.Size(154, 20);
            this.txtTenDT.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(9, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đơn giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(56, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã ĐT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(34, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên dòng ĐT:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rad256);
            this.groupBox2.Controls.Add(this.rad64);
            this.groupBox2.Controls.Add(this.rad128);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.radAll);
            this.groupBox2.Controls.Add(this.rad32);
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // rad256
            // 
            this.rad256.AutoSize = true;
            this.rad256.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rad256.Location = new System.Drawing.Point(166, 31);
            this.rad256.Name = "rad256";
            this.rad256.Size = new System.Drawing.Size(58, 17);
            this.rad256.TabIndex = 3;
            this.rad256.TabStop = true;
            this.rad256.Text = "256GB";
            this.rad256.UseVisualStyleBackColor = true;
            this.rad256.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.rad256.MouseLeave += new System.EventHandler(this.rad256_MouseLeave);
            this.rad256.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rad256_MouseMove);
            // 
            // rad64
            // 
            this.rad64.AutoSize = true;
            this.rad64.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rad64.Location = new System.Drawing.Point(166, 10);
            this.rad64.Name = "rad64";
            this.rad64.Size = new System.Drawing.Size(52, 17);
            this.rad64.TabIndex = 3;
            this.rad64.TabStop = true;
            this.rad64.Text = "64GB";
            this.rad64.UseVisualStyleBackColor = true;
            this.rad64.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.rad64.MouseLeave += new System.EventHandler(this.rad64_MouseLeave);
            this.rad64.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rad64_MouseMove);
            // 
            // rad128
            // 
            this.rad128.AutoSize = true;
            this.rad128.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rad128.Location = new System.Drawing.Point(102, 31);
            this.rad128.Name = "rad128";
            this.rad128.Size = new System.Drawing.Size(58, 17);
            this.rad128.TabIndex = 3;
            this.rad128.TabStop = true;
            this.rad128.Text = "128GB";
            this.rad128.UseVisualStyleBackColor = true;
            this.rad128.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.rad128.MouseLeave += new System.EventHandler(this.rad128_MouseLeave);
            this.rad128.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rad128_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(8, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dung lượng:";
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.BackColor = System.Drawing.Color.DarkCyan;
            this.radAll.Checked = true;
            this.radAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.radAll.Location = new System.Drawing.Point(25, 22);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(56, 17);
            this.radAll.TabIndex = 3;
            this.radAll.TabStop = true;
            this.radAll.Text = "Tất cả";
            this.radAll.UseVisualStyleBackColor = false;
            this.radAll.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // rad32
            // 
            this.rad32.AutoSize = true;
            this.rad32.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rad32.Location = new System.Drawing.Point(102, 10);
            this.rad32.Name = "rad32";
            this.rad32.Size = new System.Drawing.Size(52, 17);
            this.rad32.TabIndex = 3;
            this.rad32.TabStop = true;
            this.rad32.Text = "32GB";
            this.rad32.UseVisualStyleBackColor = true;
            this.rad32.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.rad32.MouseLeave += new System.EventHandler(this.rad32_MouseLeave);
            this.rad32.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rad32_MouseMove);
            // 
            // grChitiet
            // 
            this.grChitiet.BackColor = System.Drawing.Color.LightSeaGreen;
            this.grChitiet.Controls.Add(this.label15);
            this.grChitiet.Controls.Add(this.txtCT);
            this.grChitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grChitiet.Location = new System.Drawing.Point(680, 0);
            this.grChitiet.Name = "grChitiet";
            this.grChitiet.Size = new System.Drawing.Size(225, 226);
            this.grChitiet.TabIndex = 0;
            this.grChitiet.TabStop = false;
            this.grChitiet.Text = "Chi tiết điện thoại";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label15.Location = new System.Drawing.Point(162, 231);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 189);
            this.label15.TabIndex = 108;
            this.label15.Paint += new System.Windows.Forms.PaintEventHandler(this.label15_Paint);
            // 
            // txtCT
            // 
            this.txtCT.BackColor = System.Drawing.Color.DarkCyan;
            this.txtCT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCT.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCT.ForeColor = System.Drawing.Color.White;
            this.txtCT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCT.Location = new System.Drawing.Point(3, 25);
            this.txtCT.Multiline = true;
            this.txtCT.Name = "txtCT";
            this.txtCT.ReadOnly = true;
            this.txtCT.Size = new System.Drawing.Size(219, 199);
            this.txtCT.TabIndex = 1;
            // 
            // dgvDSDT
            // 
            this.dgvDSDT.AllowUserToAddRows = false;
            this.dgvDSDT.AllowUserToDeleteRows = false;
            this.dgvDSDT.AllowUserToResizeRows = false;
            this.dgvDSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvDSDT.Location = new System.Drawing.Point(0, 218);
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
            this.dgvDSDT.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvDSDT.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDSDT.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvDSDT.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDSDT.RowTemplate.Height = 40;
            this.dgvDSDT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSDT.Size = new System.Drawing.Size(877, 459);
            this.dgvDSDT.TabIndex = 1;
            this.dgvDSDT.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSDT_CellEnter);
            this.dgvDSDT.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDSDT_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(486, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 700);
            this.panel1.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel6.Location = new System.Drawing.Point(34, 41);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(57, 102);
            this.panel6.TabIndex = 103;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(57, 58);
            this.panel4.TabIndex = 103;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel5.Location = new System.Drawing.Point(33, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(58, 26);
            this.panel5.TabIndex = 103;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Teal;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.ForeColor = System.Drawing.Color.Black;
            this.btnback.Image = ((System.Drawing.Image)(resources.GetObject("btnback.Image")));
            this.btnback.Location = new System.Drawing.Point(17, 13);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(78, 100);
            this.btnback.TabIndex = 8;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            this.btnback.MouseLeave += new System.EventHandler(this.btnback_MouseLeave);
            this.btnback.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnback_MouseMove);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.DarkCyan;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(452, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(140, 87);
            this.btnFind.TabIndex = 10;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            this.btnFind.MouseLeave += new System.EventHandler(this.btnFind_MouseLeave);
            this.btnFind.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFind_MouseMove);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel3.Controls.Add(this.btnQL);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.dgvDSDT);
            this.panel3.Controls.Add(this.txtNumItem);
            this.panel3.Controls.Add(this.btnFind);
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Location = new System.Drawing.Point(16, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(877, 677);
            this.panel3.TabIndex = 11;
            // 
            // btnQL
            // 
            this.btnQL.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnQL.FlatAppearance.BorderSize = 0;
            this.btnQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQL.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnQL.Image = ((System.Drawing.Image)(resources.GetObject("btnQL.Image")));
            this.btnQL.Location = new System.Drawing.Point(17, 119);
            this.btnQL.Name = "btnQL";
            this.btnQL.Size = new System.Drawing.Size(78, 77);
            this.btnQL.TabIndex = 9;
            this.btnQL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQL.UseVisualStyleBackColor = false;
            this.btnQL.Click += new System.EventHandler(this.btnQL_Click);
            this.btnQL.MouseLeave += new System.EventHandler(this.btnQL_MouseLeave);
            this.btnQL.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnQL_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMASP);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.txtDonGiaMax);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtDonGiaMin);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTenDT);
            this.panel2.Location = new System.Drawing.Point(101, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 183);
            this.panel2.TabIndex = 103;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radHetHang);
            this.groupBox1.Controls.Add(this.radConhang);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(247, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(82, 94);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trạng thái";
            // 
            // radHetHang
            // 
            this.radHetHang.AutoSize = true;
            this.radHetHang.Location = new System.Drawing.Point(6, 68);
            this.radHetHang.Name = "radHetHang";
            this.radHetHang.Size = new System.Drawing.Size(69, 17);
            this.radHetHang.TabIndex = 0;
            this.radHetHang.Text = "Hết hàng";
            this.radHetHang.UseVisualStyleBackColor = true;
            this.radHetHang.CheckedChanged += new System.EventHandler(this.chkTrangThai);
            // 
            // radConhang
            // 
            this.radConhang.AutoSize = true;
            this.radConhang.Location = new System.Drawing.Point(6, 45);
            this.radConhang.Name = "radConhang";
            this.radConhang.Size = new System.Drawing.Size(71, 17);
            this.radConhang.TabIndex = 0;
            this.radConhang.Text = "Còn hàng";
            this.radConhang.UseVisualStyleBackColor = true;
            this.radConhang.CheckedChanged += new System.EventHandler(this.chkTrangThai);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tất cả";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.chkTrangThai);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Teal;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(452, 106);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 76);
            this.btnReset.TabIndex = 9;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseLeave += new System.EventHandler(this.btnReset_MouseLeave);
            this.btnReset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseMove);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DarkCyan;
            this.panel9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel9.Location = new System.Drawing.Point(598, 13);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(60, 87);
            this.panel9.TabIndex = 103;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Teal;
            this.panel7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel7.Location = new System.Drawing.Point(550, 106);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(108, 25);
            this.panel7.TabIndex = 103;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DarkCyan;
            this.panel8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel8.Location = new System.Drawing.Point(612, 140);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(46, 42);
            this.panel8.TabIndex = 103;
            // 
            // txtNumItem
            // 
            this.txtNumItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumItem.BackColor = System.Drawing.Color.Teal;
            this.txtNumItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumItem.Location = new System.Drawing.Point(545, 165);
            this.txtNumItem.Name = "txtNumItem";
            this.txtNumItem.ReadOnly = true;
            this.txtNumItem.Size = new System.Drawing.Size(56, 17);
            this.txtNumItem.TabIndex = 102;
            this.txtNumItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormTraCuuDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(905, 700);
            this.Controls.Add(this.grChitiet);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTraCuuDT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTraCuuDT";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grChitiet.ResumeLayout(false);
            this.grChitiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDT)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grChitiet;
        private System.Windows.Forms.DataGridView dgvDSDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCT;
        private System.Windows.Forms.TextBox txtMASP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNumItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDonGiaMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rad32;
        private System.Windows.Forms.RadioButton rad256;
        private System.Windows.Forms.RadioButton rad64;
        private System.Windows.Forms.RadioButton rad128;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDonGiaMax;
        private System.Windows.Forms.Button btnQL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radConhang;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radHetHang;
    }
}