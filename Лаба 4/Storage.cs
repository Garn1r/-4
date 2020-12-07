using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
   public partial class Storage
    {
		public Shape[] storage_;
		public int count;
		int size;
		public Storage(int _size)
		{
			count = 0;
			size = _size;
			storage_ = new Shape[size];
		}
		public void add(Shape a)
		{
			storage_[count] = a;
			count++; ;
		}
		public Shape get(int x)
		{
			return storage_[x];
		}

		public void remove(int x)
		{
			for (int i = x; i < count - 1; ++i)
			{
				storage_[i] = storage_[i + 1];
			}
			count--;
		}
		public int numbers()
		{
			return count;
		}
	}
}
