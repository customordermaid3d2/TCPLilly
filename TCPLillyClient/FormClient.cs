using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class SocketClient : Form
    {
        internal SocketLib.TcpClientBase socket;        

        public SocketClient()
        {
            InitializeComponent();

            Shown += ServerTest_Shown;
        }

        private void ServerTest_Shown(object sender, EventArgs e)
        {
            log("form run");

            socket = new SocketLib.TcpClientBase();
            socket.log += log;
            socket.receive += receive;

            log("socket run");
            
            Task.Factory.StartNew(() => socket.run());
        }

        void log(string log)
        {
            this.Invoke(new Action(delegate ()
            {
                msgtb.AppendText("L:"+log + "\r\n");
            }));
        }
        
        void receive(string log)
        {
            this.Invoke(new Action(delegate ()
            {
                msgtb.AppendText("R:" + log + "\r\n");
            }));
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Alt && !e.Shift)
            {                
                socket. send(msgsd.Text);
                msgsd.Clear();
            }
        }
    }
}
