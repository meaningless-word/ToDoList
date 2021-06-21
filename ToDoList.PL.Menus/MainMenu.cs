using System;
using System.Collections.Generic;
using ToDoList.BLL.Interface;
using ToDoList.PL.Interface;
using ToDoList.PL.Views;

namespace ToDoList.PL.Menus
{
	public class MainMenu : IMenu
	{
		List<string> menuItems { get; }
		private IToDoListLogic _toDoListLogic;

		public MainMenu(IToDoListLogic toDoListLogic)
		{
			_toDoListLogic = toDoListLogic;

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
				MenuView menu = new MenuView(menuItems);
				menu.Show();
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							TaskListMenu taskListMenu = new TaskListMenu(_toDoListLogic);
							taskListMenu.Choose();
							break;
						}
					case "2":
						{
							TaskProcessingMenu taskProcessingMenu = new TaskProcessingMenu(_toDoListLogic);
							taskProcessingMenu.Choose();
							break;
						}
					case "3":
						{
							TaskFindingMenu taskFindingMenu = new TaskFindingMenu(_toDoListLogic);
							taskFindingMenu.Choose();
							break;
						}
				}
			}
		}
	}
}
