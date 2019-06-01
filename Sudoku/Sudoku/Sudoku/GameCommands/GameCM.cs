using Sudoku.Model;
using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Sudoku.GameCommands
{
    class GameCM
    {
        private GameVM gameVM;
        public GameCM(GameVM userVm)
        {
            this.gameVM = userVm;
            gameVM.CurentDimension = 9;
        }

        public void Dimensiune(object obj)
        {
            int dim = Convert.ToInt32(obj);
            gameVM.CurentDimension = dim;
            gameVM.UserGame.CurentDimension = dim;
            Sudoku.View.Sudoku.SudokuWindow.changeView(dim);
        }
        public void Save(object obj)
        {
            gameVM.UserGame.CurentDimension = gameVM.CurentDimension;
            List<List<TextBox>> textBoxList=new List<List<TextBox>>();
            if (gameVM.UserGame.CurentDimension==9)
                textBoxList = Sudoku.View.Table._9x9._9x9Window.getListBox();
            if (gameVM.UserGame.CurentDimension == 4)
                textBoxList = Sudoku.View.Table._4x4._4x4Window.getListBox();
            if (gameVM.UserGame.CurentDimension == 6)
                textBoxList = Sudoku.View.Table._6x6._6x6Window.getListBox();
            gameVM.UserGame.TimeM = Sudoku.View.Sudoku.SudokuWindow.getDel();
            gameVM.UserGame.TimeS = Sudoku.View.Sudoku.SudokuWindow.getDelS();
            gameVM.TimeM = Sudoku.View.Sudoku.SudokuWindow.getDel();
            gameVM.TimeS = Sudoku.View.Sudoku.SudokuWindow.getDelS();
            List<List<int>> matr = new List<List<int>>();
            for (int i = 0; i < gameVM.UserGame.CurentDimension; i++)
            {
                List<int> l = new List<int>();
                for (int j = 0; j < gameVM.UserGame.CurentDimension; j++)
                {

                    if (textBoxList.ElementAt(i).ElementAt(j).Text.Length!=0)
                        l.Add(int.Parse(textBoxList.ElementAt(i).ElementAt(j).Text));
                    else
                        l.Add(0);
                }
                matr.Add(l);          
            }
            gameVM.UserGame.SavedGame = matr; 
            gameVM.serialzation(gameVM.UserGame.PlayerName,gameVM.UserGame);
        }
        public void OpenSave(object obj)
        {
            List<List<TextBox>> textBoxList = new List<List<TextBox>>();
            if (gameVM.UserGame.CurentDimension == 9)
                textBoxList = Sudoku.View.Table._9x9._9x9Window.getListBox();
            if (gameVM.UserGame.CurentDimension == 4)
                textBoxList = Sudoku.View.Table._4x4._4x4Window.getListBox();
            if (gameVM.UserGame.CurentDimension == 6)
                textBoxList = Sudoku.View.Table._6x6._6x6Window.getListBox();
            LinearGradientBrush myBrush = new LinearGradientBrush();
            gameVM.CurentGame = gameVM.UserGame.SavedGame;
            gameVM.SavedGame = gameVM.UserGame.SavedGame;
            gameVM.TimeM = gameVM.UserGame.TimeM;
            gameVM.TimeS = gameVM.UserGame.TimeS;
            Sudoku.View.Sudoku.SudokuWindow.timeLoad(gameVM.TimeM, gameVM.TimeS);
            List<List<int>> matr = new List<List<int>>();
             matr= gameVM.SavedGame;
            for (int i = 0; i < gameVM.UserGame.CurentDimension; i++)
                for (int j = 0; j < gameVM.UserGame.CurentDimension; j++)
                {
                    if (matr.ElementAt(i).ElementAt(j) != 0)
                    {
                        textBoxList.ElementAt(i).ElementAt(j).Text = matr.ElementAt(i).ElementAt(j).ToString();
                        textBoxList.ElementAt(i).ElementAt(j).IsReadOnly = true;
                        textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                    }
                    else
                    {
                        textBoxList.ElementAt(i).ElementAt(j).Text = "";
                        textBoxList.ElementAt(i).ElementAt(j).IsReadOnly = false;
                    }
                }
        }
        public bool VerifPat4()
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._4x4._4x4Window.getListBox();
            int ok = 0;
            for (int i = 0; i < 4; i++)
            {
                List<int> verif = new List<int>();
                for (int z = 0; z <4; z++)
                    verif.Add(0);
                for (int j = 0; j < 4; j++)
                {
                    int nr = gameVM.CurentGame.ElementAt(i).ElementAt(j);
                    if (nr <= 0 || nr > 4)
                    {
                        textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += 1;
                        if (verif[nr - 1] > 1)
                        {
                            textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                            ok = 1;
                        }
                    }
                }

            }
            if (ok == 1)
                return false;
            else
                return true;
        }
        public bool VerifCol4(int i,int j)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.6));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._4x4._4x4Window.getListBox();
            int col = 0;
            List<int> verif = new List<int>();
            for (int z = 0; z < 4; z++)
                verif.Add(0);
            if (j == 0 || j == 2 )
                col = 0;
            if (j == 1 || j == 3 )
                col = 1;   
            int ok = 0;
            for (int index = i / 2; index < 4; index += 2)
            {
                for (int index2 = col; index2 < 4; index2 += 2)
                {
                    int nr = gameVM.CurentGame.ElementAt(index).ElementAt(index2);
                    if (nr < 1 || nr > 4)
                    {
                        textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += verif.ElementAt(nr - 1);
                        if (verif[nr - 1] > 1)
                            textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                    }
                }
            }
            for (int index = 0; index < 4; index++)
            {
                if (verif.ElementAt(index) > 1)
                    return false;
            }
            if (ok == 1)
                return false;
            return true;
        }

        internal void Statistic(object obj)
        {
            if (gameVM.UserGame.Statistici.Count > 0)
            {
                string ni = "Nume Utilizator : " + gameVM.UserGame.PlayerName + "\n" + "Jocuri Incepute : " + gameVM.UserGame.Statistici[0].ToString() + "\nJocuri Castigate : " + gameVM.UserGame.Statistici[1].ToString();
                MessageBox.Show(ni, "Statistici");
            }
        }

        public bool VerifLinie4(int i, int j)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.6));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._4x4._4x4Window.getListBox();
            int col = 0;
            int rand = 0;
            List<int> verif = new List<int>();
            for (int z = 0; z < 4; z++)
                verif.Add(0);
            if (i / 2 == 0)
                rand = 0;
            if (i / 2 == 1)
                rand = 2;
            if (j == 0 || j == 1 )
                col = 0;
            if (j == 2 || j == 3 )
                col = 1;
          
            int ok = 0;
            for (int index = rand; index < 2; index++)
            {
                for (int index2 = col; index2 < col + 2; index2 += 2)
                {
                    int nr = gameVM.CurentGame.ElementAt(index).ElementAt(index2);
                    if (nr < 1 || nr > 4)
                    {
                        textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += verif.ElementAt(nr - 1);
                        if (verif[nr - 1] > 1)
                            textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                    }
                }
            }
            for (int index = 0; index < 4; index++)
            {
                if (verif.ElementAt(index) > 1)
                    return false;
            }
            if (ok == 1)
                return false;
            return true;
        }
        public bool VerifPat6()
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._6x6._6x6Window.getListBox();
            int ok = 0;
            for (int i = 0; i < 6; i++)
            {
                List<int> verif = new List<int>();
                for (int z = 0; z < 6; z++)
                    verif.Add(0);
                for (int j = 0; j < 6; j++)
                {
                    int nr = gameVM.CurentGame.ElementAt(i).ElementAt(j);
                    if (nr <= 0 || nr > 6)
                    {
                        textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += 1;
                        if (verif[nr - 1] > 1)
                        {
                            textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                            ok = 1;
                        }
                    }
                }

            }
            if (ok == 1)
                return false;
            else
                return true;
        }
        public bool VerifCol6(int i, int j)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.6));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._6x6._6x6Window.getListBox();
            int col = 0;
            List<int> verif = new List<int>();
            for (int z = 0; z < 6; z++)
                verif.Add(0);
            if (j == 0 || j == 3)
                col = 0;
            if (j == 1 || j == 4)
                col = 1;
            if (j == 2 || j == 5)
                col = 2;
            int ok = 0;
            for (int index = i / 3; index < 6; index += 3)
            {
                for (int index2 = col; index2 < 6; index2 += 3)
                {
                    int nr = gameVM.CurentGame.ElementAt(index).ElementAt(index2);
                    if (nr < 1 || nr > 6)
                    {
                        textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += verif.ElementAt(nr - 1);
                        if (verif[nr - 1] > 1)
                            textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                    }
                }
            }
            for (int index = 0; index < 6; index++)
            {
                if (verif.ElementAt(index) > 1)
                    return false;
            }
            if (ok == 1)
                return false;
            return true;
        }
        public bool VerifLinie6(int i, int j)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.6));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._6x6._6x6Window.getListBox();
            int col = 0;
            int rand = 0;
            List<int> verif = new List<int>();
            for (int z = 0; z < 6; z++)
                verif.Add(0);
            if (i / 2 == 0)
                rand = 0;
            if (i / 2 == 1)
                rand = 3;
            if (i / 3 == 2)
                rand = 6;
            if (j == 0 || j == 1 || j == 2)
                col = 0;
            if (j == 3 || j == 4 || j == 5)
                col = 1;
            

            int ok = 0;
            for (int index = rand; index < 3; index++)
            {
                for (int index2 = col; index2 < col + 3; index2 += 2)
                {
                    int nr = gameVM.CurentGame.ElementAt(index).ElementAt(index2);
                    if (nr < 1 || nr > 6)
                    {
                        textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += verif.ElementAt(nr - 1);
                        if (verif[nr - 1] > 1)
                            textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                    }
                }
            }
            for (int index = 0; index < 6; index++)
            {
                if (verif.ElementAt(index) > 1)
                    return false;
            }
            if (ok == 1)
                return false;
            return true;
        }
        public bool VerifCol9(int i,int j)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.6));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._9x9._9x9Window.getListBox();
            int col=0;
            List<int> verif = new List<int>();
            for (int z = 0; z < 9; z++)
                verif.Add(0);
            if (j == 0 || j == 3 || j == 6)
                col = 0;
            if (j == 1 || j == 4 || j == 7)
                col = 1;
            if (j == 2 || j == 5 || j == 8)
                col = 2;
            int ok = 0;
            for(int index=i/3; index < 9; index += 3)
            {
                for (int index2= col ; index2 < 9; index2 += 3)
                {
                    int nr = gameVM.CurentGame.ElementAt(index).ElementAt(index2);
                    if (nr < 1 || nr > 9)
                    { textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += verif.ElementAt(nr - 1);
                        if (verif[nr - 1] > 1)
                            textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                    }
                }
            }
            for (int index =0; index < 9; index ++)
            {
                if (verif.ElementAt(index) > 1)
                    return false;
            }
            if (ok == 1)
                return false;
            return true;
        }
       
        public bool VerifPat9()
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._9x9._9x9Window.getListBox();
            int ok = 0;
            for (int i = 0; i < 9; i++)
            {
                List<int> verif = new List<int>();
                for (int z = 0; z < 9; z++)
                    verif.Add(0);
                for (int j = 0; j < 9; j++)
                {
                    int nr = gameVM.CurentGame.ElementAt(i).ElementAt(j);
                    if (nr <= 0 || nr > 9)
                    {
                        textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += 1;
                        if (verif[nr - 1] > 1)
                        {
                            textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                            ok = 1;
                        }
                    }
                }

            }
            if (ok == 1)
                return false;
            else
                return true;

        }
        public bool VerifLinie9(int i, int j)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.6));
            List<List<TextBox>> textBoxList = Sudoku.View.Table._9x9._9x9Window.getListBox();
            int col = 0;
            int rand = 0;
            List<int> verif = new List<int>();
            for (int z = 0; z < 9; z++)
                verif.Add(0);
            if (i / 3==0)
                rand = 0;
            if (i / 3==1)
                rand = 3;
            if (i / 3==2)
                rand = 6;
            if (j == 0 || j == 1 || j == 2)
                col = 0;
            if (j == 3 || j == 4 || j == 5)
                col = 1;
            if (j == 6 || j == 7 || j == 8)
                col = 2;
            int ok = 0;
            for (int index = rand; index < 3; index ++)
            {
                for (int index2 = col; index2 < col+3; index2 += 3)
                {
                    int nr = gameVM.CurentGame.ElementAt(index).ElementAt(index2);
                    if (nr < 1 || nr > 9)
                    {
                        textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                        ok = 1;
                    }
                    else
                    {
                        verif[nr - 1] += verif.ElementAt(nr - 1);
                        if (verif[nr - 1] > 1)
                            textBoxList.ElementAt(index).ElementAt(index2).Background = myBrush;
                    }
                }
            }
            for (int index = 0; index < 9; index++)
            {
                if (verif.ElementAt(index) > 1)
                    return false;
            }
            if (ok == 1)
                return false;
            return true;
        }
        public void NewGame(object obj)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            gameVM.UserGame.Statistici[0] += 1;
            string[] lines= new string[]{};
            
            //Sudoku.View.Sudoku.SudokuWindow.changeView(gameVM.UserGame.CurentDimension);
            List<List<TextBox>> textBoxList = new List<List<TextBox>>();
            if (gameVM.CurentDimension == 9)
            {
                textBoxList = Sudoku.View.Table._9x9._9x9Window.getListBox();
                lines = System.IO.File.ReadAllLines(@"D:\Uni\Second Year\Semestrul 2\MVP\Workspace\Sudoku\Sudoku\Sudoku\9x9.txt");
            }
            if (gameVM.CurentDimension == 4)
            {
                textBoxList = Sudoku.View.Table._4x4._4x4Window.getListBox();
                lines = System.IO.File.ReadAllLines(@"D:\Uni\Second Year\Semestrul 2\MVP\Workspace\Sudoku\Sudoku\Sudoku\4x4.txt");
            }
            if (gameVM.CurentDimension == 6)
            {
                textBoxList = Sudoku.View.Table._6x6._6x6Window.getListBox();
                lines = System.IO.File.ReadAllLines(@"D:\Uni\Second Year\Semestrul 2\MVP\Workspace\Sudoku\Sudoku\Sudoku\6x6.txt");
            }
            //gameVM.Statistici[0] = gameVM.UserGame.Statistici[0];
            //List<List<TextBox>> textBoxList = Sudoku.View.Table._9x9._9x9Window.getListBox();
            //lines = System.IO.File.ReadAllLines(@"D:\repos\Sudoku\Sudoku\9x9.txt");
            Random random = new Random();
            int RandomNumber = random.Next(0, lines.Count());
            List<List<int>> matr = new List<List<int>>();
            var it = lines[RandomNumber];

            if (it.Length!=0)
            {
                    string[] words = it.Split('-');
                    foreach (var it2 in words)
                    {
                        List<int> l = new List<int>();
                        string[] nr = it2.Split(',');
                        foreach (var it3 in nr)
                        {
                            l.Add(Int32.Parse(it3));
                        }
                        matr.Add(l);


                    }
                }
            gameVM.CurentGame = matr;
            for (int i = 0; i < gameVM.CurentDimension; i++)
                for (int j = 0; j < gameVM.CurentDimension; j++)
                {
                    if (matr.ElementAt(i).ElementAt(j) != 0)
                    {
                        
                        textBoxList.ElementAt(i).ElementAt(j).Text = matr.ElementAt(i).ElementAt(j).ToString();
                        textBoxList.ElementAt(i).ElementAt(j).IsReadOnly = true;
                        textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;

                    }
                    else
                    {
                        textBoxList.ElementAt(i).ElementAt(j).Text = "";
                        textBoxList.ElementAt(i).ElementAt(j).IsReadOnly = false;
                        textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                    }
                }
            gameVM.serialzation(gameVM.UserGame.PlayerName, gameVM.UserGame);
        }

        internal void Check(object obj)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();

            List<List<TextBox>> textBoxList = new List<List<TextBox>>();
            if (gameVM.CurentDimension == 9)
            {
                textBoxList = Sudoku.View.Table._9x9._9x9Window.getListBox();
                
            }
            if (gameVM.CurentDimension == 4)
            {
                textBoxList = Sudoku.View.Table._4x4._4x4Window.getListBox();
                
            }
            if (gameVM.CurentDimension == 6)
            {
                textBoxList = Sudoku.View.Table._6x6._6x6Window.getListBox();
                
            }
            List<List<int>> matr = new List<List<int>>();
            for (int i = 0; i < gameVM.CurentDimension; i++)
            {
                List<int> l = new List<int>();
                for (int j = 0; j < gameVM.CurentDimension; j++)
                {
                    textBoxList.ElementAt(i).ElementAt(j).Background = myBrush;
                    if (textBoxList.ElementAt(i).ElementAt(j).Text.Length!=0)
                        l.Add(int.Parse(textBoxList.ElementAt(i).ElementAt(j).Text));
                    else
                        l.Add(0);
                }
                matr.Add(l);
            }
            gameVM.UserGame.CurentGame = matr;
            gameVM.CurentGame = matr;
            
            int ok = 1;
            for (int i = 0; i < gameVM.CurentDimension; i++)
            {
                for (int j = 0; j < gameVM.CurentDimension; j++)
                {
                    if (gameVM.CurentDimension == 9)
                    {
                        if (VerifCol9(i, j) == false || VerifLinie9(i, j) == false || VerifPat9() == false)
                        {
                            ok = 0;
                        }

                    }
                    if (gameVM.CurentDimension == 4)
                    {
                        if (VerifCol4(i, j) == false || VerifLinie4(i, j) == false || VerifPat4() == false)
                        {
                            ok = 0;
                        }

                    }
                    if (gameVM.CurentDimension == 6)
                    {
                        if (VerifCol6(i, j) == false || VerifLinie6(i, j) == false || VerifPat6() == false)
                        {
                            ok = 0;
                        }

                    }
                   
                }
            }
            if(ok==1)
                gameVM.UserGame.Statistici[1] += 1; 
            gameVM.serialzation(gameVM.UserGame.PlayerName, gameVM.UserGame);
        }
    }
}
