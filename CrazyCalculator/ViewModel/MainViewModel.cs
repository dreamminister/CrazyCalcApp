using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CrazyCalculator.Model;
using System.Collections.Generic;
using System.Windows.Media;

namespace CrazyCalculator.ViewModel
{
    class MainViewModel
    {
        public ICommand ClickCommand { get; set; }
        public Calculator Calc { get; set; }

        public MainViewModel()
        {
            ClickCommand = new Command(OnClickHandler);

            Calc = new Calculator()
            {
                FirstOperand = -1,
                SecondOperand = -1,
                Operation = Operation.None,
                Result = ""
            };
        }

        

        private string[] operations = {"+", "-", "*", "/"};
        private void OnClickHandler(object sender)
        {
            var btn = sender as Button;


            if (btn != null)
            {
                string value = CheckInput(btn.Content.ToString());

                if (value == "C")
                {
                    Calc.Result = "";
                    Calc.FirstOperand = -1;
                    Calc.SecondOperand = -1;
                    Calc.Operation = Operation.None;
                }
                else if (operations.Contains(value) && Calc.Operation == Operation.None && Calc.Result != "")
                {
                    switch (value)
                    {
                        case "+":
                            Calc.Operation = Operation.Add;
                            break;
                        case "-":
                            Calc.Operation = Operation.Sub;
                            break;
                        case "*":
                            Calc.Operation = Operation.Mult;
                            break;
                        case "/":
                            Calc.Operation = Operation.Div;
                            break;
                    }

                    Calc.FirstOperand = long.Parse(Calc.Result);
                    Calc.Result += value;
                }
                else if (!operations.Contains(value) && value != "=" && Calc.Operation == Operation.None)
                {
                    Calc.Result += value;
                }
                else if (!operations.Contains(value) && value != "=" && Calc.Operation != Operation.None)
                {
                    Calc.Result += value;
                }
                else if (value == "=" && Calc.Result != "" && Calc.FirstOperand != -1)
                {
                    char temp = Calc.Result[Calc.Result.Length - 1];

                    if (!char.IsDigit(temp))
                    {
                        Calc.Result = Calc.FirstOperand.ToString();
                        Calc.Operation = Operation.None;
                        return;
                    }

                    string second = Calc.Result.Replace(Calc.FirstOperand.ToString(), "").Substring(1);
                    Calc.SecondOperand = long.Parse(second);

                    if (Calc.Operation == Operation.Add)
                        Calc.Result = (Calc.FirstOperand + Calc.SecondOperand).ToString();
                    if (Calc.Operation == Operation.Div)
                        Calc.Result = (Calc.FirstOperand/Calc.SecondOperand).ToString();
                    if (Calc.Operation == Operation.Mult)
                        Calc.Result = (Calc.FirstOperand*Calc.SecondOperand).ToString();
                    if (Calc.Operation == Operation.Sub)
                        Calc.Result = (Calc.FirstOperand - Calc.SecondOperand).ToString();

                    Calc.FirstOperand = long.Parse(Calc.Result);
                    Calc.Operation = Operation.None;
                }

                ShuffleButtons(sender);
            }
        }

        private void ShuffleButtons(object sender)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                var gr = btn.Parent as Grid;
                if (gr == null)
                    return;
                
                var collection = gr.Children.OfType<Button>().ToList();

                for (int i = 0; i < collection.Count; i++)
                {
                    for (int j = 1; j < collection.Count; j=j*2)
                    {
                        string temp = collection[i].Content.ToString();
                        collection[i].Content = collection[j].Content;
                        collection[j].Content = temp;
                    }

                    for (int k = 1; k < collection.Count; k = k * 3)
                    {
                        string temp = collection[i].Content.ToString();
                        collection[i].Content = collection[k].Content;
                        collection[k].Content = temp;
                    }
                }
            }
        }

        private string CheckInput(string input)
        {
            char symbol;
            if (input.Length == 1 && char.TryParse(input, out symbol))
            {
                if (char.IsNumber(symbol))
                {
                    return input;
                }
                else if (char.IsLetter(symbol))
                {
                    return "C";
                }
                else if (symbol == '=')
                {
                    return "=";
                }
            }
            else
            {
                if (input.Equals("ADD"))
                {
                    return "+";
                }
                else if (input.Equals("DIV"))
                {
                    return "/";
                }
                else if (input.Equals("MULT"))
                {
                    return "*";
                }
                else if (input.Equals("SUB"))
                {
                    return "-";
                }
            }

            return "";
        }
    }
}
