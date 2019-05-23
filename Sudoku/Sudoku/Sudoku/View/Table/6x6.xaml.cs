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

namespace Sudoku.View.Table
{
    /// <summary>
    /// Interaction logic for _6x6.xaml
    /// </summary>
    public partial class _6x6 : UserControl
    {
        public static _6x6 _6x6Window;
        public List<List<TextBox>> textBoxList;
        public _6x6()
        {
            InitializeComponent();
            _6x6Window = this;
        }
        public void setTextBox(List<List<TextBox>> x)
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
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
            l1.Add(this.tb02);
            l1.Add(this.tb10);
            l1.Add(this.tb11);
            l1.Add(this.tb12);
            
            boxList.Add(l1);

            List<TextBox> l2 = new List<TextBox>();
            l2.Add(this.tb03);
            l2.Add(this.tb04);
            l2.Add(this.tb05);
            l2.Add(this.tb13);
            l2.Add(this.tb14);
            l2.Add(this.tb15);
            boxList.Add(l2);

            List<TextBox> l3 = new List<TextBox>();
            l3.Add(this.tb20);
            l3.Add(this.tb21);
            l3.Add(this.tb22);
            l3.Add(this.tb30);
            l3.Add(this.tb31);
            l3.Add(this.tb32);
            boxList.Add(l3);

            List<TextBox> l4 = new List<TextBox>();
            l4.Add(this.tb23);
            l4.Add(this.tb24);
            l4.Add(this.tb25);
            l4.Add(this.tb33);
            l4.Add(this.tb34);
            l4.Add(this.tb35);
            boxList.Add(l4);

            List<TextBox> l5 = new List<TextBox>();
            l5.Add(this.tb40);
            l5.Add(this.tb41);
            l5.Add(this.tb42);
            l5.Add(this.tb50);
            l5.Add(this.tb51);
            l5.Add(this.tb52);
            boxList.Add(l5);

            List<TextBox> l6 = new List<TextBox>();
            l6.Add(this.tb43);
            l6.Add(this.tb44);
            l6.Add(this.tb45);
            l6.Add(this.tb53);
            l6.Add(this.tb54);
            l6.Add(this.tb55);  
            boxList.Add(l6);

            textBoxList = boxList;
            return boxList;

        }
    }
}
