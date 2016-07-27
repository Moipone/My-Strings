using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThinkLib;

namespace money_talk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string Ones(char n)
        {
            string back = "";
            switch (n)
            {
                case '0' :  return "";
                case '1': return "one";
                case '2': return "two";
                case '3': return "three";
                case '4': return "four";
                case '5': return "five";
                case '6': return "six";
                case '7': return "seven";
                case '8': return "eight";
                case '9': return "nine";

            }
            return back;
                      
        }

        string Ftens(string t)
        {
            string back = "";
            switch (t)
            {
                case "10": return "ten";
                case "11": return "eleven";
                case "12": return "twelve";
                case "13": return "thirteen";
                case "14": return "fourteen";
                case "15": return "fifteen";
                case "16": return "sixteen";
                case "17": return "seventeen";
                case "18": return "eighteen";
                case "19": return "nineteen";

            }
            return back;
        }

        string Tens(string t)
        {
            string back = "";
            string use = Convert.ToString(t[0]);
            switch (use)
            {
                case "0": return "zero";
                case "1": return "";
                case "2": return "twenty";
                case "3": return "thirty";
                case "4": return "fourty";
                case "5": return "fifty";
                case "6": return "sixty";
                case "7": return "seventy";
                case "8": return "eighty";
                case "9": return "ninety";

            }
            return back ;
        }

        string TensH(string t)
        {
            string back = "";
            string use = Convert.ToString(t[0]);
            switch (use)
            {
                case "0": return " zero " ;
                case "1": return " ";
                case "2": return " twenty ";
                case "3": return " thirty ";
                case "4": return " fourty ";
                case "5": return " fifty ";
                case "6": return " sixty ";
                case "7": return " seventy ";
                case "8": return " eighty ";
                case "9": return " ninety ";

            }
            return back;
        }

        string Hundred(string h)
        {
            string back = "";
            string use = Convert.ToString(h[0]);
            switch (use)
            {
                case "0": return " hundred ";
                case "1": return  Ones(h[0])+ " hundred ";
                case "2": return Ones(h[0]) + " hundred ";
                case "3": return Ones(h[0]) + " hundred ";
                case "4": return Ones(h[0]) + " hundred ";
                case "5": return Ones(h[0]) + " hundred ";
                case "6": return Ones(h[0]) + " hundred ";
                case "7": return Ones(h[0]) + " hundred ";
                case "8": return Ones(h[0]) + " hundred ";
                case "9": return Ones(h[0]) + " hundred ";

            }
            return back;
        }

        private string convert(string inP)
        {
            string s = "";
            string   rand = inP;
            string cents = inP;

            if (inP.Contains("R") && (inP.Contains("c")))
            {
                return "Invalid Input";
            }

            if (inP[0] == '0' && (inP.Contains("c")))
            {
                return "Invalid Input";
            }

            //if (inP[0] == '0')
            //{
            //    return "Invalid Input";
            //}

            
            int position = inP.IndexOf('.');
            if (position >= 0  && (inP.Contains("R")))
            {
                rand = inP.Remove(position);
                rand = rand.Remove(0, 1);
            } 
                       
            //kwezi= rand.Remove(0);
            //rands = rand.Remove(0);

            //rand.Remove(0) 
            int pos = inP.IndexOf('.');
            if (pos >= 0)
            {
                cents = inP.Remove(0, pos +1);
            }
                
            if (rand.Length > 3) { return "Invalid Input"; }

            if (rand.Length == 1)
            {
                s = Ones(rand[0]) + " rand";
                if (cents.Length == 1)
                {  
                    s = s + " and " + Ones(cents[0]) + " cents";
                }
                if (cents.Length == 2)
                {
                    s = s + " and " + Tens(cents) + " cents";
                }
            }
            if (rand.Length == 3)
            {
                s = Hundred(rand) +"and"+ TensH(rand) +  " "+Ones(rand[2]) + " rand";
                if (cents.Length == 1)
                {
                    s = s + "and" + Ones(cents[0]) + " cents";
                }
                if (cents.Length == 2)
                {
                    s = s + " and " + Tens(cents) + " "+Ones(cents[1]) + " cents";
                }
            }
            if (rand.Length == 2)
            {
                if (Convert.ToInt32(rand) < 20)
                {
                    s = Ftens(rand) + " rand";
                    if (cents.Length == 1)
                    {
                        s = s + " and" + Ones(cents[0]) + " cents";
                    }
                    if (cents.Length == 2)
                    {
                        s = s + " and" + Tens(cents) +  " "+Ones(cents[1]) + " cents";
                    }
                    
                }
                else { s = Tens(rand) + " rand";
                    if (cents.Length == 1)
                    {
                        s = s + " and" + Ones(cents[0]) + " cents";
                    }
                    if (cents.Length == 2)
                    {
                        s = s + " and" + Tens(cents) +" "+ Ones(cents[1]) + " cents";
                    }
                }
                    
            }
            return s; 
        }

        private void converMoney_Click(object sender, RoutedEventArgs e)
        {
            outputBox.Text = convert(moneyBox.Text);
        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            ThinkLib.Tester.TestEq(convert("R245.72"), "two hundred and fourty five rand and seventy two cents");
            ThinkLib.Tester.TestEq(convert("51c"), "fifty one cents");
            ThinkLib.Tester.TestEq(convert("R398"), "three hundred and ninety eight rand");
            ThinkLib.Tester.TestEq(convert("R17"), "seventeen rand");
            ThinkLib.Tester.TestEq(convert("20c"), "twenty cents");
            ThinkLib.Tester.TestEq(convert("R100.20"), "one hundred rand and twenty cents");
            ThinkLib.Tester.TestEq(convert("R100.20c"), "Invalid Input");
            ThinkLib.Tester.TestEq(convert("0.20"), "Invalid Input");
            ThinkLib.Tester.TestEq(convert("0.20c"), "Invalid Input");
            ThinkLib.Tester.TestEq(convert("R100"), "one hundred rand");
            ThinkLib.Tester.TestEq(convert("R101"), "one hundred and one rand");
            ThinkLib.Tester.TestEq(convert("R101.01"), "one hundred and one rand and one cents");
            ThinkLib.Tester.TestEq(convert("R101.00"), "one hundred and  one rand and zero  cents");
            ThinkLib.Tester.TestEq(convert("R1000"), "Invalid Input");
            ThinkLib.Tester.TestEq(convert("020c"), "Invalid Input");

        }
    }
}
