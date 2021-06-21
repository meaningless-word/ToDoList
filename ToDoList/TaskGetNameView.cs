using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.PLL.Views
{
	public class TaskGetNameView
	{
		public string Show()
		{
			Console.WriteLine("Введите");
			Console.Write("фрагмент текста для поиска: ");
			string part = Console.ReadLine();
			return part;
		}
	}
}
