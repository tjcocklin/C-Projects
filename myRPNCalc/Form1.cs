using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace myRPNCalc
{
    public partial class Form1 : Form
    {
        Stack<int> userInput= new Stack<int>();

        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void Multiply()
        {
            int a, b, res;

            b = userInput.Pop();
            a = userInput.Pop();
            res = a * b;

            userInput.Push(res);
            
        }
        private void Divide()
        {
            int a, b, res;

            b = userInput.Pop();
            a = userInput.Pop();
            try
            {
                if (b == 0)
                {
                    throw new DivideByZeroException();
                }
                res = a / b;

                userInput.Push(res);
            }
            catch( DivideByZeroException e)
            {
                results.Text = "ERROR: Division by zero, press clr twice";
            }


           

            }
        private void Add()
        {
            int a, b, res;

            b = userInput.Pop();
            a = userInput.Pop();
            res = a + b;

            userInput.Push(res);

        }
        private void Subtract()
        {
            int a, b, res;

            b = userInput.Pop();
            a = userInput.Pop();
            res = a - b;

            userInput.Push(res);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            results.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            results.Text += "2";
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            results.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            results.Text += "4";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            results.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            results.Text += "6";
        }
        private void button7_Click(object sender, EventArgs e)
        { 
            results.Text += "7";
        
        }
        private void button8_Click(object sender, EventArgs e)
        {
            results.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            results.Text += "9";
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            results.Text += "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Clear button
            if (results.Text.Length == 0 && userInput.Count > 0)
            {
                userInput.Clear();
               // if (userInput.Count == 0)
                   // Console.WriteLine("empty stack");
            }
            else if(results.Text.Length > 0)
            {
                results.Text = "";
                //Console.WriteLine("empty Str");
                //Console.WriteLine(""+userInput.Peek());
            }

        }
        private void button12_Click_1(object sender, EventArgs e)
        {
            //Equals
            Calc();  

        }
        private void button13_Click(object sender, EventArgs e)
        {
            //Multiply
            results.Text += "*";


        }
        private void button14_Click(object sender, EventArgs e)
        {
            //Division
            results.Text += "/";
        }
        private void button15_Click(object sender, EventArgs e)
        {
            //Addition
            results.Text += "+";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            //subtraction
            results.Text += "-";
        }
        private void button17_Click(object sender, EventArgs e)
        {
            //append a space
            results.Text += " ";
        }

        private void Calc()
        {
            //parse an calculate

            String[] parsed = results.Text.Split(' ');

            bool isDigit;
            int intVal;

            for (int i = 0; i < parsed.Length; i++)
            {
                isDigit = int.TryParse(parsed[i], out intVal);
                //Console.WriteLine(intVal);
                if (isDigit) {
                    userInput.Push(intVal);
                }
                else if(parsed[i].Length == 1)
                {
                    try
                    {
                        switch (parsed[i])
                        {
                            case "*":
                                Multiply();
                                break;

                            case "/":
                                Divide();
                                break;

                            case "+":
                                Add();
                                break;

                            case "-":
                                Subtract();
                                break;

                            default:
                                results.Text = "How Did you do that?!";
                                break;
                        }
                    }catch(InvalidOperationException e)
                    {
                        results.Text = "ERROR: You need at least 2 operands per operator.";
                    }
                }
                else
                {
                    results.Text = "ERROR: Bad input, input Press clr twice.";
                }
                //Console.WriteLine(parsed[i]);
            }
            int remaining = userInput.Count;
            if(remaining > 1)
            {
                results.Text = "ERROR: Not enough operators!";
            }
            else if (remaining == 1)
            {
                results.Text = "" + userInput.Pop();
            }
        }   
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
