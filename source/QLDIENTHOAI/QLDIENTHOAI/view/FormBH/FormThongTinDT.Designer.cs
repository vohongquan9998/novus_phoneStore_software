namespace QLDIENTHOAI.view.FormBH
{
    partial class FormThongTinDT
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radHethang = new System.Windows.Forms.RadioButton();
            this.radConhang = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDetal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.radHethang);
            this.panel1.Controls.Add(this.radConhang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDetal);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 570);
            this.panel1.TabIndex = 0;
            // 
            // radHethang
            // 
            this.radHethang.AutoSize = true;
            this.radHethang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHethang.Location = new System.Drawing.Point(246, 502);
            this.radHethang.Name = "radHethang";
            this.radHethang.Size = new System.Drawing.Size(85, 22);
            this.radHethang.TabIndex = 3;
            this.radHethang.TabStop = true;
            this.radHethang.Text = "Hết hàng";
            this.radHethang.UseVisualStyleBackColor = true;
            // 
            // radConhang
            // 
            this.radConhang.AutoSize = true;
            this.radConhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radConhang.Location = new System.Drawing.Point(112, 502);
            this.radConhang.Name = "radConhang";
            this.radConhang.Size = new System.Drawing.Size(90, 22);
            this.radConhang.TabIndex = 3;
            this.radConhang.TabStop = true;
            this.radConhang.Text = "Còn hàng";
            this.radConhang.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tình trạng:";
            // 
            // txtDetal
            // 
            this.txtDetal.AcceptsReturn = true;
            this.txtDetal.AcceptsTab = true;
            this.txtDetal.AllowDrop = true;
            this.txtDetal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetal.Location = new System.Drawing.Point(13, 18);
            this.txtDetal.Multiline = true;
            this.txtDetal.Name = "txtDetal";
            this.txtDetal.ReadOnly = true;
            this.txtDetal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetal.Size = new System.Drawing.Size(272, 434);
            this.txtDetal.TabIndex = 1;
            this.txtDetal.TabStop = false;
            // 
            // FormThongTinDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(401, 595);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormThongTinDT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDetal;
        private System.Windows.Forms.RadioButton radHethang;
        private System.Windows.Forms.RadioButton radConhang;
        private System.Windows.Forms.Label label1;
    }
}