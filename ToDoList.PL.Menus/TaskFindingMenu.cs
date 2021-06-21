using System;
using System.Collections.Generic;
using ToDoList.BLL.Interface;
using ToDoList.PL.Interface;
using ToDoList.PL.Views;

namespace ToDoList.PL.Menus
{
	public class TaskFindingMenu : IMenu
	{
		List<string> menuItems { get; }
		private IToDoListLogic _toDoListLogic;

		public TaskFindingMenu(IToDoListLogic toDoListLogic)
		{
			_toDoListLogic = toDoListLogic;

			menuItems = new List<string>()
			{
				"по фрагменту наименования",
				"по фрагменту текста"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Задачи\Поиск");
				MenuView menu = new MenuView(menuItems);
				menu.Show();
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doFind = new TaskGetNameView();
							var doRead = new TasksView(_toDoListLogic.GetByPartOfName(doFind.Display()));
							doRead.Show();
							break;
						}
					case "2":
						{
							var doFind = new TaskGetNameView();
							var doRead = new TasksView(_toDoListLogic.GetByPartOfText(doFind.Display()));
							doRead.Show();
							break;
						}
				}
			}
		}
	}
}
