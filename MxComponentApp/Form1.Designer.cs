namespace MxComponentApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.axActUtlType1 = new AxActUtlTypeLib.AxActUtlType();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConNode = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtWriteAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axActUtlType1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "M0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "地址：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 22);
            this.button2.TabIndex = 2;
            this.button2.Text = "读取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(144, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 21);
            this.button3.TabIndex = 2;
            this.button3.Text = "写入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(3, 17);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(387, 330);
            this.txtMessage.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Location = new System.Drawing.Point(499, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 350);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "展示区";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.axActUtlType1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtConNode);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 96);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数设置区";
            // 
            // axActUtlType1
            // 
            this.axActUtlType1.Enabled = true;
            this.axActUtlType1.Location = new System.Drawing.Point(188, 20);
            this.axActUtlType1.Name = "axActUtlType1";
            this.axActUtlType1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActUtlType1.OcxState")));
            this.axActUtlType1.Size = new System.Drawing.Size(32, 32);
            this.axActUtlType1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "节点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(222, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "未连接";
            // 
            // txtConNode
            // 
            this.txtConNode.Location = new System.Drawing.Point(75, 25);
            this.txtConNode.Name = "txtConNode";
            this.txtConNode.Size = new System.Drawing.Size(100, 21);
            this.txtConNode.TabIndex = 3;
            this.txtConNode.Text = "1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(12, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 125);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "读取";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(75, 81);
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
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.txtWriteValue);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Location = new System.Drawing.Point(12, 242);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(481, 120);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "写入";
            // 
            // txtWriteAddress
            // 
            this.txtWriteAddress.Location = new System.Drawing.Point(79, 20);
            this.txtWriteAddress.Multiline = true;
            this.txtWriteAddress.Name = "txtWriteAddress";
            this.txtWriteAddress.Size = new System.Drawing.Size(128, 28);
            this.txtWriteAddress.TabIndex = 3;
            this.txtWriteAddress.Text = "M0.1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "值：";
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(274, 20);
            this.txtWriteValue.Multiline = true;
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(128, 26);
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
            this.button5.Location = new System.Drawing.Point(274, 70);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(72, 21);
            this.button5.TabIndex = 2;
            this.button5.Text = "单个写入";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Location = new System.Drawing.Point(248, 115);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 124);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "批量读取";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 22);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 40);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Y0,D0,D1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "地址：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 374);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axActUtlType1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConNode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtWriteAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.Label label5;
        private AxActUtlTypeLib.AxActUtlType axActUtlType1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}

