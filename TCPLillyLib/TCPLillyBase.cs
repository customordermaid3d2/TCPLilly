using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace SocketLib
{
    public abstract class TcpBase
    {
        public bool isRun = true;
        public Action runs = () => { };
        public Action tcSet = () => { };

        public TcpClient tc;
        public NetworkStream stream;

        public string sockMsg = string.Empty;

        public Action<string> receive = (s) =>
        {
            //Debug.WriteLine("R:" + s);
            //Console.WriteLine("R:" + s);
        };
        public Action<string> log = (s) =>
        {
            //Debug.WriteLine("L:" + s);
            //Console.WriteLine("L:" + s);
        };

        public void run()
        {
            log("runs");
            runs();

            while (isRun)
            {
                log("tcSet");
                tcSet();

                while (tc.Connected)
                {
                    Receive();
                }
                tc.Close();
            }
            log("run end");
        }

        public void Receive()
        {
            try
            {
                log("Receive");
                //lock (stream = tc.GetStream())
                {
                    using (MemoryStream mstream = new MemoryStream())
                    {
                        byte[] buff = new byte[256];
                        log("Receive 2");
                        int nbytes, a=0;//tbytes=0,
                        do
                        {
                            //if (tbytes==0)
                            //{
                            //    var s = sizeof(int);
                            //    log($"Receive 31 {s} {buff.Length}");
                            //    tbytes = stream.Read(buff, 0, s);
                            //    nbytes = stream.Read(buff, s, buff.Length-s);
                            //    mstream.Write(buff, s, nbytes);
                            //    a +=  -s;
                            //}
                            nbytes = stream.Read(buff, 0, buff.Length);
                            a += nbytes;
                            log($"Receive 3 {nbytes} {a}");//{tbytes} 
                            mstream.Write(buff, 0, nbytes);
                        }
                        while (stream.DataAvailable);
                        var m= mstream.ToArray();
                        log($"Receive 4 {m.Length}");
                        receive(Encoding.UTF8.GetString(m));
                    }
                    //    stream.Close();
                }
            }
            catch (Exception e)
            {
                log($"run e: {e.Message}");
            }
        }

        public void send(string msg)
        {
            //log("send s" + msg);
            log("send s" );
            byte[] buff = Encoding.UTF8.GetBytes(msg);
            send(buff);
        }

        public void send(byte[] buff)
        {
            log("send b " + buff.Length);
            if (tc != null && tc.Connected)
            {
                //lock (stream = tc.GetStream())
                {
                    byte[] size = BitConverter.GetBytes(buff.Length);
                    log($"size {size.Length} {buff.Length}" );
                    //stream.Write(size, 0, size.Length);
                    stream.Write(buff, 0, buff.Length);
                    stream.Flush();
                    // stream.Close();
                }
            }
            else
            {
                log("send Connected not");
            }
        }
    }

    public class TcpServerBase : TcpBase
    {
        TcpListener listener;

        public TcpServerBase() : base()
        {
            runs += () =>
            {
                listener = new TcpListener(IPAddress.Any, 7000);
                listener.Start();
            };
            tcSet += () =>
             {
                 tc = listener.AcceptTcpClient();
                 stream = tc.GetStream();
             };
        }
    }

    public class TcpClientBase : TcpBase
    {
        public TcpClientBase() : base()
        {
            tcSet += () =>
            {
                while (tc==null || !tc.Connected)
                {
                    try
                    {
                        tc = new TcpClient("127.0.0.1", 7000);
                    }
                    catch (Exception e)
                    {
                        log($"tcSet e: {e.Message}");
                        Thread.Sleep(1000);
                    }

                }
                stream = tc.GetStream();
            };
        }
    }
}