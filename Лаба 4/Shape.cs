using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Лаба_4
{
    public  abstract partial class Shape
    {
        public abstract bool Get_select();
        public abstract void SetSelect(bool new_select);
        public abstract void Draw(PaintEventArgs e);
        public abstract bool CheckIn(MouseEventArgs e);
    }
}
