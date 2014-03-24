namespace ibex
{
    partial class Main
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
            this.btnDL = new System.Windows.Forms.Button();
            this.gvArchive = new System.Windows.Forms.DataGridView();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.querySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contype1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoFiber = new System.Windows.Forms.RadioButton();
            this.rdoCable = new System.Windows.Forms.RadioButton();
            this.rdoDSL = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenData = new System.Windows.Forms.Button();
            this.lblGenerate = new System.Windows.Forms.Label();
            this.txtGenerate = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.rdoUNR = new System.Windows.Forms.RadioButton();
            this.rdoAzure = new System.Windows.Forms.RadioButton();
            this.rdoEC2 = new System.Windows.Forms.RadioButton();
            this.btnLoadArchive = new System.Windows.Forms.Button();
            this.btnClearArhive = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtStep = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkMod = new System.Windows.Forms.CheckBox();
            this.rdoCurve = new System.Windows.Forms.RadioButton();
            this.rdoTPC = new System.Windows.Forms.RadioButton();
            this.rdoEqualSize = new System.Windows.Forms.RadioButton();
            this.btnOverheadForm = new System.Windows.Forms.Button();
            this.txtMod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvArchive)).BeginInit();
            this.grpConnection.SuspendLayout();
            this.grpServer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDL
            // 
            this.btnDL.Location = new System.Drawing.Point(22, 120);
            this.btnDL.Name = "btnDL";
            this.btnDL.Size = new System.Drawing.Size(78, 22);
            this.btnDL.TabIndex = 1;
            this.btnDL.Text = "Download Data";
            this.btnDL.UseVisualStyleBackColor = true;
            this.btnDL.Click += new System.EventHandler(this.btnDL_Click);
            // 
            // gvArchive
            // 
            this.gvArchive.AllowUserToAddRows = false;
            this.gvArchive.AllowUserToDeleteRows = false;
            this.gvArchive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvArchive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.startTime,
            this.endTime,
            this.seconds,
            this.querySize,
            this.numRows,
            this.serv,
            this.contype1,
            this.updown});
            this.gvArchive.Location = new System.Drawing.Point(9, 175);
            this.gvArchive.Name = "gvArchive";
            this.gvArchive.ReadOnly = true;
            this.gvArchive.Size = new System.Drawing.Size(790, 325);
            this.gvArchive.TabIndex = 4;
            // 
            // startTime
            // 
            this.startTime.DataPropertyName = "startTime";
            this.startTime.HeaderText = "startTime";
            this.startTime.Name = "startTime";
            this.startTime.ReadOnly = true;
            // 
            // endTime
            // 
            this.endTime.DataPropertyName = "endTime";
            this.endTime.HeaderText = "endTime";
            this.endTime.Name = "endTime";
            this.endTime.ReadOnly = true;
            // 
            // seconds
            // 
            this.seconds.DataPropertyName = "seconds";
            this.seconds.HeaderText = "seconds";
            this.seconds.Name = "seconds";
            this.seconds.ReadOnly = true;
            // 
            // querySize
            // 
            this.querySize.DataPropertyName = "querySize";
            this.querySize.HeaderText = "querySize";
            this.querySize.Name = "querySize";
            this.querySize.ReadOnly = true;
            // 
            // numRows
            // 
            this.numRows.DataPropertyName = "numRows";
            this.numRows.HeaderText = "numRows";
            this.numRows.Name = "numRows";
            this.numRows.ReadOnly = true;
            // 
            // serv
            // 
            this.serv.DataPropertyName = "serv";
            this.serv.HeaderText = "serv";
            this.serv.Name = "serv";
            this.serv.ReadOnly = true;
            // 
            // contype1
            // 
            this.contype1.DataPropertyName = "contype";
            this.contype1.HeaderText = "contype";
            this.contype1.Name = "contype1";
            this.contype1.ReadOnly = true;
            // 
            // updown
            // 
            this.updown.DataPropertyName = "updown";
            this.updown.HeaderText = "updown";
            this.updown.Name = "updown";
            this.updown.ReadOnly = true;
            // 
            // rdoFiber
            // 
            this.rdoFiber.AutoSize = true;
            this.rdoFiber.Checked = true;
            this.rdoFiber.Location = new System.Drawing.Point(14, 19);
            this.rdoFiber.Name = "rdoFiber";
            this.rdoFiber.Size = new System.Drawing.Size(48, 17);
            this.rdoFiber.TabIndex = 7;
            this.rdoFiber.TabStop = true;
            this.rdoFiber.Text = "Fiber";
            this.rdoFiber.UseVisualStyleBackColor = true;
            // 
            // rdoCable
            // 
            this.rdoCable.AutoSize = true;
            this.rdoCable.Location = new System.Drawing.Point(14, 42);
            this.rdoCable.Name = "rdoCable";
            this.rdoCable.Size = new System.Drawing.Size(52, 17);
            this.rdoCable.TabIndex = 7;
            this.rdoCable.Text = "Cable";
            this.rdoCable.UseVisualStyleBackColor = true;
            // 
            // rdoDSL
            // 
            this.rdoDSL.AutoSize = true;
            this.rdoDSL.Location = new System.Drawing.Point(14, 65);
            this.rdoDSL.Name = "rdoDSL";
            this.rdoDSL.Size = new System.Drawing.Size(46, 17);
            this.rdoDSL.TabIndex = 7;
            this.rdoDSL.Text = "DSL";
            this.rdoDSL.UseVisualStyleBackColor = true;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(15, 88);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(51, 17);
            this.rdoOther.TabIndex = 7;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(65, 87);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(100, 20);
            this.txtOther.TabIndex = 8;
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.rdoFiber);
            this.grpConnection.Controls.Add(this.txtOther);
            this.grpConnection.Controls.Add(this.rdoCable);
            this.grpConnection.Controls.Add(this.rdoOther);
            this.grpConnection.Controls.Add(this.rdoDSL);
            this.grpConnection.Location = new System.Drawing.Point(12, 12);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(180, 127);
            this.grpConnection.TabIndex = 9;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Type of Connection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data Archive";
            // 
            // btnGenData
            // 
            this.btnGenData.Enabled = false;
            this.btnGenData.Location = new System.Drawing.Point(20, 46);
            this.btnGenData.Name = "btnGenData";
            this.btnGenData.Size = new System.Drawing.Size(75, 48);
            this.btnGenData.TabIndex = 12;
            this.btnGenData.Text = "Generate Data";
            this.btnGenData.UseVisualStyleBackColor = true;
            this.btnGenData.Click += new System.EventHandler(this.btnGenData_Click);
            // 
            // lblGenerate
            // 
            this.lblGenerate.AutoSize = true;
            this.lblGenerate.Location = new System.Drawing.Point(692, 135);
            this.lblGenerate.Name = "lblGenerate";
            this.lblGenerate.Size = new System.Drawing.Size(22, 13);
            this.lblGenerate.TabIndex = 13;
            this.lblGenerate.Text = "     ";
            // 
            // txtGenerate
            // 
            this.txtGenerate.Enabled = false;
            this.txtGenerate.Location = new System.Drawing.Point(20, 19);
            this.txtGenerate.Name = "txtGenerate";
            this.txtGenerate.Size = new System.Drawing.Size(75, 20);
            this.txtGenerate.TabIndex = 14;
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(101, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear Data";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpServer
            // 
            this.grpServer.Controls.Add(this.btnTestConn);
            this.grpServer.Controls.Add(this.rdoUNR);
            this.grpServer.Controls.Add(this.rdoAzure);
            this.grpServer.Controls.Add(this.rdoEC2);
            this.grpServer.Location = new System.Drawing.Point(198, 12);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(124, 127);
            this.grpServer.TabIndex = 16;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "Server";
            // 
            // btnTestConn
            // 
            this.btnTestConn.Location = new System.Drawing.Point(14, 88);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(101, 23);
            this.btnTestConn.TabIndex = 24;
            this.btnTestConn.Text = "Test Connection";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // rdoUNR
            // 
            this.rdoUNR.AutoSize = true;
            this.rdoUNR.Checked = true;
            this.rdoUNR.Location = new System.Drawing.Point(14, 19);
            this.rdoUNR.Name = "rdoUNR";
            this.rdoUNR.Size = new System.Drawing.Size(49, 17);
            this.rdoUNR.TabIndex = 7;
            this.rdoUNR.TabStop = true;
            this.rdoUNR.Text = "UNR";
            this.rdoUNR.UseVisualStyleBackColor = true;
            // 
            // rdoAzure
            // 
            this.rdoAzure.AutoSize = true;
            this.rdoAzure.Location = new System.Drawing.Point(14, 42);
            this.rdoAzure.Name = "rdoAzure";
            this.rdoAzure.Size = new System.Drawing.Size(52, 17);
            this.rdoAzure.TabIndex = 7;
            this.rdoAzure.Text = "Azure";
            this.rdoAzure.UseVisualStyleBackColor = true;
            // 
            // rdoEC2
            // 
            this.rdoEC2.AutoSize = true;
            this.rdoEC2.Enabled = false;
            this.rdoEC2.Location = new System.Drawing.Point(14, 65);
            this.rdoEC2.Name = "rdoEC2";
            this.rdoEC2.Size = new System.Drawing.Size(45, 17);
            this.rdoEC2.TabIndex = 7;
            this.rdoEC2.Text = "EC2";
            this.rdoEC2.UseVisualStyleBackColor = true;
            // 
            // btnLoadArchive
            // 
            this.btnLoadArchive.Location = new System.Drawing.Point(805, 301);
            this.btnLoadArchive.Name = "btnLoadArchive";
            this.btnLoadArchive.Size = new System.Drawing.Size(110, 23);
            this.btnLoadArchive.TabIndex = 17;
            this.btnLoadArchive.Text = "Load Archive";
            this.btnLoadArchive.UseVisualStyleBackColor = true;
            this.btnLoadArchive.Click += new System.EventHandler(this.btnLoadArchive_Click);
            // 
            // btnClearArhive
            // 
            this.btnClearArhive.Location = new System.Drawing.Point(805, 330);
            this.btnClearArhive.Name = "btnClearArhive";
            this.btnClearArhive.Size = new System.Drawing.Size(110, 23);
            this.btnClearArhive.TabIndex = 18;
            this.btnClearArhive.Text = "Clear Archive";
            this.btnClearArhive.UseVisualStyleBackColor = true;
            this.btnClearArhive.Click += new System.EventHandler(this.btnClearArhive_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnGenData);
            this.groupBox1.Controls.Add(this.txtGenerate);
            this.groupBox1.Location = new System.Drawing.Point(651, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "dlDB Management";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(106, 120);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(68, 22);
            this.btnUpload.TabIndex = 22;
            this.btnUpload.Text = "Upload Data";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMod);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtStep);
            this.groupBox2.Controls.Add(this.txtEnd);
            this.groupBox2.Controls.Add(this.txtStart);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.btnDL);
            this.groupBox2.Location = new System.Drawing.Point(465, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 157);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Parameters";
            // 
            // txtStep
            // 
            this.txtStep.Location = new System.Drawing.Point(80, 68);
            this.txtStep.Name = "txtStep";
            this.txtStep.Size = new System.Drawing.Size(94, 20);
            this.txtStep.TabIndex = 28;
            this.txtStep.Text = "100";
            this.txtStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(80, 43);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(94, 20);
            this.txtEnd.TabIndex = 27;
            this.txtEnd.Text = "1000";
            this.txtEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(80, 16);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(94, 20);
            this.txtStart.TabIndex = 26;
            this.txtStart.Text = "100";
            this.txtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Step";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "End";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Start";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkMod);
            this.groupBox3.Controls.Add(this.rdoCurve);
            this.groupBox3.Controls.Add(this.rdoTPC);
            this.groupBox3.Controls.Add(this.rdoEqualSize);
            this.groupBox3.Location = new System.Drawing.Point(328, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 107);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test Type";
            // 
            // chkMod
            // 
            this.chkMod.AutoSize = true;
            this.chkMod.Location = new System.Drawing.Point(7, 83);
            this.chkMod.Name = "chkMod";
            this.chkMod.Size = new System.Drawing.Size(66, 17);
            this.chkMod.TabIndex = 2;
            this.chkMod.Text = "Modified";
            this.chkMod.UseVisualStyleBackColor = true;
            // 
            // rdoCurve
            // 
            this.rdoCurve.AutoSize = true;
            this.rdoCurve.Location = new System.Drawing.Point(7, 60);
            this.rdoCurve.Name = "rdoCurve";
            this.rdoCurve.Size = new System.Drawing.Size(53, 17);
            this.rdoCurve.TabIndex = 0;
            this.rdoCurve.TabStop = true;
            this.rdoCurve.Text = "Curve";
            this.rdoCurve.UseVisualStyleBackColor = true;
            // 
            // rdoTPC
            // 
            this.rdoTPC.AutoSize = true;
            this.rdoTPC.Location = new System.Drawing.Point(7, 37);
            this.rdoTPC.Name = "rdoTPC";
            this.rdoTPC.Size = new System.Drawing.Size(46, 17);
            this.rdoTPC.TabIndex = 0;
            this.rdoTPC.TabStop = true;
            this.rdoTPC.Text = "TPC";
            this.rdoTPC.UseVisualStyleBackColor = true;
            // 
            // rdoEqualSize
            // 
            this.rdoEqualSize.AutoSize = true;
            this.rdoEqualSize.Location = new System.Drawing.Point(7, 14);
            this.rdoEqualSize.Name = "rdoEqualSize";
            this.rdoEqualSize.Size = new System.Drawing.Size(75, 17);
            this.rdoEqualSize.TabIndex = 0;
            this.rdoEqualSize.TabStop = true;
            this.rdoEqualSize.Text = "Equal Size";
            this.rdoEqualSize.UseVisualStyleBackColor = true;
            // 
            // btnOverheadForm
            // 
            this.btnOverheadForm.Location = new System.Drawing.Point(857, 23);
            this.btnOverheadForm.Name = "btnOverheadForm";
            this.btnOverheadForm.Size = new System.Drawing.Size(75, 48);
            this.btnOverheadForm.TabIndex = 25;
            this.btnOverheadForm.Text = "Overhead";
            this.btnOverheadForm.UseVisualStyleBackColor = true;
            this.btnOverheadForm.Click += new System.EventHandler(this.btnOverheadForm_Click);
            // 
            // txtMod
            // 
            this.txtMod.Location = new System.Drawing.Point(80, 94);
            this.txtMod.Name = "txtMod";
            this.txtMod.Size = new System.Drawing.Size(94, 20);
            this.txtMod.TabIndex = 30;
            this.txtMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Mod";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 512);
            this.Controls.Add(this.btnOverheadForm);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClearArhive);
            this.Controls.Add(this.btnLoadArchive);
            this.Controls.Add(this.grpServer);
            this.Controls.Add(this.lblGenerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpConnection);
            this.Controls.Add(this.gvArchive);
            this.Name = "Main";
            this.Text = "Internet Bandwidth Explorer";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvArchive)).EndInit();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDL;
        private System.Windows.Forms.DataGridView gvArchive;
        private System.Windows.Forms.RadioButton rdoFiber;
        private System.Windows.Forms.RadioButton rdoCable;
        private System.Windows.Forms.RadioButton rdoDSL;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenData;
        private System.Windows.Forms.Label lblGenerate;
        private System.Windows.Forms.TextBox txtGenerate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpServer;
        private System.Windows.Forms.RadioButton rdoUNR;
        private System.Windows.Forms.RadioButton rdoAzure;
        private System.Windows.Forms.RadioButton rdoEC2;
        private System.Windows.Forms.Button btnLoadArchive;
        private System.Windows.Forms.Button btnClearArhive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtStep;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoCurve;
        private System.Windows.Forms.RadioButton rdoTPC;
        private System.Windows.Forms.RadioButton rdoEqualSize;
        private System.Windows.Forms.Button btnOverheadForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn seconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn querySize;
        private System.Windows.Forms.DataGridViewTextBoxColumn numRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn serv;
        private System.Windows.Forms.DataGridViewTextBoxColumn contype1;
        private System.Windows.Forms.DataGridViewTextBoxColumn updown;
        private System.Windows.Forms.CheckBox chkMod;
        private System.Windows.Forms.TextBox txtMod;
        private System.Windows.Forms.Label label1;
    }
}

