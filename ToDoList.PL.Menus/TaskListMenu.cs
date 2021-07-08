using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.BLL.Interface;
using ToDoList.PL.Interface;
using ToDoList.PL.Views;

namespace ToDoList.PL.Menus
{
	public class TaskListMenu : IMenu
	{
		List<string> menuItems { get; }
		private IToDoListLogic _toDoListLogic;

		public TaskListMenu(IToDoListLogic toDoListLogic)
		{
			_toDoListLogic = toDoListLogic;

			menuItems = new List<string>()
			{
				"Полный",
				"Полный (с учетом приоритета)",
				"Невыполненные (по убыванию приоритета)",
				"Выполненные"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Задачи\Список задач");
				MenuView menu = new MenuView(menuItems);
				menu.Show();
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doRead = new TasksView(_toDoListLogic.GetAll());
							doRead.Show();
							break;
						}
					case "2":
						{
							var doRead = new TasksView(_toDoListLogic.GetAllSortedByPriority(true));
							doRead.Show();
							break;
						}
					case "3":
						{
							var doRead = new TasksView(_toDoListLogic.GetAllSortedByPriority(false).Where(x => !x.Checked));
							doRead.Show();
							break;
						}
					case "4":
						{
							var doRead = new TasksView(_toDoListLogic.GetAll().Where(x => x.Checked));
							doRead.Show();
							break;
						}
				}
			}
		}
	}
}
