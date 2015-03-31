using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CrazyCalculator.Model;

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

        private void OnClickHandler(object sender)
        {
            var btn = sender as Button;

            if (btn != null)
            {
                string value = btn.Content.ToString();

                Calc.Result += value;

                
            }
        }
    }
}
