using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Common;
using ToDoList.BLL.Models;
using ToDoList.PLL.Common;

namespace ToDoList.PLL.Views
{
	public class MainMenu : IMenu
	{
		List<string> menuItems { get; }
		private IToDoListBLL _toDoListBLL;

		public MainMenu(IToDoListBLL toDoListBLL)
		{
			_toDoListBLL = toDoListBLL;

			menuItems = new List<string>()
			{
				"Список задач",
				"Действия",
				"Поиск"
			};
		}
		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Задачи");
				MenuView.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							Program.taskListMenu.Choose();
							break;
						}
					case "2":
						{
							Program.taskProcessingMenu.Choose();
							break;
						}
					case "3":
						{
							Program.taskFindingMenu.Choose();
							break;
						}
				}
			}
		}
	}
}
