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
		Point Locmouse;
		int x_loc;
		int y_loc;

		private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class Circle
        {
            public int x;
            public int y;
            public int rad;
            Circle()
            {
                x = 0;
                y = 0;
                rad = 10;
            }
            public Circle(int _x,int _y)
            {
                x = _x;
                y = _y;
            }
            public Circle(Circle a)
            {
                x = a.x;
                y = a.y;
            }
        }
        public class Storage
        {
			public Circle[] storage_circle;
			int count;
			int size;
			Storage(int _size)
			{
				count = 0;
				size = _size;
				storage_circle = new Circle[size];
				for (int i = 0; i < size; i++)
				{
					storage_circle[i] = null;
				}
				//cout <<"Хранилище создано" << endl;
			}
			public void add(Circle a, int i)
			{
				if ((i < size) && (size != count))
				{
					if (storage_circle[i] == null)
					{
						//printf("В хранилище добавлен элемент в ячейку %d\n",i);
						storage_circle[i] = a;
						count += 1;
					}
					else
					{
						//printf(" В этой ячейке уже есть элемент,идем дальше\n");
						int j = i;
						while ((storage_circle[j] != null) && (j < size))
						{
							++j;
						}
						if (storage_circle[j] == null)
						{
							storage_circle[j] = a;
							count++;
							//printf("Добавлен элемент в ячейку%d\n", j);
						}
						else
						{
							expansion(a, j);
						}
					}
				}
				else
				{
					expansion(a, i);
				}
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
					//printf( "Элемент удален из ячейки %d\n",i);
				}
				/*else
					cout << "Невозможно удалить,пуста ячейка под номером " <<i<< endl;*/
			}
			public int Whatcount()
			{
				return count;
			}
			public int Whatsize()
			{
				return size;
			}
		}
		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
		}
		bool flag = false;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
			if (flag)
				e.Graphics.DrawEllipse(new Pen(Brushes.Red, 3), x_loc, y_loc, 100, 100);
		}

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
			 flag = true;
			 x_loc = e.Location.X;
			 y_loc = e.Location.Y;
			 Invalidate();
		}

    }
}
