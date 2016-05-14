using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClientServer
{
    public enum EServerConnectionState
    {
        Undefined = 0,
        Attempting,
        Connected,
        Disconnected
    }

    public partial class ServerForm : Form
    {
        #region Declaration
        const string contStateLog = "STATE";
        const string contServerLog = "SERVER";

        IPAddress mIP = new IPAddress(new byte[] { 127, 0, 0, 1 });
        int mPort = 9090;
        EServerConnectionState mState = EServerConnectionState.Undefined;
        TCPServer mServer = null;
        #endregion

        #region Constructor
        public ServerForm()
        {
            InitializeComponent();
            mTxtIP.Text = mIP.ToString();
            mTxtPort.Text = mPort.ToString();
        }
        #endregion

        #region Properties
        public EServerConnectionState ConnectionState
        {
            get { return mState; }
            set { mState = value; mLabelConnectionState.Text = mState.ToString(); }
        }
        #endregion

        #region Private Member
        private void LogMessage(DateTime time, string sender, string msg)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell dateCell = new DataGridViewTextBoxCell();
            dateCell.Value = time.ToString();
            row.Cells.Add(dateCell);
            DataGridViewTextBoxCell senderCell = new DataGridViewTextBoxCell();
            senderCell.Value = sender;
            row.Cells.Add(senderCell);
            DataGridViewTextBoxCell msgCell = new DataGridViewTextBoxCell();
            msgCell.Value = msg;
            row.Cells.Add(msgCell);
            if(sender == contStateLog)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Style.ForeColor = Color.Gray;
            }
            else if (sender == contServerLog)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Style.ForeColor = Color.DarkSlateBlue;
            }
            mDgvLog.Rows.Add(row);
        }

        private void Connect()
        {
            if (mServer != null)
                Disconnect();
            LogMessage(DateTime.Now, contStateLog, "Creating server connection");
            mServer = new TCPServer(mIP, mPort);
            mServer.ConnectionStateChanged += MServer_ConnectionStateChanged;
            mServer.MessageReceived += MServer_MessageReceived;
            LogMessage(DateTime.Now, contStateLog, "Attempting to connect");
            mServer.Connect();
        }

        private void Disconnect()
        {
            if (mServer == null)
                return;
            LogMessage(DateTime.Now, contStateLog, "Disposing server connection");
            mServer.Dispose();
            mServer.ConnectionStateChanged -= MServer_ConnectionStateChanged;
            mServer.MessageReceived -= MServer_MessageReceived;
            mServer = null;
        }

        private void Send(string msg)
        {
            if (mServer == null)
                return;
            mServer.Send(msg);
            LogMessage(DateTime.Now, contServerLog, msg);
        }
        #endregion

        #region Form Events
        private void mTxtIP_TextChanged(object sender, EventArgs e)
        {
            string ipText = mTxtIP.Text;
            if (ipText.ToLower() == "localhost")
                ipText = "127.0.0.1";
            IPAddress ipObj;
            if (IPAddress.TryParse(ipText, out ipObj))
            {
                mTxtIP.ForeColor = SystemColors.ControlText;
                mIP = ipObj;
            }
            else
                mTxtIP.ForeColor = Color.Red;
        }

        private void mTxtPort_TextChanged(object sender, EventArgs e)
        {
            int port;
            if(int.TryParse(mTxtPort.Text, out port) && port < 10E9)
            {
                mTxtPort.ForeColor = SystemColors.ControlText;
                mPort = port;
            }
            else
                mTxtPort.ForeColor = Color.Red;
        }

        private void mBtnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void mBtnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void mBtnSend_Click(object sender, EventArgs e)
        {
            string msg = mTxtMsg.Text;
            if (string.IsNullOrWhiteSpace(msg))
                return;
            Send(msg);
            mTxtMsg.Clear();
        }
        #endregion

        #region Server Events
        private void MServer_ConnectionStateChanged(EServerConnectionState oldState, EServerConnectionState newState)
        {
            if(InvokeRequired)
            {
                Invoke(new TCPServer.ConnectionStateChangedHandler(MServer_ConnectionStateChanged), new object[] { oldState, newState });
                return;
            }
            ConnectionState = newState;
            LogMessage(DateTime.Now, contStateLog, "Connection state changed to " + newState.ToString() + " from " + oldState.ToString());
        }

        private void MServer_MessageReceived(DateTime time, string sender, string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new TCPServer.MessageReceivedHandler(MServer_MessageReceived), new object[] { time, sender, msg });
                return;
            }
            LogMessage(time, sender, msg);
        }
        #endregion
    }
}
