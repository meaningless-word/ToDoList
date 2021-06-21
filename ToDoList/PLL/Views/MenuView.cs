using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.PLL.Views
{
	public class MenuView
	{
		public static void Show(List<string> menuItems)
		{
			ConsoleColor originalColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Cyan;
			int width = menuItems.Select(x => x.Length).Max() + 5;
			for (int i = 0; i < menuItems.Count; i++)
				Console.WriteLine(String.Format("{0} {1}", menuItems[i].PadRight(width, '.'), i + 1));
			Console.ForegroundColor = originalColor;
			Console.WriteLine(String.Format("{0} {1}", "Выход".PadRight(width, '.'), 0));
		}
	}
}
