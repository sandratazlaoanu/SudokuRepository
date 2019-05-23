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
    /// Interaction logic for _9x9.xaml
    /// </summary>
    public partial class _9x9 : UserControl
    {
        public static _9x9 _9x9Window;
        public List<List<TextBox>> textBoxList;
        public _9x9()
        {
           InitializeComponent();
            _9x9Window = this;
        }
        public void setTextBox(List<List<TextBox>> x)
        {
            for(int i=0;i<9;i++)
                for(int j=0;j<9;j++)
                    if(x.ElementAt(i).ElementAt(j).Text=="")
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
            List<List<TextBox>> boxList=new List<List<TextBox>> ();
            List<TextBox> l1 = new List<TextBox>();
            l1.Add(this.tb00);
            l1.Add(this.tb01);
            l1.Add(this.tb02);
            l1.Add(this.tb10);
            l1.Add(this.tb11);
            l1.Add(this.tb12);
            l1.Add(this.tb20);
            l1.Add(this.tb21);
            l1.Add(this.tb22);
            boxList.Add(l1);

            List<TextBox> l2 = new List<TextBox>();
            l2.Add(this.tb03);
            l2.Add(this.tb04);
            l2.Add(this.tb05);
            l2.Add(this.tb13);
            l2.Add(this.tb14);
            l2.Add(this.tb15);
            l2.Add(this.tb23);
            l2.Add(this.tb24);
            l2.Add(this.tb25);
            boxList.Add(l2);

            List<TextBox> l3 = new List<TextBox>();
            l3.Add(this.tb06);
            l3.Add(this.tb07);
            l3.Add(this.tb08);
            l3.Add(this.tb16);
            l3.Add(this.tb17);
            l3.Add(this.tb18);
            l3.Add(this.tb26);
            l3.Add(this.tb27);
            l3.Add(this.tb28);
            boxList.Add(l3);

            List<TextBox> l4 = new List<TextBox>();
            l4.Add(this.tb30);
            l4.Add(this.tb31);
            l4.Add(this.tb32);
            l4.Add(this.tb40);
            l4.Add(this.tb41);
            l4.Add(this.tb42);
            l4.Add(this.tb50);
            l4.Add(this.tb51);
            l4.Add(this.tb52);
            boxList.Add(l4);

            List<TextBox> l5 = new List<TextBox>();
            l5.Add(this.tb33);
            l5.Add(this.tb34);
            l5.Add(this.tb35);
            l5.Add(this.tb43);
            l5.Add(this.tb44);
            l5.Add(this.tb45);
            l5.Add(this.tb53);
            l5.Add(this.tb54);
            l5.Add(this.tb55);
            boxList.Add(l5);

            List<TextBox> l6 = new List<TextBox>();
            l6.Add(this.tb36);
            l6.Add(this.tb37);
            l6.Add(this.tb38);
            l6.Add(this.tb46);
            l6.Add(this.tb47);
            l6.Add(this.tb48);
            l6.Add(this.tb56);
            l6.Add(this.tb57);
            l6.Add(this.tb58);
            boxList.Add(l6);

            List<TextBox> l7 = new List<TextBox>();
            l7.Add(this.tb60);
            l7.Add(this.tb61);
            l7.Add(this.tb62);
            l7.Add(this.tb70);
            l7.Add(this.tb71);
            l7.Add(this.tb72);
            l7.Add(this.tb80);
            l7.Add(this.tb81);
            l7.Add(this.tb82);
            boxList.Add(l7);

            List<TextBox> l8 = new List<TextBox>();
            l8.Add(this.tb63);
            l8.Add(this.tb64);
            l8.Add(this.tb65);
            l8.Add(this.tb73);
            l8.Add(this.tb74);
            l8.Add(this.tb75);
            l8.Add(this.tb83);
            l8.Add(this.tb84);
            l8.Add(this.tb85);
            boxList.Add(l8);

            List<TextBox> l9 = new List<TextBox>();
            l9.Add(this.tb66);
            l9.Add(this.tb67);
            l9.Add(this.tb68);
            l9.Add(this.tb76);
            l9.Add(this.tb77);
            l9.Add(this.tb78);
            l9.Add(this.tb86);
            l9.Add(this.tb87);
            l9.Add(this.tb88);
            boxList.Add(l9);
            textBoxList = boxList;
            return boxList;

        }
    }
}
