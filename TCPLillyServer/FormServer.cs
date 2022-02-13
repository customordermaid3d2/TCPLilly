using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SocketServer
{
    public partial class ServerTest : Form
    {
        internal static SocketLib.TcpServerBase socket;
        
        public ServerTest()
        {
            InitializeComponent();

            Shown += ServerTest_Shown;
        }

        private void ServerTest_Shown(object sender, EventArgs e)
        {
            log("form run");

            socket = new SocketLib.TcpServerBase();
            socket.log += log;
            socket.receive += log;

            log("socket run");

            Task.Factory.StartNew(() => socket.run());
        }

        void log(string log)
        {
            this.Invoke(new Action(delegate ()
            {
                msgtb.AppendText("L:" + log + "\r\n");
            }));
        }

        void receive(string log)
        {
            this.Invoke(new Action(delegate ()
            {
                msgtb.AppendText("R:" + log + "\r\n");
            }));
        }

        private void msgtb_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control && !e.Alt && !e.Shift)
            {
                socket.send(msgsd.Text);
                msgsd.Clear();
            }
        }

        private void msgsd_TextChanged(object sender, EventArgs e)
        {

        }

        //[Serializable]
        Dictionary<int,string> d=new Dictionary<int,string>();
        //XmlSerializer Serializer= new XmlSerializer();

        private void button1_Click(object sender, EventArgs e)
        {
            if (d.Count==0)
            {
            for (int i = 0; i < 100; i++)
            {
                //socket.send($"loop {i}");
                d[i] = $"loop {i}";
            }
            d[999]= "\r\n";
            }

            var s = JsonConvert.SerializeObject(d);
            socket.send(s);
            /*
            var s = JsonSerializer.Serialize<Dictionary< int,string>>(d);
            socket.send(s);
            */
            /*
                // 지원 불가
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dictionary<int, string>));
                //xmlSerializer.Serialize(memoryStream, d);             

                socket.send(memoryStream.ToArray());
            }
            */
        }
    }
}
