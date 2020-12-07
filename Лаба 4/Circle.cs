using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Лаба_4
{
    public partial class Circle: Shape
    {
        public int x;
        public int y;
        public bool selected;
        public int Rad = 50;
        public Circle(MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
        public override bool Get_select()
        {
            return selected;
        }
        public override void SetSelect(bool new_select)
        {
            selected = new_select;
        }
        public override  void Draw_circle(PaintEventArgs e)
        {
            if (selected)
                e.Graphics.DrawEllipse(new Pen(Brushes.Blue, 3), x - Rad, y - Rad, 100, 100);
            else
                e.Graphics.DrawEllipse(new Pen(Brushes.Green, 3), x - Rad, y - Rad, 100, 100);
        }
        public override bool CheckIn(MouseEventArgs e)
        {
            if ((x - e.X) * (x - e.X) + (y -e.Y) * (y - e.Y) <= Rad * Rad) return true;
            return false;
        }
    }
}
