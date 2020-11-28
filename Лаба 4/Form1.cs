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
				st.get(i).Draw_circle(e);
			}
		}
		bool q;
		private void data_MouseClick(object sender, MouseEventArgs e)
		{
			if (checkB.Checked == true)
			{
				st.add(new Circle(e));
				data.Invalidate();
			}
			else
            {
				int x = 1;
				for(int i=st.count-1;i>=0;--i)
                {
					if (q != true)
						st.get(i).SetSelected(false);
					if(st.get(i).Boom(e)&&x==1)
                    {
						x = 0;
						st.get(i).SetSelected(true);
                    }
                }
				data.Invalidate();
            }
		}
		public class Circle
        {
            public int x;
            public int y;
            public int rad;
			public bool selected;
            public Circle(MouseEventArgs e)
            {
                x = e.X;
                y = e.Y;
            }
            public Circle(Circle a)
            {
                x = a.x;
                y = a.y;
            }
			public  bool Select(bool x)
            {
				return selected;
            }
			public void SetSelected(bool x)
            {
				selected = x;
            }
			public void Draw_circle(PaintEventArgs e)
            {
				if (selected)
					e.Graphics.DrawEllipse(new Pen(Brushes.Blue,3), x - 50, y - 50, 100, 100);
				else
					e.Graphics.DrawEllipse(new Pen(Brushes.Red, 3), x - 50, y - 50, 100, 100);
			}
			public  bool Boom(MouseEventArgs e)
            {
				if (Math.Sqrt(Math.Pow(e.X-x,2)+Math.Pow(e.Y-y,2))<=50)
                {
					return true;
                }
				return false;
            }
        }
        public class Storage
        {
			public Circle[] storage_circle;
			public int count;
			int size;
			public Storage(int _size)
			{
				count = 0;
				size = _size;
				storage_circle = new Circle[size];
				for (int i = 0; i < size; i++)
				{
					storage_circle[i] = null;
				}
			}
			public void add(Circle a)
			{
				storage_circle[count] = a;
				count++; ;
			}
			public Circle get(int x)
            {
				return storage_circle[x];
            }
			public void expansion(Circle a, int new_size)
			{
				//printf("Превышен размер хранилища,увеличиваем его\n");
				Circle[] storage_circle_new = new Circle[size + new_size]; 
				for (int i = 0; i < size; i++)
				{
					storage_circle_new[i] = storage_circle[i];
				}
				for (int j = size; j < size + new_size; j++)
				{
					storage_circle_new[j] = null;
				}
				storage_circle = storage_circle_new;
				storage_circle_new[new_size] = a;
				count += 1;
				size = size + new_size;
				//printf("Хранилище увеличено на %d и добавлен элемент в ячейку %d\n", new_size,new_size);
			}
			public void remove(int i)
			{
				if ((i <= size) && (storage_circle[i] != null) && (count > 0))
				{
					storage_circle[i] = null;
					count--;
				}
			}

		}

    }
}
