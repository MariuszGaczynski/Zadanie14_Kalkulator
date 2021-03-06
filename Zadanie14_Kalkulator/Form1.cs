﻿using System;
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
        string lastEntry;  //  // pomaga mi żeby w labelu nie wyskakiwał aktualny wynik tylko poprzednia wpisywana liczba
        bool notEqualsYet = false; // pomaga mi żeby w labelu nie wyskakiwał aktualny wynik , dopiero jak będzie "=" wywyołane

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text != ",")
            {
                if (txtB_Result.Text == "0" || operationPressed == true)
                {
                    txtB_Result.Clear();
                }
            }
            operationPressed = false;
            

            if (btn.Text == ",")
            {
                if (!txtB_Result.Text.Contains(","))
                {
                    txtB_Result.Text = txtB_Result.Text + btn.Text;
                }
            }
            else if (btn.Text == "," && txtB_Result.Text == "0") // dzieki temu udało się ułamek mniejszy niż 1 zrobić (0,3 na przykład)
            {
                txtB_Result.Text = "0" + btn.Text;
            }
            else
            {
                txtB_Result.Text = txtB_Result.Text + btn.Text;
            }

            lastEntry = txtB_Result.Text;
            notEqualsYet = false;
        }

        private void btn_ClearEntry_Click(object sender, EventArgs e)
        {
            txtB_Result.Text = "0";



        }

        private void operatorClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (value !=0)
            {
                notEqualsYet = true;
                btn_equals.PerformClick();
                operation = btn.Text;
                operationPressed = true;

                lbl_calculation.Text += lastEntry + operation;
            }
            else
            {
                lbl_calculation.Text = lastEntry;
                operation = btn.Text;
                value = Double.Parse(txtB_Result.Text);
                operationPressed = true;

                lbl_calculation.Text += (btn.Text);
               
            }

            
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
            value = Double.Parse(txtB_Result.Text);
            
            Button btn = (Button)sender;

            if (notEqualsYet != true)
            {
                lbl_calculation.Text += lastEntry + "=";

                lbl_calculation.Text +=  txtB_Result.Text;
            }
            else
            {
               
            }
            
            operationPressed = false;
            operation = String.Empty;


        }

        private void btn_ClearClick(object sender, EventArgs e)
        {
            txtB_Result.Text = "0";
            value = 0;
            lbl_calculation.Text = String.Empty;


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "1":
                    btn_1.PerformClick();
                    break;
                case "2":
                    btn_2.PerformClick();
                    break;
                case "3":
                    btn_3.PerformClick();
                    break;
                case "4":
                    btn_4.PerformClick();
                    break;
                case "5":
                    btn_5.PerformClick();
                    break;
                case "6":
                    btn_6.PerformClick();
                    break;
                case "7":
                    btn_7.PerformClick();
                    break;
                case "8":
                    btn_8.PerformClick();
                    break;
                case "9":
                    btn_9.PerformClick();
                    break;
                case "0":
                    btn_0.PerformClick();
                    break;
                case "+":
                    btn_plus.PerformClick();
                    break;
                case "-":
                    btn_minus.PerformClick();
                    break;
                case "*":
                    btn_multiple.PerformClick();
                    break;
                case "/":
                    btn_divide.PerformClick();
                    break;
                case ",":
                    btn_comma.PerformClick();
                    break;
                case "=":
                  btn_equals.PerformClick();
                    break;

                case "escape":
                   btn_Clear.PerformClick();
                   break;


                default:
                    break;

            }
            switch (e.KeyChar)
            {

                //case (char)Keys.Enter:
                //    btn_equals.PerformClick();
                //    break;
                //case (char)Keys.Return:
                //    btn_equals.PerformClick();
                //    break;
                case (char)Keys.Escape:
                    btn_Clear.PerformClick();
                    break;
                case (char)Keys.Back:
                    btn_ClearEntry.PerformClick();
                    break;
            }
            }
    }
}
