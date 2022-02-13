namespace SocketServer
{
    partial class ServerTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msgtb = new System.Windows.Forms.TextBox();
            this.msgsd = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgtb
            // 
            this.msgtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgtb.Location = new System.Drawing.Point(0, 0);
            this.msgtb.Multiline = true;
            this.msgtb.Name = "msgtb";
            this.msgtb.Size = new System.Drawing.Size(800, 398);
            this.msgtb.TabIndex = 0;
            // 
            // msgsd
            // 
            this.msgsd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.msgsd.Location = new System.Drawing.Point(0, 427);
            this.msgsd.Name = "msgsd";
            this.msgsd.Size = new System.Drawing.Size(800, 23);
            this.msgsd.TabIndex = 1;
            this.msgsd.TextChanged += new System.EventHandler(this.msgsd_TextChanged);
            this.msgsd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.msgtb_KeyUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 398);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ServerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msgtb);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.msgsd);
            this.Name = "ServerTest";
            this.Text = "server";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox msgsd;
        public System.Windows.Forms.TextBox msgtb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}
