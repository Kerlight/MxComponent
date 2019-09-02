namespace MxComponentApp
{
    partial class HslReConntionFrm
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labPLC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(111, 22);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(145, 21);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192.168.0.113,1400";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "状态：";
            // 
            // labPLC
            // 
            this.labPLC.AutoSize = true;
            this.labPLC.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPLC.ForeColor = System.Drawing.Color.Red;
            this.labPLC.Location = new System.Drawing.Point(333, 24);
            this.labPLC.Name = "labPLC";
            this.labPLC.Size = new System.Drawing.Size(44, 17);
            this.labPLC.TabIndex = 3;
            this.labPLC.Text = "未连接";
            // 
            // HslReConntionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labPLC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.Name = "HslReConntionFrm";
            this.Text = "HslReConntionFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HslReConntionFrm_FormClosing);
            this.Load += new System.EventHandler(this.HslReConntionFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labPLC;
    }
}