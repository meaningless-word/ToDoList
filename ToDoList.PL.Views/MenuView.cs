using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.PL.Interface;

namespace ToDoList.PL.Views
{
	public class MenuView : IView
	{
		private List<string> _menuItems;

		public MenuView (List<string> menuItems)
		{
			_menuItems = menuItems;
		}

		public void Show()
		{
			ConsoleColor originalColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Cyan;
			int width = _menuItems.Select(x => x.Length).Max() + 5;
			for (int i = 0; i < _menuItems.Count; i++)
				Console.WriteLine(String.Format("{0} {1}", _menuItems[i].PadRight(width, '.'), i + 1));
			Console.ForegroundColor = originalColor;
			Console.WriteLine(String.Format("{0} {1}", "Выход".PadRight(width, '.'), 0));
		}
	}
}
