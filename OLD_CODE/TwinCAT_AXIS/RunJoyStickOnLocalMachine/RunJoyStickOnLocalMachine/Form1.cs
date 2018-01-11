using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TwinCAT_AXIS;

namespace RunJoyStickOnLocalMachine
{
    public partial class Form1 : Form
    {
        int x;
        int y;
        double counter;
        double unit=0.1;

        StringBuilder output_string = new StringBuilder("");
        StringBuilder income = new StringBuilder(" ");

        private Joystick joystick;
        private bool[] joystickButtons;
        public Form1()
        {
            InitializeComponent();
            joystick = new Joystick(this.Handle);
            connectToJoystick(joystick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //---------------------------------------------------------------------
        private void connectToJoystick(Joystick joystick)
        {
            while (true)
            {
                string sticks = joystick.FindJoysticks();
                if (sticks != null)
                {
                    if (joystick.AcquireJoystick(sticks))
                    {
                        enableTimer();
                        break;
                    }
                }
            }
        }

        private void enableTimer()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ThreadStart(delegate()
                {
                    joystickTimer.Enabled = true;
                }));
            }
            else
                joystickTimer.Enabled = true;
        }

        private void joystickTimer_Tick_1(object sender, EventArgs e)
        {
            try
            {
                joystick.UpdateStatus();
                joystickButtons = joystick.buttons;
                    
                if (joystick.Xaxis < 32767)
                {
                    x=inverse(joystick.Xaxis);

                    counter -= Double.Parse(x.ToString()) / 10;

                    Axis_control.RvExtension(output_string, 8, counter.ToString());

                    output.Text = "Direction: Left Position: "+counter.ToString() +" Speed:" + x.ToString() + "\n" + output.Text;

                    Thread.Sleep(100);
                }

                if (joystick.Xaxis > 32767)
                {
                    joystick.Xaxis = joystick.Xaxis - 32767;
                    x = Power(joystick.Xaxis);

                    counter += Double.Parse(x.ToString()) / 10;

                    Axis_control.RvExtension(output_string, 8, counter.ToString());

                    output.Text = "Direction: Right Position: " + counter.ToString() + " Speed:" + x.ToString() + "\n" + output.Text;

                    Thread.Sleep(1);
                }
            }
            catch
            {
                joystickTimer.Enabled = false;
                connectToJoystick(joystick);
            }
        }
        private int inverse(int number)
        {
            number = number / 3277;
            switch (number)
            {
                case 0:
                    number = 9;
                    break;
                case 1:
                    number = 8;
                    break;
                case 2:
                    number = 7;
                    break;
                case 3:
                    number = 6;
                    break;
                case 4:
                    number = 5;
                    break;
                case 5:
                    number = 4;
                    break;
                case 6:
                    number = 3;
                    break;
                case 7:
                    number = 2;
                    break;
                case 8:
                    number = 1;
                    break;
                case 9:
                    number = 0;
                    break;
            } 
            return number;
        }
        private int Power(int number)
        {
            number = number / 3277;

            return number;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            output.Text = "";
        }

    }
}
