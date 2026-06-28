using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_MVVM_calculator.Command;
using Wpf_MVVM_calculator.Model;

namespace Wpf_MVVM_calculator.ViewModel
{
    public class VM_Calculator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void UpdataProperty(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
        string outputString;
        public string OutputString
        { 
                get { return outputString; }
                set { outputString = value; } 
        }
        string inputString;
        public string InputString
        { 
                get { return inputString; }
                set { inputString = value; } 
        }

        void doInput(string ch)
        {
            if(ch=="=")
            {
                outputString = CalculatorSystem.Calculator(inputString);
                UpdataProperty(outputString);
                UpdataProperty(inputString);
                inputCommand.UpdateCanExecuteChanged();
            }
            else
            {
                inputString += ch;
                UpdataProperty(inputString);
                inputCommand.UpdateCanExecuteChanged();
            }
        }

       bool isNumber(string ch)
       {
            string[] chs = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            return chs.Contains(ch);
       } 
        bool isSymbol(string ch)
       {
            string[] chs = { "+", "-", "*", "/"};
            return chs.Contains(ch);
       }

      bool canInput(string ch)
      {
            string lastCh = null;
            if(inputString!=null)
            {
                lastCh += "" + inputString.LastOrDefault();
                if(isSymbol(lastCh)&&isSymbol(ch))
                {
                    return false;
                }
                if(isSymbol(lastCh) && (ch=="="))
                {
                    return false;
                }
               
            }
        return true;
      }

          DelegateCommand<string> inputCommand = null;
          public ICommand InputCommand
          {
                get
                {
                    if (inputCommand == null)
                        inputCommand = new DelegateCommand<string>(doInput, canInput);
                    return inputCommand;
                }
          }
          CalculatorSystem calculatorSystem;
          public CalculatorSystem CalculatorSystem
          {
            get
            {
                return calculatorSystem;
            }
            set
            {
                calculatorSystem = value;
            }
          }
    }
}
