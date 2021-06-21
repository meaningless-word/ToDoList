using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Common;

namespace ToDoList.PLL.Views
{
	public class TaskFindingMenu
	{
		List<string> menuItems { get; }
		private IToDoListBLL _toDoListBLL;

		public TaskFindingMenu(IToDoListBLL toDoListBLL)
		{
			_toDoListBLL = toDoListBLL;

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
				MenuView.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doFind = new TaskGetNameView();
							var doRead = new TasksView();
							doRead.Show(_toDoListBLL.GetByPartOfName(doFind.Show()));
							break;
						}
					case "2":
						{
							var doFind = new TaskGetNameView();
							var doRead = new TasksView();
							doRead.Show(_toDoListBLL.GetByPartOfText(doFind.Show()));
							break;
						}
				}
			}
		}
	}
}
