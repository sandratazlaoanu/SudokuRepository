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
    class UserViewModel : BaseUserVM
    {
        private Operation operation;
        private ObservableCollection<User> userList;
        public UserViewModel()
        {
            userList = new ObservableCollection<User>();
            string[] lines = System.IO.File.ReadAllLines(@"D:\\Uni\\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\jucatori.txt");
            foreach (var it in lines)
            {
                if (it != "")
                {
                    string[] words = it.Split(',');
                    userList.Add(new User() { Name = words[0], ImgPath = words[1] });
                }
            }
            operation = new Operation(this);
        }
        private bool canExecuteCommand = true;
        public ObservableCollection<User> User
        {
            get { return userList; }
            set { userList = value;
                OnPropertyChanged("User");
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
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new Updater(operation.Delete, param => CanExecuteCommand);
                }
                return deleteCommand;
            }
        }
        private string nameN;
        public string NameN
        {
            get { return nameN; }
            set
            {
                nameN = value;
                canExecuteCommand = Validator.CanExecuteOperation(NameN);
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
        private ICommand newCommand;
        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new Updater(operation.New, param => CanExecuteCommand);
                }
                return newCommand;
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
        private ICommand startCommand;
        public ICommand StartCommand
        {
            get
            {
                if (startCommand == null)
                {
                    startCommand = new Updater(operation.Start, param => CanExecuteCommand);
                }
                return startCommand;
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
