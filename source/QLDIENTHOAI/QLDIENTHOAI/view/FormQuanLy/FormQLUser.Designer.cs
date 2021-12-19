namespace QLDIENTHOAI.view.FormQuanLy
{
    partial class FormQLUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQLUser));
            this.dgvQTV = new System.Windows.Forms.DataGridView();
            this.dgvND = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnChangeFind = new System.Windows.Forms.Button();
            this.btnChangeDelete = new System.Windows.Forms.Button();
            this.txtXoa = new System.Windows.Forms.TextBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQTV = new System.Windows.Forms.Button();
            this.btnND = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvND)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQTV
            // 
            this.dgvQTV.AllowUserToAddRows = false;
            this.dgvQTV.AllowUserToDeleteRows = false;
            this.dgvQTV.AllowUserToResizeRows = false;
            this.dgvQTV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQTV.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dgvQTV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQTV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvQTV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQTV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQTV.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQTV.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQTV.EnableHeadersVisualStyles = false;
            this.dgvQTV.GridColor = System.Drawing.Color.DarkCyan;
            this.dgvQTV.Location = new System.Drawing.Point(17, 102);
            this.dgvQTV.Name = "dgvQTV";
            this.dgvQTV.ReadOnly = true;
            this.dgvQTV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQTV.RowHeadersVisible = false;
            this.dgvQTV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvQTV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvQTV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvQTV.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvQTV.RowTemplate.Height = 40;
            this.dgvQTV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQTV.Size = new System.Drawing.Size(393, 379);
            this.dgvQTV.TabIndex = 5;
            this.dgvQTV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQTV_CellEnter);
            // 
            // dgvND
            // 
            this.dgvND.AllowUserToAddRows = false;
            this.dgvND.AllowUserToDeleteRows = false;
            this.dgvND.AllowUserToResizeRows = false;
            this.dgvND.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvND.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.dgvND.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvND.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvND.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvND.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvND.ColumnHeadersHeight = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvND.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvND.EnableHeadersVisualStyles = false;
            this.dgvND.GridColor = System.Drawing.Color.DarkCyan;
            this.dgvND.Location = new System.Drawing.Point(542, 102);
            this.dgvND.Name = "dgvND";
            this.dgvND.ReadOnly = true;
            this.dgvND.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvND.RowHeadersVisible = false;
            this.dgvND.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvND.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvND.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvND.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvND.RowTemplate.Height = 40;
            this.dgvND.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvND.Size = new System.Drawing.Size(390, 379);
            this.dgvND.TabIndex = 5;
            this.dgvND.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvND_CellEnter);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(416, 11);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 52);
            this.btnReset.TabIndex = 6;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Teal;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(416, 102);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(120, 69);
            this.btnFind.TabIndex = 7;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quản trị viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkCyan;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Người dùng";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.dgvND);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.dgvQTV);
            this.panel2.Controls.Add(this.btnChangeFind);
            this.panel2.Controls.Add(this.btnChangeDelete);
            this.panel2.Controls.Add(this.txtXoa);
            this.panel2.Controls.Add(this.txtFind);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.btnQTV);
            this.panel2.Controls.Add(this.btnND);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(948, 497);
            this.panel2.TabIndex = 10;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.DarkCyan;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.Black;
            this.btnback.Image = ((System.Drawing.Image)(resources.GetObject("btnback.Image")));
            this.btnback.Location = new System.Drawing.Point(17, 11);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(115, 86);
            this.btnback.TabIndex = 4;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel6.Location = new System.Drawing.Point(429, 317);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(52, 164);
            this.panel6.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel4.Location = new System.Drawing.Point(465, 219);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(49, 141);
            this.panel4.TabIndex = 12;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel8.Location = new System.Drawing.Point(499, 177);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(37, 72);
            this.panel8.TabIndex = 12;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel7.Location = new System.Drawing.Point(784, 202);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(164, 295);
            this.panel7.TabIndex = 9;
            // 
            // btnChangeFind
            // 
            this.btnChangeFind.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnChangeFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeFind.Location = new System.Drawing.Point(454, 69);
            this.btnChangeFind.Name = "btnChangeFind";
            this.btnChangeFind.Size = new System.Drawing.Size(27, 27);
            this.btnChangeFind.TabIndex = 10;
            this.btnChangeFind.UseVisualStyleBackColor = false;
            this.btnChangeFind.Click += new System.EventHandler(this.btnChangeFind_Click);
            this.btnChangeFind.MouseHover += new System.EventHandler(this.btnChangeFind_MouseHover);
            // 
            // btnChangeDelete
            // 
            this.btnChangeDelete.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnChangeDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeDelete.Location = new System.Drawing.Point(793, 22);
            this.btnChangeDelete.Name = "btnChangeDelete";
            this.btnChangeDelete.Size = new System.Drawing.Size(27, 27);
            this.btnChangeDelete.TabIndex = 10;
            this.btnChangeDelete.UseVisualStyleBackColor = false;
            this.btnChangeDelete.Click += new System.EventHandler(this.btnChangeDelete_Click);
            this.btnChangeDelete.MouseHover += new System.EventHandler(this.btnChangeDelete_MouseHover);
            // 
            // txtXoa
            // 
            this.txtXoa.Location = new System.Drawing.Point(625, 26);
            this.txtXoa.Name = "txtXoa";
            this.txtXoa.Size = new System.Drawing.Size(162, 20);
            this.txtXoa.TabIndex = 9;
            this.txtXoa.Click += new System.EventHandler(this.txtXoa_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(281, 69);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(168, 27);
            this.txtFind.TabIndex = 9;
            this.txtFind.Text = "Nhập tên Người Dùng cần tìm";
            this.txtFind.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFind.Click += new System.EventHandler(this.txtFind_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(542, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 52);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnQTV
            // 
            this.btnQTV.BackColor = System.Drawing.Color.DarkCyan;
            this.btnQTV.FlatAppearance.BorderSize = 0;
            this.btnQTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQTV.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQTV.Image = ((System.Drawing.Image)(resources.GetObject("btnQTV.Image")));
            this.btnQTV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQTV.Location = new System.Drawing.Point(669, 52);
            this.btnQTV.Name = "btnQTV";
            this.btnQTV.Size = new System.Drawing.Size(263, 44);
            this.btnQTV.TabIndex = 6;
            this.btnQTV.Text = "Thay đổi thành QTV";
            this.btnQTV.UseVisualStyleBackColor = false;
            this.btnQTV.Click += new System.EventHandler(this.btnQTV_Click);
            // 
            // btnND
            // 
            this.btnND.BackColor = System.Drawing.Color.Teal;
            this.btnND.Enabled = false;
            this.btnND.FlatAppearance.BorderSize = 0;
            this.btnND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnND.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnND.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnND.Image = ((System.Drawing.Image)(resources.GetObject("btnND.Image")));
            this.btnND.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnND.Location = new System.Drawing.Point(138, 11);
            this.btnND.Name = "btnND";
            this.btnND.Size = new System.Drawing.Size(272, 52);
            this.btnND.TabIndex = 6;
            this.btnND.Text = "Thay đổi thành Người dùng";
            this.btnND.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnND.UseVisualStyleBackColor = false;
            this.btnND.Click += new System.EventHandler(this.btnND_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(487, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 27);
            this.panel3.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(138, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 28);
            this.panel1.TabIndex = 11;
            // 
            // FormQLUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(972, 521);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormQLUser";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvND)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvQTV;
        private System.Windows.Forms.DataGridView dgvND;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQTV;
        private System.Windows.Forms.Button btnND;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtXoa;
        private System.Windows.Forms.Button btnChangeDelete;
        private System.Windows.Forms.Button btnChangeFind;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnback;
    }
}