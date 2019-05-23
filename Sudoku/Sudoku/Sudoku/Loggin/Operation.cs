using Sudoku.Model;
using Sudoku.View;
using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku.Loggin
{
    class Operation
    {
        private UserViewModel userVM;
      

        public Operation(UserViewModel userVm)
        {
            this.userVM = userVm;
        }



        public void Delete(object param)
        {
            String ss = param as String;
            if (ss != null)
            {
                Debug.WriteLine("debug");
                for (int it = 0; it < userVM.User.Count(); ++it)
                {
                    if (userVM.User.ElementAt(it).Name == ss)
                        userVM.User.RemoveAt(it);
                }
                if (File.Exists(@"D:\\Uni\\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\jucatori.txt"))
                {
                    File.Delete(@"D:\\Uni\\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\jucatori.txt");
                }
                if (File.Exists(@"D:\\Uni\\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\Sudoku\\" + ss + ".xml"))
                {
                    File.Delete(@"D:\\Uni\\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\Sudoku\\" + ss + ".xml");
                }
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Append text to an existing file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine("D:\\Uni\\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\", "jucatori.txt"), true))
                {
                    foreach (var it in userVM.User)
                        outputFile.WriteLine(it.Name + "," + it.ImgPath);
                }
            }
            else
                MessageBox.Show("Player nu a fost selectat", "Error");
        }
        public void New(object param)
        {
            String ss = param as String;
            Debug.WriteLine("dddddddddddddd");
            NewUser user = new NewUser();
            user.ShowDialog();
            userVM.User = new ObservableCollection<User>();
            string[] lines = System.IO.File.ReadAllLines(@"D:\\Uni\\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku\\jucatori.txt");
            foreach (var it in lines)
            {
                if (it != "")
                {
                    string[] words = it.Split(',');
                    userVM.User.Add(new User() { Name = words[0], ImgPath = words[1] });
                }
            }
            // calculatorVM.Output = calcVM.FirstValue + calcVM.SecondValue;
        }
        public void Start(object param)
        {

            String ss = param as String;
            if (ss != null)
            {
                View.Sudoku user = new View.Sudoku(ss);
                user.ShowDialog();
            }
            else
                MessageBox.Show("Player nu a fost selectat", "Error");

            // calculatorVM.Output = calcVM.FirstValue + calcVM.SecondValue;
        }
        public void Save(object param)
        {

            UserViewModel ss = param as UserViewModel;
            User us = new User() { Name = userVM.NameN, ImgPath = userVM.ImgPathN };
            Debug.WriteLine("dddddddddddddd");
            if (userVM.NameN != null && userVM.ImgPathN != null)
            {
                userVM.User.Add(us);
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Append text to an existing file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine("D:\\Uni\\Second Year\\Semestrul 2\\MVP\\Workspace\\Sudoku\\Sudoku", "jucatori.txt"), true))
                {
                    outputFile.WriteLine(us.Name + "," + us.ImgPath);
                }
            }
            else
                MessageBox.Show("Nume sau poza lipsa", "Error");
            // calculatorVM.Output = calcVM.FirstValue + calcVM.SecondValue;
        }
        public void Img(object param)
        {

            String ss = param as String;
            userVM.ImgPathN = ss;
            // calculatorVM.Output = calcVM.FirstValue + calcVM.SecondValue;
        }
    }
}
