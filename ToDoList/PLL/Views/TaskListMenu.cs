using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Common;
using ToDoList.PLL.Common;

namespace ToDoList.PLL.Views
{
	public class TaskListMenu : IMenu
	{
		List<string> menuItems { get; }
		private IToDoListBLL _toDoListBLL;

		public TaskListMenu(IToDoListBLL toDoListBLL)
		{
			_toDoListBLL = toDoListBLL;

			menuItems = new List<string>()
			{
				"Полный",
				"Невыполненные (по убыванию приоритета)",
				"Выполненные"
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Задачи\Список задач");
				MenuView.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doRead = new TasksView();
							doRead.Show(_toDoListBLL.GetAll());
							break;
						}
					case "2":
						{
							var doRead = new TasksView();
							doRead.Show(_toDoListBLL.GetAllSortedByPriority(false).Where(x => !x.Checked));
							break;
						}
					case "3":
						{
							var doRead = new TasksView();
							doRead.Show(_toDoListBLL.GetAll().Where(x => x.Checked));
							break;
						}
				}
			}
		}
	}
}
