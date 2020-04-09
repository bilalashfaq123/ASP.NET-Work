using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String reg = "^[0-9]*$";
            bool isValidText1IsMatch = Regex.IsMatch(textBox1.Text, reg);
            bool isValidText2IsMatch = Regex.IsMatch(textBox2.Text, reg);
            if (!isValidText1IsMatch || !isValidText2IsMatch || textBox1.Text != "" || textBox2.Text != "")
            {
                MessageBox.Show("Please enter a valid Number");
                return;
            }

            try
            {
                Button button = (Button) sender;
                String opt = button.Text;
                Calculate(textBox1.Text, textBox2.Text, opt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Calculate(object var1, object var2, string opt)
        {
            double num1 = Convert.ToDouble(var1);
            double num2 = Convert.ToDouble(var2);
            double res = 0;
            switch (opt)
            {
                case "+":
                    res = num1 + num2;
                    textBox3.Text = res.ToString();
                    break;
                case "-":
                    res = num1 - num2;
                    textBox3.Text = res.ToString();
                    break;
                case "/":
                    try
                    {
                        res = num1 / num2;
                        textBox3.Text = res.ToString();
                    }
                    catch (DivideByZeroException e)
                    {
                        // MessageBox.Show("Zero Division Error");
                        textBox3.Text = "infinity";
                    }

                    break;
                case "x":
                    res = num1 * num2;
                    textBox3.Text = res.ToString();
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}