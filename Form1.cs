using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProvaPWD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool blockTAB = false;
        int countdownPWD;
        int watchDogTime = 10;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabControl.SelectedIndex > 1) && (blockTAB==false))
            {
                tabControl.SelectedTab = tabPage1;
                MessageBox.Show("Sorry... but you don't have privileges to use this tab. Please, open Monitor tab and insert password to unblock");
            }
        }

        private void btnpassword_Click(object sender, EventArgs e)
        {
            if (txtPWD.Text == "permesso")
            {
                blockTAB = true;
                timerPWD.Enabled = true;
                countdownPWD = watchDogTime;
            }
        }

        private void timerPWD_Tick(object sender, EventArgs e)
        {
            if (countdownPWD == 0)
            {
                blockTAB = false;
                timerPWD.Enabled = false;
                tabControl.SelectedTab = tabPage1;
            }
            countdownPWD = countdownPWD - 1;
            lbltime.Text = countdownPWD.ToString();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            countdownPWD = watchDogTime; //se si sposta sul Form
        }

        private void tabControl_MouseMove(object sender, MouseEventArgs e)
        {
            countdownPWD = watchDogTime; //se si sposta sul TabControl
        }

        private void tabPage3_MouseMove(object sender, MouseEventArgs e)
        {
            countdownPWD = watchDogTime; //se si sposta sulla pagina 3 del TabControl
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lblFrom.Text = dateTimePicker1.Text;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value >= dateTimePicker1.Value)
            { 
                lblTo.Text = dateTimePicker2.Text;
            }
            else
            {
                MessageBox.Show("It'n not possibile to have...");
                dateTimePicker1.Value = Convert.ToDateTime(dateTimePicker1.Text);
            }
        }
    }
}
