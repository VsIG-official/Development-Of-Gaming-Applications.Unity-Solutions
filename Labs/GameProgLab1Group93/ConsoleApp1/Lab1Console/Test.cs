using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Console
{
	internal class Test
	{
		public int MyProperty { get; set; }

		public Test()
		{
		}

		public Test(int xValue)
		{
			MyProperty = xValue;
		}

		public void Print()
		{
			Console.WriteLine(MyProperty);
		}
	}
}
