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
		bool ctrl_down;
		private void data_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < st.count; i++)
			{
				st.get(i).Draw(e);
			}
		}
		private void data_KeyUp(object sender, KeyEventArgs e)
		{
			ctrl_down = e.Control;
		}
		private void data_MouseClick(object sender, MouseEventArgs e)
		{
			if (checkB.Checked == true)
			{
				st.set(new Circle(e));
				data.Invalidate();
			}
			else
            {
				bool flag = false;//для того чтобы выделять один объект а не несколько
				for(int i=st.count-1;i>=0;i--)
                {
					if (ctrl_down == false)
						st.get(i).SetSelect(false);
					if(st.get(i).CheckIn(e)&&flag==false)
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
						st.del(j);
						j--;
					}
					i++;
					j++;
                }
				data.Invalidate();
			}
		}

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
