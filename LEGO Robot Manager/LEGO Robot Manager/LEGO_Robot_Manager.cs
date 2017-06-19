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
using System.Diagnostics;
using System.IO;

namespace LEGO_Robot_Manager
{
    public partial class LEGO_Robot_Manager : Form
    {
        // Fields
        private EV3Messenger messenger;
        EV3Message message;
        TimeSpan timespan = new TimeSpan(0, 0, 0);
        private Stopwatch stopwatch = new Stopwatch();
        bool isConnected = false;
        bool isControlled = false;
        bool isManaged = false;
        bool isPaused = false;
        bool isPickedUp = false;
        bool isDropped = false;
        double avgTimePickUp = 0, avgTimeDropOff = 0;

        List<TimeSpan> timeToPickUp = new List<TimeSpan>();
        List<TimeSpan> timeToDropOff = new List<TimeSpan>();
        bool firstTimePick = true;
        bool firstTimeDrop = true;

        int timeInMilliseconds = 0;


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

            // Load previous times in the appropriate listboxes
            using (StreamReader sr = new StreamReader("PickUpHistory.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    TimeSpan lineTime = TimeSpan.FromMilliseconds(Convert.ToInt64(line));
                    lstPickUpHistory.Items.Add(lineTime.Minutes + ":" + lineTime.Seconds);
                    timeToPickUp.Add(lineTime);
                }
            }

            using (StreamReader sr = new StreamReader("DropOffHistory.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    TimeSpan lineTime = TimeSpan.FromMilliseconds(Convert.ToInt64(line));
                    lstDropOffHistory.Items.Add(lineTime.Minutes+":"+lineTime.Seconds);
                    timeToDropOff.Add(lineTime);
                }
            }

            int sumTimes = 0;
            foreach(var item in timeToPickUp)
            {
                sumTimes += (int)item.TotalMilliseconds;
            }
            avgTimePickUp = sumTimes / timeToPickUp.Count;

            sumTimes = 0;
            foreach (var item in timeToDropOff)
            {
                sumTimes += (int)item.TotalMilliseconds;
            }
            avgTimeDropOff = sumTimes / timeToDropOff.Count;
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
            messenger.SendMessage("Robot_Mode", "Manage");
            btnStartManage.Enabled = false;
            btnStopManage.Enabled = true;
            btnManagePauseContinue.Enabled = true;
            elapsedTime.Start();
            stopwatch.Start();
        }

        private void btnStopManage_Click(object sender, EventArgs e)
        {
            isManaged = false;
            UpdateFormGUI();
            messenger.SendMessage("Robot_Mode", "Stop_Manage");
            btnStartManage.Enabled = true;
        }

        private void btnManagePauseContinue_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                messenger.SendMessage("Robot_Status", "Busy");
                isPaused = false;
            }
            else
            {
                messenger.SendMessage("Robot_Status", "Pause");
                isPaused = true;
            }
        }

        private void elapsedTime_Tick(object sender, EventArgs e)
        {
            timeInMilliseconds += 100;
            int etaMilliseconds;
            message = messenger.ReadMessage();
            if (message != null)
            {
                if (message.ValueAsText == "Picked_Up") isPickedUp = true;
                else if (message.ValueAsText == "Dropped_Off") isDropped = true;
            }            

            if (!isPickedUp && !isDropped)
            {
                txtStatus.Text = "Retreiving package";
                if (avgTimePickUp - timeInMilliseconds < 0)
                {
                    txtETA.Text = "The AGV is delayed";
                }
                else
                {
                    etaMilliseconds = (int)avgTimePickUp - timeInMilliseconds;
                    txtETA.Text = string.Format(TimeSpan.FromMilliseconds(etaMilliseconds).Minutes +":"+ TimeSpan.FromMilliseconds(etaMilliseconds).Seconds) ;
                }
                
            }
            else if (isPickedUp && !isDropped)
            {
                if (avgTimeDropOff - timeInMilliseconds < 0)
                {
                    txtETA.Text = "The AGV is delayed";
                }
                else
                {
                    etaMilliseconds = (int)avgTimeDropOff - timeInMilliseconds;
                    txtETA.Text = string.Format(TimeSpan.FromMilliseconds(etaMilliseconds).Minutes + ":" + TimeSpan.FromMilliseconds(etaMilliseconds).Seconds);
                }

                if (firstTimePick)
                {
                    timeInMilliseconds = 0;
                    txtStatus.Text = "Delivering package";                    
                    stopwatch.Stop();
                    timespan = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
                    timeToPickUp.Add(timespan);
                    lstPickUpHistory.Items.Add(timespan.Minutes+":"+timespan.Seconds);
                    firstTimePick = false;
                    stopwatch.Reset();
                    stopwatch.Start();

                    using (StreamWriter sw = new StreamWriter("PickUpHistory.txt", true))
                    {
                        sw.WriteLine(timespan.TotalMilliseconds);
                    }
                }
                              
            }
            else
            {                
                if (firstTimeDrop)
                {
                    txtETA.Text = "0:00";
                    txtStatus.Text = "Returning home";
                    stopwatch.Stop();
                    timespan = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
                    timeToDropOff.Add(timespan);
                    lstDropOffHistory.Items.Add(timespan.Minutes + ":" + timespan.Seconds);
                    firstTimeDrop = false;
                    stopwatch.Reset();

                    using (StreamWriter sw = new StreamWriter("DropOffHistory.txt", true))
                    {
                        sw.WriteLine(timespan.TotalMilliseconds);
                    }
                }                
            }
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
            messenger.SendMessage("Robot_Mode", "Control");
            btnStopControl.Enabled = true;
            btnStartControl.Enabled = false;
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
            messenger.SendMessage("Robot_Mode", "Stop_Control");
            btnStartControl.Enabled = true;
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
                        btnStartControl.Enabled = true;
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
                btnStopManage.Enabled = false;
                btnManagePauseContinue.Enabled = false;
                pnlControl.Enabled = true;
                btnStopControl.Enabled = false;
            }
        }
        
        #endregion


    }
}
