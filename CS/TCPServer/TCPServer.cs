using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPClientServer
{
    public class TCPServer : IDisposable
    {
        #region Declaration
        EServerConnectionState mConnectionState = EServerConnectionState.Undefined;
        TcpListener mTcp = null;
        BackgroundWorker mWorker = null;
        #endregion

        #region Constructor
        public TCPServer()
            : this(IPAddress.Any, 0)
        { }

        public TCPServer(string ip, int port)
            : this(IPAddress.Parse(ip), port)
        { }

        public TCPServer(IPAddress ip, int port)
        {
            IP = ip;
            Port = port;
        }
        #endregion

        #region Properties
        public IPAddress IP { get; private set; }
        public int Port { get; private set; }
        #endregion

        #region Private Member
        #endregion

        #region Public Member
        public void Connect()
        {
            if (ConnectionState != EServerConnectionState.Disconnected && ConnectionState != EServerConnectionState.Undefined)
                Disconnect();
            ConnectionState = EServerConnectionState.Attempting;
            if (mWorker == null)
                mWorker = new BackgroundWorker();
            mWorker.WorkerSupportsCancellation = true;

            if (mTcp == null)
                mTcp = new TcpListener(IP, Port);
            mTcp.Start();

            mWorker.DoWork += M_objWorker_DoWork;
            mWorker.RunWorkerAsync();

            ConnectionState = EServerConnectionState.Connected;
        }

        private void M_objWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (mTcp != null)
                {
                    Console.Write("Waiting for a connection... ");
                    
                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = mTcp.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        if (MessageReceived != null)
                            MessageReceived(DateTime.Now, "Client", data);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException ex)
            {
                if (MessageReceived != null)
                    MessageReceived(DateTime.Now, ex.Source, string.Format("SocketException: {0}", ex));
                Console.WriteLine("SocketException: {0}", ex);
            }
            catch(Exception ex)
            {
                if (MessageReceived != null)
                    MessageReceived(DateTime.Now, ex.Source, string.Format("Exception: {0}", ex));
                Console.WriteLine("Exception: {0}", ex);
            }
        }
        
        public void Disconnect()
        {
            if (mWorker != null)
            {
                mWorker.CancelAsync();
                mWorker.Dispose();
            }
            mWorker = null;
            if (mTcp != null)
                mTcp.Stop();
            mTcp = null;
            ConnectionState = EServerConnectionState.Disconnected;
        }

        public bool Send(string msg)
        {
            return true;
        }
        #endregion

        #region Events
        public delegate void ConnectionStateChangedHandler(EServerConnectionState oldState, EServerConnectionState newState);
        public event ConnectionStateChangedHandler ConnectionStateChanged;
        private EServerConnectionState ConnectionState
        {
            get { return mConnectionState; }
            set
            {
                if (ConnectionStateChanged != null)
                    ConnectionStateChanged(mConnectionState, value);
                mConnectionState = value;
            }
        }

        public delegate void MessageReceivedHandler(DateTime time, string sender, string msg);
        public event MessageReceivedHandler MessageReceived;
        #endregion

        #region IDisposable
        bool mIsDisposed = false;
        public bool IsDisposed { get { return mIsDisposed; } }
        public void Dispose()
        {
            if (mIsDisposed)
                return;
            Disconnect();
            mIsDisposed = false;
        }
        #endregion
    }
}
