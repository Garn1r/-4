using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
		Storage st = new Storage(100);
		private void data_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < st.count; ++i)
			{
				st.get(i).Draw(e);
			}
		}
		bool ctrl_down;
		private void data_KeyUp(object sender, KeyEventArgs e)
		{
			ctrl_down = e.Control;
		}
		private void data_MouseClick(object sender, MouseEventArgs e)
		{
			if (checkB.Checked == true)
			{
				st.add(new Circle(e));
				data.Invalidate();
			}
			else
            {
				bool flag = false;
				for(int i=st.count-1;i>=0;--i)
                {
					if (ctrl_down != true)
						st.get(i).SetSelect(false);
					if(st.get(i).CheckIn(e)&&!flag)
                    {
						flag = true; 
						st.get(i).SetSelect(true);
                    }
                }
				data.Invalidate();
            }
		}
		private void data_KeyDown(object sender, KeyEventArgs e)
		{
			ctrl_down = e.Control;
			if (e.KeyCode.ToString() == "Delete")
			{
				int count= st.count;
				int i = 0;
				int j = 0;
				while (i<count)
                {
					if(st.get(j).Get_select())
                    {
						st.remove(j);
						--j;
					}
					++i;
					++j;
                }
				data.Invalidate();
			}
		}

    }
}
