namespace SocketClient
{
    partial class SocketClient
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
            this.SuspendLayout();
            // 
            // msgtb
            // 
            this.msgtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgtb.Location = new System.Drawing.Point(0, 0);
            this.msgtb.Multiline = true;
            this.msgtb.Name = "msgtb";
            this.msgtb.Size = new System.Drawing.Size(800, 427);
            this.msgtb.TabIndex = 0;
            // 
            // msgsd
            // 
            this.msgsd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.msgsd.Location = new System.Drawing.Point(0, 427);
            this.msgsd.Name = "msgsd";
            this.msgsd.Size = new System.Drawing.Size(800, 23);
            this.msgsd.TabIndex = 1;
            this.msgsd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            // 
            // SocketClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msgtb);
            this.Controls.Add(this.msgsd);
            this.Name = "SocketClient";
            this.Text = "client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox msgtb;
        public System.Windows.Forms.TextBox msgsd;
    }
}
