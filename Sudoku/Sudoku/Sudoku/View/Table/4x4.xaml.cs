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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku.View.Table
{
    /// <summary>
    /// Interaction logic for _4x4.xaml
    /// </summary>
    public partial class _4x4 : UserControl
    {
        public static _4x4 _4x4Window;
        public List<List<TextBox>> textBoxList;
        public _4x4()
        {
            InitializeComponent();
            _4x4Window = this;
        }
        public void setTextBox(List<List<TextBox>> x)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (x.ElementAt(i).ElementAt(j).Text == "")
                    {
                        textBoxList.ElementAt(i).ElementAt(j).Text = "";
                        textBoxList.ElementAt(i).ElementAt(j).IsReadOnly = true;
                    }
                    else
                    {
                        textBoxList.ElementAt(i).ElementAt(j).Text = x.ElementAt(i).ElementAt(j).Text;
                        textBoxList.ElementAt(i).ElementAt(j).IsReadOnly = true;
                    }
        }
        public List<List<TextBox>> getListBox()
        {
            List<List<TextBox>> boxList = new List<List<TextBox>>();
            List<TextBox> l1 = new List<TextBox>();
            l1.Add(this.tb00);
            l1.Add(this.tb01);
            l1.Add(this.tb10);
            l1.Add(this.tb11);
            boxList.Add(l1);

            List<TextBox> l2 = new List<TextBox>();
            l2.Add(this.tb02);
            l2.Add(this.tb03);
            l2.Add(this.tb12);
            l2.Add(this.tb13);
            boxList.Add(l2);

            List<TextBox> l3 = new List<TextBox>();
            l3.Add(this.tb20);
            l3.Add(this.tb21);
            l3.Add(this.tb30);
            l3.Add(this.tb31);
            boxList.Add(l3);

            List<TextBox> l4 = new List<TextBox>();
            l4.Add(this.tb22);
            l4.Add(this.tb23);
            l4.Add(this.tb32);
            l4.Add(this.tb33);
            boxList.Add(l4);
            

            textBoxList = boxList;
            return boxList;

        }
    }
}
