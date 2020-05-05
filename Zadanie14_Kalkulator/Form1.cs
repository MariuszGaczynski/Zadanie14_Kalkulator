using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie14_Kalkulator
{
    public partial class MainForm : Form
    {

        double value = 0;
        string operation = String.Empty;
        bool operationPressed = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (txtB_Result.Text == "0" || operationPressed == true)
            {
                txtB_Result.Clear();
            }
            operationPressed = false;
            Button btn = (Button)sender;

            if (btn.Text == ",")
            {
                if (!txtB_Result.Text.Contains(","))
                {
                    txtB_Result.Text = txtB_Result.Text + btn.Text;
                }
            }
            else
            {
                txtB_Result.Text = txtB_Result.Text + btn.Text;
            }
        }

        private void btn_ClearEntry_Click(object sender, EventArgs e)
        {
            txtB_Result.Text = "0";
        }

        private void operatorClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operation = btn.Text;
            value = Double.Parse(txtB_Result.Text);
            operationPressed = true;
        }

        private void equalsClick(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    txtB_Result.Text = (value  + Double.Parse(txtB_Result.Text)).ToString();
                    break;
                case "-":
                    txtB_Result.Text = (value - Double.Parse(txtB_Result.Text)).ToString();
                    break;
                case "*":
                    txtB_Result.Text = (value * Double.Parse(txtB_Result.Text)).ToString();
                    break;
                case "/":
                    txtB_Result.Text = (value / Double.Parse(txtB_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            operationPressed = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtB_Result.Text = "0";
            value = 0;
        }
    }
}
