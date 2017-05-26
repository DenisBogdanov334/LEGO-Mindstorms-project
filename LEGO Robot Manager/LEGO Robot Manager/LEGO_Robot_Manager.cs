using EV3MessengerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEGO_Robot_Manager
{
    public partial class LEGO_Robot_Manager : Form
    {
        // Fields
        private EV3Messenger messenger;
        bool isConnected = false;
        bool isControlled = false;
        bool isManaged = false;


        // Constructor
        public LEGO_Robot_Manager()
        {
            InitializeComponent();
            // Create messenger object
            messenger = new EV3Messenger();
            // Fill list with ports
            FillPortsList();
            UpdateFormGUI();
            this.KeyPreview = true;
        }

        // Methods
        #region Connect
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillPortsList();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Check if a port has been selected
            if (lstPorts.SelectedIndex > -1)
            {
                // Get the selected port from the ListBox
                string port = lstPorts.SelectedItem.ToString().ToUpper();
                // Try to connect with the Brick via the selected port
                if (messenger.Connect(port))
                {
                    isConnected = true;
                    UpdateFormGUI();
                }
                else
                {                    
                    MessageBox.Show("Failed to connect to serial port '" + port + "'.\n"
                        + "Make sure your robot is connected to that serial port and try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select a port for the bluetooth connection");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Disconnect from the Brick
            messenger.Disconnect();
            isConnected = false;
            UpdateFormGUI();
        }

        private void FillPortsList()
        {
            String[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);

            lstPorts.Items.Clear();
            foreach (String port in ports)
            {
                lstPorts.Items.Add(port);
            }
        }
        #endregion

        #region Manage

        private void btnStartManage_Click(object sender, EventArgs e)
        {
            isManaged = true;
            UpdateFormGUI();
        }

        private void btnStopManage_Click(object sender, EventArgs e)
        {
            isManaged = false;
            UpdateFormGUI();
        }

        #endregion

        #region Control

        private void btnStartControl_Click(object sender, EventArgs e)
        {
            isControlled = true;
            UpdateFormGUI();
            btnUp.Enabled = true;
            btnDown.Enabled = true;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            btnPickUp.Enabled = true;
            btnPutDown.Enabled = true;
        }

        private void btnStopControl_Click(object sender, EventArgs e)
        {
            isControlled = false;
            UpdateFormGUI();
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            btnPickUp.Enabled = false;
            btnPutDown.Enabled = false;
            messenger.SendMessage("MESSAGE", "Stop");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            messenger.SendMessage("MESSAGE", "Up");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            messenger.SendMessage("MESSAGE", "Left");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            messenger.SendMessage("MESSAGE", "Down");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            messenger.SendMessage("MESSAGE", "Right");
        }

        private void btnPickUp_Click(object sender, EventArgs e)
        {
            messenger.SendMessage("MESSAGE", "Pick up");
        }

        private void btnPutDown_Click(object sender, EventArgs e)
        {
            messenger.SendMessage("MESSAGE", "Put down");
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (isControlled)
            {
                switch(e.KeyCode)
                {
                    case Keys.W:
                        messenger.SendMessage("MESSAGE", "Up");
                        break;
                    case Keys.S:
                        messenger.SendMessage("MESSAGE", "Down");
                        break;
                    case Keys.A:
                        messenger.SendMessage("MESSAGE", "Left");
                        break;
                    case Keys.D:
                        messenger.SendMessage("MESSAGE", "Right");
                        break;
                    case Keys.Q:
                        messenger.SendMessage("MESSAGE", "Pick up");
                        break;
                    case Keys.E:
                        messenger.SendMessage("MESSAGE", "Put down");
                        break;
                    case Keys.Escape:
                        isControlled = false;
                        UpdateFormGUI();
                        btnUp.Enabled = false;
                        btnDown.Enabled = false;
                        btnLeft.Enabled = false;
                        btnRight.Enabled = false;
                        btnPickUp.Enabled = false;
                        btnPutDown.Enabled = false;
                        messenger.SendMessage("MESSAGE", "Stop");
                        break;
                }                
            }            
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (isControlled)
            {
                messenger.SendMessage("MESSAGE", "Stop");
            }
            
        }

        #endregion

        #region Update GUI
        private void UpdateFormGUI()
        {
            // Accessibility of the panels for all possible scenarios.
            if (!isConnected)
            {
                btnConnect.Enabled = true;
                btnRefresh.Enabled = true;
                btnDisconnect.Enabled = false;
                pnlManage.Enabled = false;
                pnlControl.Enabled = false;
            }
            else if (isConnected && isControlled)
            {
                pnlManage.Enabled = false;
            }
            else if (isConnected && isManaged)
            {
                pnlControl.Enabled = false;
            }
            else
            {
                btnConnect.Enabled = false;
                btnRefresh.Enabled = false;
                btnDisconnect.Enabled = true;
                pnlManage.Enabled = true;
                pnlControl.Enabled = true;
            }
        }

        #endregion


    }
}
