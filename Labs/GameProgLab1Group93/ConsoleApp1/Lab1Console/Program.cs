using System;

namespace Lab1Console
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Test test = new Test();
			test.Print();

			Test[] testArray =
			{
				new Test(),
				new Test(2),
				new Test(4),
			};


		}
	}
}
