using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
   public partial class Storage
    {
		public Circle[] storage_circle;
		public int count;
		int size;
		public Storage(int _size)
		{
			count = 0;
			size = _size;
			storage_circle = new Circle[size];
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
		public void remove(int x)
		{
			for (int i = x; i < count - 1; ++i)
			{
				storage_circle[i] = storage_circle[i + 1];
			}
			count--;
		}
		public int numbers()
		{
			return count;
		}
	}
}
