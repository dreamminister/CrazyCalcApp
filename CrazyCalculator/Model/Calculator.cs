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
        public long FirstOperand;
        public long SecondOperand;
        public Operation Operation;

        public event PropertyChangedEventHandler PropertyChanged;


        private string _result;
        public string Result
        {
            set
            {
                _result = value;

                OnPropertyChanged("Result");

                
                if (Operation != Operation.None)
                {
                    Error = Operation.ToString();
                    OnPropertyChanged("Error");
                }
                else if (Result == "")
                {
                    Error = "";
                    OnPropertyChanged("Error");
                }

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
