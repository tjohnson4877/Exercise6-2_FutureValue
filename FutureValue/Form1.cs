using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // initialize variables for investment, interest rate, and years
            decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
            decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            // calculate, format, and display future value
            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            decimal futureValue = this.CalculateFutureValue(
                monthlyInvestment, monthlyInterestRate, months); // Item 6: call CalculateFutureValue method
            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();
        }
        
        private decimal CalculateFutureValue(decimal monthlyInvestment, 
            decimal monthlyInterestRate, int months) // Item 5: create method to calculate future value
        {
            decimal futureValue = 0m; // initialize variable for future value
            for (int i = 0; i < months; i++) // add interest for each month
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }
            return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // close form
        }

        private void ClearFutureValue(object sender, EventArgs e) // Item 9: method to clear future value
        {
            txtFutureValue.Text = ""; // Item 9: clear Future Value textbox
        }
        /*****************************************************
         * Travis Johnson
         * 4-24-2020
         * "Week 4 Murach Practice Assignments (Individual)"
         * Exercise 6-2 "Experiment with events"
         *****************************************************/
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            // clear all textboxes
            txtMonthlyInvestment.Text = "";
            txtInterestRate.Text = "";
            txtYears.Text = "";
            txtFutureValue.Text = "";
        }

        private void txtInterestRate_DoubleClick(object sender, EventArgs e)
        {
            txtInterestRate.Text = "12"; // set textbox value to 12
        }
    }
}