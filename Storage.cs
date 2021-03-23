using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
   public partial class Storage
    {
		public Circle[] storage_;
		public int count;
		public int _size;

		public Storage(int size)
		{
			count = 0;
			_size = size;
			storage_ = new Circle[_size];
		}
		public void add(Circle a)
		{
			storage_[count] = a;
			count++; ;
		}
		public Circle get(int x)
		{
			return storage_[x];
		}

		public void del(int x)
		{
			for (int i = x; i < count - 1; i++)
				storage_[i] = storage_[i + 1];
			count--;
		}
	}
}
