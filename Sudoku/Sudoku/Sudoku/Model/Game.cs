using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Model
{
    public class Game : INotifyPropertyChanged
    {
        private string playerName;
        private int curentDimension;
        private int Dimension;
        private double timeM;
        private double timeS;
        private List<List<int>> savedGame;
        private List<List<int>> curentGame;
        private List<int> statistici;

        public event PropertyChangedEventHandler PropertyChanged;
        private List<List<int>> SetZero()
        {
            List<List<int>> x=new List<List<int>>();
            
            for (int j = 0; j < 9; j++)
            {
                List<int> z = new List<int>();
                for (int i = 0; i < 9; i++)
                    z.Add(0);
                x.Add(z);

            }
            return x;
        }
        public Game()
        {
            savedGame = new List<List<int>>();
            curentGame = new List<List<int>>();
            statistici = new List<int>();
            playerName = "Name";
            timeM = 4;
            timeS = 240;
            curentDimension = 9;
            savedGame = SetZero();
            curentGame = SetZero();
            
        }
        public Game(string i)
        {
            savedGame = new List<List<int>>();
            curentGame = new List<List<int>>();
            statistici = new List<int>();
            playerName = i;
            timeM = 4;
            timeS = 240;
            curentDimension = 9;
            savedGame = SetZero();
            curentGame = SetZero();
            statistici.Add(0);
            statistici.Add(0);
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        public double TimeM
        {
            get
            {
                return timeM;
            }
            set
            {
                timeM = value;
                OnPropertyChanged("TimeM");
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
                OnPropertyChanged("TimeS");
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
    }
}
