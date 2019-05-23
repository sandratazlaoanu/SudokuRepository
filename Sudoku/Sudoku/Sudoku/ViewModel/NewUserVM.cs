using Sudoku.Command;
using Sudoku.Loggin;
using Sudoku.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sudoku.ViewModel
{
    class NewUserVM
    {
        private Operation operation;
        public NewUserVM()
        {
            operation = new Operation(this);
        }
        private bool canExecuteCommand = true;

        private string nameN;
        public string NameN
        {
            get { return nameN; }
            set
            {
                nameN = value;
                //OnPropertyChanged("User");
            }
        }
        private string imgPathN;
        public string ImgPathN
        {
            get { return imgPathN; }
            set
            {
                imgPathN = value;
                //OnPropertyChanged("User");
            }
        }
        public bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }

            set
            {
                if (canExecuteCommand == value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new Updater(operation.Save, param => CanExecuteCommand);
                }
                return saveCommand;
            }
        }
        private ICommand imageCommand;
        public ICommand ImageCommand
        {
            get
            {
                if (imageCommand == null)
                {
                    imageCommand = new Updater(operation.Img, param => CanExecuteCommand);
                }
                return imageCommand;
            }
        }
    }
}
