namespace TCPClientServer
{
    partial class ServerForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.mTxtPort = new System.Windows.Forms.TextBox();
            this.mTxtIP = new System.Windows.Forms.TextBox();
            this.mLabelConnectionState = new System.Windows.Forms.Label();
            this.mBtnConnect = new System.Windows.Forms.Button();
            this.mBtnDisconnect = new System.Windows.Forms.Button();
            this.mBtnSend = new System.Windows.Forms.Button();
            this.mTxtMsg = new System.Windows.Forms.TextBox();
            this.mDgvLog = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mDgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // mTxtPort
            // 
            this.mTxtPort.Location = new System.Drawing.Point(731, 14);
            this.mTxtPort.Name = "mTxtPort";
            this.mTxtPort.Size = new System.Drawing.Size(50, 20);
            this.mTxtPort.TabIndex = 15;
            this.mTxtPort.Text = "9999";
            this.mTxtPort.TextChanged += new System.EventHandler(this.mTxtPort_TextChanged);
            // 
            // mTxtIP
            // 
            this.mTxtIP.Location = new System.Drawing.Point(625, 14);
            this.mTxtIP.Name = "mTxtIP";
            this.mTxtIP.Size = new System.Drawing.Size(100, 20);
            this.mTxtIP.TabIndex = 14;
            this.mTxtIP.Text = "127.0.0.1";
            this.mTxtIP.TextChanged += new System.EventHandler(this.mTxtIP_TextChanged);
            // 
            // mLabelConnectionState
            // 
            this.mLabelConnectionState.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mLabelConnectionState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mLabelConnectionState.Location = new System.Drawing.Point(171, 12);
            this.mLabelConnectionState.Name = "mLabelConnectionState";
            this.mLabelConnectionState.Size = new System.Drawing.Size(107, 23);
            this.mLabelConnectionState.TabIndex = 8;
            this.mLabelConnectionState.Text = "Unknown";
            this.mLabelConnectionState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mBtnConnect
            // 
            this.mBtnConnect.Location = new System.Drawing.Point(12, 12);
            this.mBtnConnect.Name = "mBtnConnect";
            this.mBtnConnect.Size = new System.Drawing.Size(72, 23);
            this.mBtnConnect.TabIndex = 9;
            this.mBtnConnect.Text = "Connect";
            this.mBtnConnect.UseVisualStyleBackColor = true;
            this.mBtnConnect.Click += new System.EventHandler(this.mBtnConnect_Click);
            // 
            // mBtnDisconnect
            // 
            this.mBtnDisconnect.Location = new System.Drawing.Point(90, 12);
            this.mBtnDisconnect.Name = "mBtnDisconnect";
            this.mBtnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.mBtnDisconnect.TabIndex = 10;
            this.mBtnDisconnect.Text = "Disconnect";
            this.mBtnDisconnect.UseVisualStyleBackColor = true;
            this.mBtnDisconnect.Click += new System.EventHandler(this.mBtnDisconnect_Click);
            // 
            // mBtnSend
            // 
            this.mBtnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mBtnSend.Location = new System.Drawing.Point(706, 455);
            this.mBtnSend.Name = "mBtnSend";
            this.mBtnSend.Size = new System.Drawing.Size(75, 23);
            this.mBtnSend.TabIndex = 13;
            this.mBtnSend.Text = "Send";
            this.mBtnSend.UseVisualStyleBackColor = true;
            this.mBtnSend.Click += new System.EventHandler(this.mBtnSend_Click);
            // 
            // mTxtMsg
            // 
            this.mTxtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTxtMsg.Location = new System.Drawing.Point(12, 457);
            this.mTxtMsg.Name = "mTxtMsg";
            this.mTxtMsg.Size = new System.Drawing.Size(688, 20);
            this.mTxtMsg.TabIndex = 12;
            // 
            // mDgvLog
            // 
            this.mDgvLog.AllowUserToAddRows = false;
            this.mDgvLog.AllowUserToDeleteRows = false;
            this.mDgvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mDgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mDgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colSender,
            this.colMsg});
            this.mDgvLog.Location = new System.Drawing.Point(12, 41);
            this.mDgvLog.Name = "mDgvLog";
            this.mDgvLog.RowHeadersVisible = false;
            this.mDgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mDgvLog.Size = new System.Drawing.Size(769, 410);
            this.mDgvLog.TabIndex = 16;
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTime.HeaderText = "Timestamp";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 83;
            // 
            // colSender
            // 
            this.colSender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSender.HeaderText = "Sender";
            this.colSender.Name = "colSender";
            this.colSender.ReadOnly = true;
            this.colSender.Width = 66;
            // 
            // colMsg
            // 
            this.colMsg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMsg.HeaderText = "Message";
            this.colMsg.Name = "colMsg";
            this.colMsg.ReadOnly = true;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 490);
            this.Controls.Add(this.mDgvLog);
            this.Controls.Add(this.mTxtPort);
            this.Controls.Add(this.mTxtIP);
            this.Controls.Add(this.mLabelConnectionState);
            this.Controls.Add(this.mBtnConnect);
            this.Controls.Add(this.mBtnDisconnect);
            this.Controls.Add(this.mBtnSend);
            this.Controls.Add(this.mTxtMsg);
            this.Name = "ServerForm";
            this.Text = "TCP Server";
            ((System.ComponentModel.ISupportInitialize)(this.mDgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mTxtPort;
        private System.Windows.Forms.TextBox mTxtIP;
        private System.Windows.Forms.Label mLabelConnectionState;
        private System.Windows.Forms.Button mBtnConnect;
        private System.Windows.Forms.Button mBtnDisconnect;
        private System.Windows.Forms.Button mBtnSend;
        private System.Windows.Forms.TextBox mTxtMsg;
        private System.Windows.Forms.DataGridView mDgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsg;
    }
}

