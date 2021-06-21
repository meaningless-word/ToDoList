using System;
using System.Collections.Generic;
using ToDoList.BLL.Interface;
using ToDoList.Exceptions;
using ToDoList.PL.Interface;
using ToDoList.PL.Views;

namespace ToDoList.PL.Menus
{
	public class TaskProcessingMenu : IMenu
	{
		List<string> menuItems { get; }
		private IToDoListLogic _toDoListLogic;

		public TaskProcessingMenu(IToDoListLogic toDoListLogic)
		{
			_toDoListLogic = toDoListLogic;

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
				MenuView menu = new MenuView(menuItems);
				menu.Show();
				string keyValue = Console.ReadLine();
				if (keyValue == "0") break;

				switch (keyValue)
				{
					case "1":
						{
							var doCreate = new TaskCreationView();
							try
							{
								_toDoListLogic.Create(doCreate.Display());
								Console.WriteLine("задача добавлена");
							}
							catch (PropertyIsNotValidException) { new ErrorMessageView("Не все обязательные поля заполнены").Show(); }
							catch (Exception ex) { new ErrorMessageView(ex.Message).Show() ; }
							break;
						}
					case "2":
						{
							var doDelete = new TaskGetIdentificationView();
							try
							{
								_toDoListLogic.Delete(doDelete.Display());
								Console.WriteLine("задача удалена");
							}
							catch (InfoIsNotValidException) { new ErrorMessageView("Нет задачи с таким идентификатором").Show(); }
							catch (Exception ex) { new ErrorMessageView(ex.Message).Show(); }
							break;
						}
					case "3":
						{
							var doCheck = new TaskGetIdentificationView();
							try
							{
								int id = doCheck.Display();
								_toDoListLogic.CheckItem(id, !_toDoListLogic.GetById(id).Checked);
								Console.WriteLine("статус задачи изменен");
							}
							catch (InfoIsNotValidException) { new ErrorMessageView("Нет задачи с таким идентификатором").Show(); }
							catch (Exception ex) { new ErrorMessageView(ex.Message).Show(); }
							break;
						}
				}
			}
		}
	}
}
