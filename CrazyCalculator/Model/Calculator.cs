using System.ComponentModel;
using System.Text;

namespace CrazyCalculator.Model
{
    public enum Operation
    {
        None = -1,
        Reset,
        Result,
        Add,
        Mult,
        Sub,
        Div
    }



    public class Calculator : INotifyPropertyChanged
    {
        public int FirstOperand;
        public int SecondOperand;
        public Operation Operation;

        public static string OperationToString(Operation op)
        {
            if (op == Operation.Mult)
                return "*";
            else if (op == Operation.Sub)
                return "-";
            else if (op == Operation.Add)
                return "+";
            else if (op == Operation.Div)
                return "/";
            else
                return "";
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private string _result;
        public string Result
        {
            set
            {
                _result = value;
                OnPropertyChanged("Result");
                
                if (Result.Length > 5)
                    Error = "Too many digits...";
                OnPropertyChanged("Error");
            }
            get
            {
                return _result;
            }
        }

        public string Error { get; set; }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


    }
}
