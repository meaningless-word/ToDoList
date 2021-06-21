using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Common;
using ToDoList.Common.Exceptions;

namespace ToDoList.PLL.Views
{
	public class TaskProcessingMenu
	{
		List<string> menuItems { get; }
		private IToDoListBLL _toDoListBLL;

		public TaskProcessingMenu(IToDoListBLL toDoListBLL)
		{
			_toDoListBLL = toDoListBLL;

			menuItems = new List<string>()
			{
				"Создать",
				"Удалить",
				"Изменение статуса",
			};
		}

		public void Choose()
		{
			while (true)
			{
				Console.WriteLine(@"Задачи\Действия");
				MenuView.Show(menuItems);
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doCreate = new TaskCreationView();
							try { 
								_toDoListBLL.Create(doCreate.Show());
								Console.WriteLine("задача добавлена");
							}
							catch (PropertyIsNotValid) { ErrorMessageView.Show("Не все обязательные поля заполнены"); }
							catch (Exception ex) { ErrorMessageView.Show(ex.Message); }
							break;
						}
					case "2":
						{
							var doDelete = new TaskGetIdentificationView();
							try { 
								_toDoListBLL.Delete(doDelete.Show());
								Console.WriteLine("задача удалена");
							}
							catch (InfoIsNotValid) { ErrorMessageView.Show("Нет задачи с таким идентификатором"); }
							catch (Exception ex) { ErrorMessageView.Show(ex.Message); }
							break;
						}
					case "3":
						{
							var doCheck = new TaskGetIdentificationView();
							try {
								int id = doCheck.Show();
								_toDoListBLL.CheckItem(id, !_toDoListBLL.GetById(id).Checked);
								Console.WriteLine("статус задачи изменен");
							}
							catch (InfoIsNotValid) { ErrorMessageView.Show("Нет задачи с таким идентификатором"); }
							catch (Exception ex) { ErrorMessageView.Show(ex.Message); }
							break;
						}
				}
			}
		}
	}
}
