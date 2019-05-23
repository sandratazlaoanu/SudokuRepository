using Sudoku.Command;
using Sudoku.GameCommands;
using Sudoku.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Sudoku.ViewModel
{
    class GameVM : BaseUserVM
    {
        private GameCM gameOP;
        private Game userGame= new Game();
       
       
        public GameVM()
        {
            userGame = new Game();
            string name = "name";
            name= View.Sudoku.SudokuWindow.name();
            if (File.Exists(@"D:\Uni\Second Year\\Semestrul 2\\Help\\MVP\\Sudoku\\Sudoku\\Sudoku\\Jucatori" + name + ".xml"))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(Game));
                FileStream file = new FileStream(@"D:\Uni\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\Sudoku\\Jucatori" + name + ".xml", FileMode.Open);
                var entity = xmlser.Deserialize(file);
                file.Dispose();
                userGame = entity as Game;
            }
            else
            {
 
                XmlSerializer xmlser = new XmlSerializer(typeof(Game));
                Game newuser = new Game(name);
                newuser.PlayerName = name;
                FileStream fileStr = new FileStream(@"D:\\Uni\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\Sudoku\\Jucatori\\" + name + ".xml", FileMode.Create);
                xmlser.Serialize(fileStr, newuser);
                fileStr.Dispose();

            }
            gameOP = new GameCM(this);

        }
        private string playerName;
        private int curentDimension;
        private double timeM;
        private double timeS;
        private List<List<int>> savedGame;
        private List<List<int>> curentGame;
        private List<int> statistici;

        private bool canExecuteCommand = true;
        public void serialzation(string name, Game user)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Game));
            FileStream fileStr = new FileStream(@"D:\\Uni\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\Sudoku\\Jucatori\\" + user.PlayerName + ".xml", FileMode.Create);
            xmlser.Serialize(fileStr, user);
            fileStr.Dispose();
        }
        public Game UserGame
        {
            get
            {
                return userGame;
            }
            set
            {
                userGame = value;
                OnPropertyChanged("userGame");
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
        public double TimeM
        {
            get
            {
                return timeM;
            }
            set
            {
                timeM = value;
                OnPropertyChanged("timeM");
            }
        }
        public double TimeS
        {
            get
            {
                return timeS;
            }
            set
            {
                timeS = value;
                OnPropertyChanged("timeS");
            }
        }
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
                OnPropertyChanged("Name");
            }
        }
        public int CurentDimension
        {
            get
            {
                return curentDimension;
            }
            set
            {
                curentDimension = value;
                OnPropertyChanged("Dimensiune");
            }
        }

        public List<int> Statistici
        {
            get
            {
                return statistici;
            }
            set
            {
                statistici = value;
                OnPropertyChanged("Statistici");
            }
        }
        public List<List<int>> SavedGame
        {
            get
            {
                return savedGame;
            }
            set
            {
                savedGame = value;
                OnPropertyChanged("SavedGame");
            }
        }
        public List<List<int>> CurentGame
        {
            get
            {
                return curentGame;
            }
            set
            {
                curentGame = value;
                OnPropertyChanged("CurentGame");
            }
        }
        
        private ICommand dimensionCommand;
        public ICommand DimensionCommand
        {
            get
            {
                if (dimensionCommand == null)
                {
                    dimensionCommand = new Updater(gameOP.Dimensiune, param => CanExecuteCommand);
                }
                return dimensionCommand;
            }
        }
        private ICommand newGameCommand;
        public ICommand NewGameCommand
        {
            get
            {
                if (newGameCommand == null)
                {
                    newGameCommand = new Updater(gameOP.NewGame, param => CanExecuteCommand);
                }
                return newGameCommand;
            }
        }
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new Updater(gameOP.Save, param => CanExecuteCommand);
                }
                return saveCommand;
            }
        }
        private ICommand openSaveCommand;
        public ICommand OpenSaveCommand
        {
            get
            {
                if (openSaveCommand == null)
                {
                    openSaveCommand = new Updater(gameOP.OpenSave, param => CanExecuteCommand);
                }
                return openSaveCommand;
            }
        }
        private ICommand checkCommand;
        public ICommand CheckCommand
        {
            get
            {
                if (checkCommand == null)
                {
                    checkCommand = new Updater(gameOP.Check, param => CanExecuteCommand);
                }
                return checkCommand;
            }
        }
        private ICommand statisticiCommand;
        public ICommand StatisticiCommand
        {
            get
            {
                if (statisticiCommand == null)
                {
                    statisticiCommand = new Updater(gameOP.Statistic, param => CanExecuteCommand);
                }
                return statisticiCommand;
            }
        }
    }
}
