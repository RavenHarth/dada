using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        int currentCalcTime = 1;
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClick(object sender, EventArgs e)
        {
            string btnNumber = ((Button)sender).Text;
            if
                (lblSign.Text == "")
            {
                TbFirstNumber.Text += btnNumber;
            }
            else
                TbSecondNumber.Text += btnNumber;
            

        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            string symbol = ((Button)sender).Text;
            lblSign.Text = symbol;

        }

        private void lblSign_Click(object sender, EventArgs e)
        {
            lblSign.Text = "";
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {

            //Ако ще използваме реални числа, decimal е правилния вариант - с най-голяма точност и големина
            //(128-битов тип)
            //Ако ще изполваме цели числа, BigInteger би бил правилен вариант, ако ще използваме сметки
            //с кголеми числа.
            decimal firstNumber = 0.0m;
            decimal secondNumber = 0.0m;
            try
            {
                DataTable dt = new DataTable();
                var v = dt.Compute(TbFirstNumber.Text, "");
                var b = dt.Compute(TbSecondNumber.Text, "");

                

                firstNumber = decimal.Parse(v.ToString());
                secondNumber = decimal.Parse(b.ToString());
            }
            catch (FormatException exc)
            {
                MessageBox.Show("Попълни си полетата");
            }

            catch (OverflowException exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch (DivideByZeroException exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                MessageBox.Show("Finally triggered");
            }
            
            decimal result = 0;
            switch (lblSign.Text)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-": 
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }
            
            tbResult.Text = result.ToString("F2");

            //Memory-to pazi maximum 6 puti (po princip kalkulatorite nqmat mnogo pamet lmaooo)
          
            switch (currentCalcTime)
            {
                case 1:
                    calc1.Text = "First calculation: " + TbFirstNumber.Text + " " + lblSign.Text + " " + TbSecondNumber.Text + " = " + result.ToString("F2");
            break;
                case 2:
                    calc2.Text = "Second calculation: " + TbFirstNumber.Text + " " + lblSign.Text + " " + TbSecondNumber.Text + " = " + result.ToString("F2");
                    break;
                case 3:
                    calc3.Text = "Third calculation: " + TbFirstNumber.Text + " " + lblSign.Text + " " + TbSecondNumber.Text + " = " + result.ToString("F2");
                    break;
                case 4:
                    calc4.Text = "Fourth calculation: " + TbFirstNumber.Text + " " + lblSign.Text + " " + TbSecondNumber.Text + " = " + result.ToString("F2");
                    break;
                case 5:
                    calc5.Text = "Fifth calculation: " + TbFirstNumber.Text + " " + lblSign.Text + " " + TbSecondNumber.Text + " = " + result.ToString("F2");
                    break;
                case 6:
                    calc6.Text = "Sixth calculation: " + TbFirstNumber.Text + " " + lblSign.Text + " " + TbSecondNumber.Text + " = " + result.ToString("F2");
                    break;

                default:
                    break;
            }
            currentCalcTime++;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            TbFirstNumber.Text = "";
            TbSecondNumber.Text = String.Empty;
            tbResult.Text = String.Empty;
            lblSign.Text = String.Empty;

              
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            lblSign.Text = String.Empty;
        }
    }
}
