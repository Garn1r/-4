using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Лаба_4
{
    public partial class Circle
    {
        public int x;
        public int y;
        public bool selected;
        public int Rad = 50;
        public Pen p1=new Pen(Color.Green,3);
        public Circle(MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
        public  bool Get_select()
        {
            return selected;
        }
        public  void SetSelect(bool new_select)
        {
            selected = new_select;
        }
        public  void Draw(PaintEventArgs e)
        {
            if (selected)
            e.Graphics.DrawEllipse(new Pen(Brushes.Blue, 3), x - Rad, y - Rad, 100, 100);
            else
            e.Graphics.DrawEllipse(new Pen(Brushes.Green, 3), x - Rad, y - Rad, 100, 100);
        }
        public  bool CheckIn(MouseEventArgs e)
        {
            if ((x - e.X) * (x - e.X) + (y -e.Y) * (y - e.Y) <= Rad * Rad) return true;
            return false;
        }
    }
}
