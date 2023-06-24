using System;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace calculator
{
    public partial class Main : Form
    {

        private bool newCalc = true;

        public Main()
        {
            InitializeComponent();
            this.Text = "Calculator";
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Calculate()
        {
            try
            {
                double summa = 0;
                List<string> stringList = new List<string>();
                int previous = 0;
                for (int x = 0; x < textbox.Text.Length; x++)
                {
                    if (textbox.Text[x] == '+' || textbox.Text[x] == '-' || textbox.Text[x] == '*' || textbox.Text[x] == '/' || textbox.Text[x] == '^' || textbox.Text[x] == 'r')
                    {
                        stringList.Add(textbox.Text.Substring(previous, x - previous));
                        previous = x + 1;
                        stringList.Add(Char.ToString(textbox.Text[x]));
                    }

                }
                stringList.Add(textbox.Text.Substring(previous));

                while (stringList.Contains("^"))
                {
                    int index = stringList.FindIndex(stringList => stringList.Contains('^'));
                    //double result = Convert.ToDouble(stringList[index - 1]) * Convert.ToDouble(stringList[index + 1]);
                    double result = Math.Pow(Double.Parse(stringList[index - 1], CultureInfo.InvariantCulture), Double.Parse(stringList[index + 1], CultureInfo.InvariantCulture));
                    stringList[index - 1] = result.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
                    stringList.RemoveRange(index, 2);
                }

                while (stringList.Contains("r"))
                {
                    int index = stringList.FindIndex(stringList => stringList.Contains('r'));
                    //double result = Convert.ToDouble(stringList[index - 1]) * Convert.ToDouble(stringList[index + 1]);
                    double result = Math.Pow(Double.Parse(stringList[index - 1], CultureInfo.InvariantCulture), 1 / Double.Parse(stringList[index + 1], CultureInfo.InvariantCulture));
                    stringList[index - 1] = result.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
                    stringList.RemoveRange(index, 2);
                }

                while (stringList.Contains("*"))
                {
                    int index = stringList.FindIndex(stringList => stringList.Contains('*'));
                    //double result = Convert.ToDouble(stringList[index - 1]) * Convert.ToDouble(stringList[index + 1]);
                    double result = Double.Parse(stringList[index - 1], CultureInfo.InvariantCulture) * Double.Parse(stringList[index + 1], CultureInfo.InvariantCulture);
                    stringList[index - 1] = result.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
                    stringList.RemoveRange(index, 2);
                }
                while (stringList.Contains("/"))
                {
                    int index = stringList.FindIndex(stringList => stringList.Contains('/'));
                    //double result = Convert.ToDouble(stringList[index - 1]) / Convert.ToDouble(stringList[index + 1]);
                    double result = Double.Parse(stringList[index - 1], CultureInfo.InvariantCulture) / Double.Parse(stringList[index + 1], CultureInfo.InvariantCulture);
                    stringList[index - 1] = result.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
                    stringList.RemoveRange(index, 2);
                }
                foreach (string s in stringList)
                {
                    System.Diagnostics.Debug.WriteLine(s);
                }
                //summa += Convert.ToDouble(stringList[0]);
                summa += Double.Parse(stringList[0], CultureInfo.InvariantCulture);
                for (int index = 1; index < stringList.Count; index += 2)
                {
                    double result = 0;
                    //double second = Convert.ToDouble(stringList[index + 1]);
                    double second = Double.Parse(stringList[index + 1], CultureInfo.InvariantCulture);
                    switch (stringList[index])
                    {
                        case "+":
                            summa += second;
                            break;
                        case "-":
                            summa -= second;
                            break;
                    }
                    System.Diagnostics.Debug.WriteLine(result);
                }
                textbox.Text = summa.ToString();
            }
            catch (Exception ex)
            {
                newCalc = true;
                textbox.Text = ex.Message;
            }
        }

        private void RemoveLast()
        {
            if (textbox.Text.Length > 0)
            {
                textbox.Text = textbox.Text[..^1];
            }
        }

        private void ClearTextbox()
        {
            textbox.Text = "";
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if (newCalc)
            {
                textbox.Text = "";
                newCalc = false;
            }
            switch (e.KeyCode)
            {  
                case Keys.NumPad0:
                    textbox.Text += '0';
                    break;
                case Keys.NumPad1:
                    textbox.Text += '1';
                    break;
                case Keys.NumPad2:
                    textbox.Text += '2';
                    break;
                case Keys.NumPad3:
                    textbox.Text += '3';
                    break;
                case Keys.NumPad4:
                    textbox.Text += '4';
                    break;
                case Keys.NumPad5:
                    textbox.Text += '5';
                    break;
                case Keys.NumPad6:
                    textbox.Text += '6';
                    break;
                case Keys.NumPad7:
                    textbox.Text += '7';
                    break;
                case Keys.NumPad8:
                    textbox.Text += '8';
                    break;
                case Keys.NumPad9:
                    textbox.Text += '9';
                    break;
                case Keys.D0:
                    textbox.Text += '0';
                    break;
                case Keys.D1:
                    textbox.Text += '1';
                    break;
                case Keys.D2:
                    textbox.Text += '2';
                    break;
                case Keys.D3:
                    textbox.Text += '3';
                    break;
                case Keys.D4:
                    textbox.Text += '4';
                    break;
                case Keys.D5:
                    textbox.Text += '5';
                    break;
                case Keys.D6:
                    textbox.Text += '6';
                    break;
                case Keys.D7:
                    textbox.Text += '7';
                    break;
                case Keys.D8:
                    textbox.Text += '8';
                    break;
                case Keys.D9:
                    textbox.Text += '9';
                    break;
                case Keys.Add:
                    textbox.Text += '+';
                    break;
                case Keys.Subtract:
                    textbox.Text += '-';
                    break;
                case Keys.Multiply:
                    textbox.Text += '*';
                    break;
                case Keys.Divide:
                    textbox.Text += '/';
                    break;
                case Keys.R:
                    textbox.Text += 'r';
                    break;
                case Keys.OemSemicolon:
                    textbox.Text += '^';
                    break;
                case Keys.Decimal:
                    textbox.Text += '.';
                    break;
                case Keys.OemPeriod:
                    textbox.Text += '.';
                    break;
                case Keys.Oemcomma:
                    textbox.Text += '.';
                    break;
                case Keys.Enter:
                    Calculate();
                    break;
                case Keys.Back:
                    RemoveLast();
                    break;
                case Keys.Delete:
                    RemoveLast();
                    break;
                case Keys.Escape:
                    ClearTextbox();
                    break;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button nappi = (Button)sender;
            if (nappi.Text == "=")
            {
                newCalc = true;
                Calculate();
            }
            else
            {
                if (newCalc)
                {
                    newCalc = false;
                    textbox.Text = "";
                }
                if (nappi.Text == "del")
                {
                    RemoveLast();
                }
                else if (nappi.Text == "C")
                {
                    ClearTextbox();
                }
                else
                {
                    textbox.Text += nappi.Text;
                }
            }
        }
        private void Textbox_Changed(object sender, EventArgs e)
        {

        }
    }
}