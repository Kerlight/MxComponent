namespace MxComponentApp
{
    partial class MxComponentConnFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MxComponentConnFrm));
            this.btn_conn = new System.Windows.Forms.Button();
            this.axActUtlType1 = new AxActUtlTypeLib.AxActUtlType();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConNode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtWriteAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axActUtlType1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_conn
            // 
            this.btn_conn.Location = new System.Drawing.Point(345, 34);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(75, 23);
            this.btn_conn.TabIndex = 0;
            this.btn_conn.Text = "开始";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // axActUtlType1
            // 
            this.axActUtlType1.Enabled = true;
            this.axActUtlType1.Location = new System.Drawing.Point(229, 30);
            this.axActUtlType1.Name = "axActUtlType1";
            this.axActUtlType1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActUtlType1.OcxState")));
            this.axActUtlType1.Size = new System.Drawing.Size(32, 32);
            this.axActUtlType1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(263, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "未连接";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "节点：";
            // 
            // txtConNode
            // 
            this.txtConNode.Location = new System.Drawing.Point(77, 35);
            this.txtConNode.Name = "txtConNode";
            this.txtConNode.Size = new System.Drawing.Size(100, 21);
            this.txtConNode.TabIndex = 11;
            this.txtConNode.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.axActUtlType1);
            this.groupBox1.Controls.Add(this.txtConNode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_conn);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 80);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置区";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(6, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 125);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "读取";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "M0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "地址：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(87, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 22);
            this.button4.TabIndex = 2;
            this.button4.Text = "单个读取";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtWriteAddress);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtWriteValue);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Location = new System.Drawing.Point(6, 229);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 119);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "写入";
            // 
            // txtWriteAddress
            // 
            this.txtWriteAddress.Location = new System.Drawing.Point(79, 20);
            this.txtWriteAddress.Name = "txtWriteAddress";
            this.txtWriteAddress.Size = new System.Drawing.Size(90, 21);
            this.txtWriteAddress.TabIndex = 3;
            this.txtWriteAddress.Text = "M0.1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "值：";
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(80, 51);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(89, 21);
            this.txtWriteValue.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "地址：";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(80, 87);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(72, 21);
            this.button5.TabIndex = 2;
            this.button5.Text = "单个写入";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMessage);
            this.groupBox2.Location = new System.Drawing.Point(242, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 249);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "展示区";
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(3, 17);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(329, 229);
            this.txtMessage.TabIndex = 0;
            // 
            // MxComponentConnFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 349);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "MxComponentConnFrm";
            this.Text = "MxComponentConnFrm";
            this.Load += new System.EventHandler(this.MxComponentConnFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axActUtlType1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_conn;
        private AxActUtlTypeLib.AxActUtlType axActUtlType1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConNode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtWriteAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMessage;
    }
}