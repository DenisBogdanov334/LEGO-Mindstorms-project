namespace LEGO_Robot_Manager
{
    partial class LEGO_Robot_Manager
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
            this.components = new System.ComponentModel.Container();
            this.pnlConnect = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lstPorts = new System.Windows.Forms.ListBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlManage = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStopManage = new System.Windows.Forms.Button();
            this.btnStartManage = new System.Windows.Forms.Button();
            this.lblConnect = new System.Windows.Forms.Label();
            this.lblManage = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnPutDown = new System.Windows.Forms.Button();
            this.btnPickUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnStopControl = new System.Windows.Forms.Button();
            this.btnStartControl = new System.Windows.Forms.Button();
            this.lblControl = new System.Windows.Forms.Label();
            this.btnManagePauseContinue = new System.Windows.Forms.Button();
            this.elapsedTime = new System.Windows.Forms.Timer(this.components);
            this.pnlConnect.SuspendLayout();
            this.pnlManage.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConnect
            // 
            this.pnlConnect.BackColor = System.Drawing.Color.LightGray;
            this.pnlConnect.Controls.Add(this.btnConnect);
            this.pnlConnect.Controls.Add(this.lstPorts);
            this.pnlConnect.Controls.Add(this.btnDisconnect);
            this.pnlConnect.Controls.Add(this.btnRefresh);
            this.pnlConnect.Location = new System.Drawing.Point(25, 49);
            this.pnlConnect.Name = "pnlConnect";
            this.pnlConnect.Size = new System.Drawing.Size(225, 130);
            this.pnlConnect.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(120, 50);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 30);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lstPorts
            // 
            this.lstPorts.FormattingEnabled = true;
            this.lstPorts.ItemHeight = 16;
            this.lstPorts.Location = new System.Drawing.Point(15, 15);
            this.lstPorts.Name = "lstPorts";
            this.lstPorts.Size = new System.Drawing.Size(87, 100);
            this.lstPorts.TabIndex = 0;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(120, 85);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(90, 30);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(120, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlManage
            // 
            this.pnlManage.BackColor = System.Drawing.Color.LightGray;
            this.pnlManage.Controls.Add(this.btnManagePauseContinue);
            this.pnlManage.Controls.Add(this.txtStatus);
            this.pnlManage.Controls.Add(this.lblStatus);
            this.pnlManage.Controls.Add(this.btnStopManage);
            this.pnlManage.Controls.Add(this.btnStartManage);
            this.pnlManage.Location = new System.Drawing.Point(268, 49);
            this.pnlManage.Name = "pnlManage";
            this.pnlManage.Size = new System.Drawing.Size(312, 130);
            this.pnlManage.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(77, 89);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(220, 22);
            this.txtStatus.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(19, 92);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            // 
            // btnStopManage
            // 
            this.btnStopManage.BackColor = System.Drawing.Color.Red;
            this.btnStopManage.Location = new System.Drawing.Point(111, 15);
            this.btnStopManage.Name = "btnStopManage";
            this.btnStopManage.Size = new System.Drawing.Size(90, 60);
            this.btnStopManage.TabIndex = 1;
            this.btnStopManage.Text = "STOP";
            this.btnStopManage.UseVisualStyleBackColor = false;
            this.btnStopManage.Click += new System.EventHandler(this.btnStopManage_Click);
            // 
            // btnStartManage
            // 
            this.btnStartManage.BackColor = System.Drawing.Color.Lime;
            this.btnStartManage.Location = new System.Drawing.Point(15, 15);
            this.btnStartManage.Name = "btnStartManage";
            this.btnStartManage.Size = new System.Drawing.Size(90, 60);
            this.btnStartManage.TabIndex = 0;
            this.btnStartManage.Text = "START";
            this.btnStartManage.UseVisualStyleBackColor = false;
            this.btnStartManage.Click += new System.EventHandler(this.btnStartManage_Click);
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Location = new System.Drawing.Point(35, 28);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(60, 17);
            this.lblConnect.TabIndex = 2;
            this.lblConnect.Text = "Connect";
            // 
            // lblManage
            // 
            this.lblManage.AutoSize = true;
            this.lblManage.Location = new System.Drawing.Point(278, 28);
            this.lblManage.Name = "lblManage";
            this.lblManage.Size = new System.Drawing.Size(59, 17);
            this.lblManage.TabIndex = 3;
            this.lblManage.Text = "Manage";
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.LightGray;
            this.pnlControl.Controls.Add(this.btnPutDown);
            this.pnlControl.Controls.Add(this.btnPickUp);
            this.pnlControl.Controls.Add(this.btnDown);
            this.pnlControl.Controls.Add(this.btnRight);
            this.pnlControl.Controls.Add(this.btnLeft);
            this.pnlControl.Controls.Add(this.btnUp);
            this.pnlControl.Controls.Add(this.btnStopControl);
            this.pnlControl.Controls.Add(this.btnStartControl);
            this.pnlControl.Location = new System.Drawing.Point(25, 232);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(555, 156);
            this.pnlControl.TabIndex = 4;
            // 
            // btnPutDown
            // 
            this.btnPutDown.Enabled = false;
            this.btnPutDown.Location = new System.Drawing.Point(465, 86);
            this.btnPutDown.Name = "btnPutDown";
            this.btnPutDown.Size = new System.Drawing.Size(75, 50);
            this.btnPutDown.TabIndex = 7;
            this.btnPutDown.Text = "PUT DOWN";
            this.btnPutDown.UseVisualStyleBackColor = true;
            this.btnPutDown.Click += new System.EventHandler(this.btnPutDown_Click);
            // 
            // btnPickUp
            // 
            this.btnPickUp.Enabled = false;
            this.btnPickUp.Location = new System.Drawing.Point(465, 25);
            this.btnPickUp.Name = "btnPickUp";
            this.btnPickUp.Size = new System.Drawing.Size(75, 50);
            this.btnPickUp.TabIndex = 6;
            this.btnPickUp.Text = "PICK UP";
            this.btnPickUp.UseVisualStyleBackColor = true;
            this.btnPickUp.Click += new System.EventHandler(this.btnPickUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(248, 86);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(70, 50);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.Enabled = false;
            this.btnRight.Location = new System.Drawing.Point(324, 86);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(70, 50);
            this.btnRight.TabIndex = 4;
            this.btnRight.Text = "RIGHT";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Enabled = false;
            this.btnLeft.Location = new System.Drawing.Point(172, 86);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(70, 50);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "LEFT";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(248, 30);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(70, 50);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnStopControl
            // 
            this.btnStopControl.BackColor = System.Drawing.Color.Red;
            this.btnStopControl.Location = new System.Drawing.Point(13, 81);
            this.btnStopControl.Name = "btnStopControl";
            this.btnStopControl.Size = new System.Drawing.Size(90, 60);
            this.btnStopControl.TabIndex = 1;
            this.btnStopControl.Text = "STOP";
            this.btnStopControl.UseVisualStyleBackColor = false;
            this.btnStopControl.Click += new System.EventHandler(this.btnStopControl_Click);
            // 
            // btnStartControl
            // 
            this.btnStartControl.BackColor = System.Drawing.Color.Lime;
            this.btnStartControl.Location = new System.Drawing.Point(15, 15);
            this.btnStartControl.Name = "btnStartControl";
            this.btnStartControl.Size = new System.Drawing.Size(90, 60);
            this.btnStartControl.TabIndex = 0;
            this.btnStartControl.Text = "START";
            this.btnStartControl.UseVisualStyleBackColor = false;
            this.btnStartControl.Click += new System.EventHandler(this.btnStartControl_Click);
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Location = new System.Drawing.Point(35, 212);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(53, 17);
            this.lblControl.TabIndex = 5;
            this.lblControl.Text = "Control";
            // 
            // btnManagePauseContinue
            // 
            this.btnManagePauseContinue.BackColor = System.Drawing.Color.OrangeRed;
            this.btnManagePauseContinue.Location = new System.Drawing.Point(207, 15);
            this.btnManagePauseContinue.Name = "btnManagePauseContinue";
            this.btnManagePauseContinue.Size = new System.Drawing.Size(90, 60);
            this.btnManagePauseContinue.TabIndex = 6;
            this.btnManagePauseContinue.Text = "PAUSE CONTINUE";
            this.btnManagePauseContinue.UseVisualStyleBackColor = false;
            this.btnManagePauseContinue.Click += new System.EventHandler(this.btnManagePauseContinue_Click);
            // 
            // LEGO_Robot_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 414);
            this.Controls.Add(this.lblControl);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.lblManage);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.pnlManage);
            this.Controls.Add(this.pnlConnect);
            this.Name = "LEGO_Robot_Manager";
            this.Text = "LEGO Robot Manager";
            this.pnlConnect.ResumeLayout(false);
            this.pnlManage.ResumeLayout(false);
            this.pnlManage.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lstPorts;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlManage;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStopManage;
        private System.Windows.Forms.Button btnStartManage;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Label lblManage;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.Button btnStopControl;
        private System.Windows.Forms.Button btnStartControl;
        private System.Windows.Forms.Button btnPutDown;
        private System.Windows.Forms.Button btnPickUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnManagePauseContinue;
        private System.Windows.Forms.Timer elapsedTime;
    }
}

