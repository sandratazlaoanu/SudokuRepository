using Sudoku.View.Table;
using Sudoku.ViewModel;
using Sudoku.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sudoku.View
{
    /// <summary>
    /// Interaction logic for Sudoku.xaml
    /// </summary>
    
    public partial class Sudoku : Window
    {
        public object DisplayViewModel;
        private int currentView;
        public int CurrentView {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;

            }
        }
        public string NameN { get; set; }
        public static Sudoku SudokuWindow;
        public Sudoku(string nume)
        {
            NameN = nume;
            SudokuWindow = this;
            
            DisplayViewModel = new _9x9();
            InitializeComponent();
            gridSDK.Children.Clear();
            gridSDK.Children.Add(new _9x9());
            currentView = 1;
            labelName.Content = NameN.ToString();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
          

        }
        public void changeView(int i)
        {
            if(i==9)
            {
                DisplayViewModel = new _9x9();
                gridSDK.Children.Clear();
                gridSDK.Children.Add(new _9x9());
            }
            if (i == 4)
            {
                DisplayViewModel = new _4x4();
                gridSDK.Children.Clear();
                gridSDK.Children.Add(new _4x4());
            }
            if (i == 6)
            {
                DisplayViewModel = new _6x6();
                gridSDK.Children.Clear();
                gridSDK.Children.Add(new _6x6());
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
        public string name()
        {

            return NameN;

        }
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public double delay = 4;
        public double delaySec = 240;
        private DateTime deadline;
        private DateTime deadlineMin;
        public void timeLoad(double del, double del2)
        {
            delay = del;
            delaySec = del2;
            deadline = DateTime.Now.AddMinutes(delay);
            int secondsRemaining = (deadline - DateTime.Now).Seconds;
            int minutesRemaining = (deadline - DateTime.Now).Minutes;
            
                if (secondsRemaining >= 10)
                    labelTime.Content = minutesRemaining.ToString() + " : " + secondsRemaining.ToString();
                else
                    labelTime.Content = minutesRemaining.ToString() + " : 0" + secondsRemaining.ToString();
            
        }
        private void StartTimer()
        {
            //se seteaza momentul in care trebuie sa se opreaqsca timer-ul
            //se adauga la data curenta un numar de secunde egal cu delay-ul
            //mai exact, peste 20 de secunde, trebuie sa se opreasca timer-ul
            //se pot adauga si minute, ore, etc... la data curenta
            deadline = DateTime.Now.AddSeconds(delaySec);
            deadlineMin =DateTime.Now.AddMinutes(delay);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int secondsRemaining = (deadline - DateTime.Now).Seconds;
            int minutesRemaining = (deadlineMin - DateTime.Now).Minutes;
            if (secondsRemaining == 0 && minutesRemaining==0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer.IsEnabled = false;
                MessageBox.Show("Time has expired!");
                delay = 4;
                
            }
            else
            {
                if(secondsRemaining>=10)
                    labelTime.Content = minutesRemaining.ToString()+" : "+ secondsRemaining.ToString();
                else
                    labelTime.Content = minutesRemaining.ToString() + " : 0" + secondsRemaining.ToString();
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //la fiecare pornire a timer-ului se reseteaza deadline-ul
            //delay = 4;
            StartTimer();
        }

        public void btnStop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            //de fiecare data cand oprim timer-ul vom reseta si delay-ul,
            //dar si deadline-ul, ca sa nu treaca pe negativ cand a ajuns la 
            //final si o luam de la capat
            delay = (deadline - DateTime.Now).Minutes;
            delaySec = (deadline - DateTime.Now).Seconds+delay*60;
           // deadline = DateTime.Now.AddMinutes(delay);
            deadline = DateTime.Now.AddSeconds(delaySec);
        }

        public double getDel()
        {
            dispatcherTimer.Stop();
            //de fiecare data cand oprim timer-ul vom reseta si delay-ul,
            //dar si deadline-ul, ca sa nu treaca pe negativ cand a ajuns la 
            //final si o luam de la capat
            delay = (deadline - DateTime.Now).Minutes;
            deadline = DateTime.Now.AddMinutes(delay);
            return delay;
        }
        public double getDelS()
        {
            dispatcherTimer.Stop();
            //de fiecare data cand oprim timer-ul vom reseta si delay-ul,
            //dar si deadline-ul, ca sa nu treaca pe negativ cand a ajuns la 
            //final si o luam de la capat
            delaySec = (deadline - DateTime.Now).Seconds + delay * 60;
            deadline = DateTime.Now.AddMinutes(delay);
            return delaySec;
        }

        private void ResetTime_Click(object sender, RoutedEventArgs e)
        {
            delay = 4;
            delaySec = 240;
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            string ni = "Stefan Iacob\n10LF372 \nstefan.iacob@student.com";
            MessageBox.Show(ni, "About");
        }
    }
}
