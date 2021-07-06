using System;
using System.Globalization;
using ToDoList.BLL.Entities;
using ToDoList.PL.Interface;

namespace ToDoList.PL.Views
{
	public class TaskCreationView : IView
	{
		public ItemCreated Display()
		{
			ItemCreated itemCreation = new ItemCreated();

			try
			{
				Console.WriteLine("Введите");
				Console.Write("наименование задачи: ");
				itemCreation.Name = Console.ReadLine();
				Console.Write("текст задачи: ");
				itemCreation.Text = Console.ReadLine();
				Console.Write("дата окончания срока исполнения (дд.мм.гггг): ");
				itemCreation.ExpireDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
				Console.Write("приоритет: ");
				itemCreation.Priority = int.Parse(Console.ReadLine());
			}
			catch (Exception ex)
			{
				new ErrorMessageView(ex.Message).Show();
			}
			return itemCreation;
		}

		public void Show()
		{
			throw new NotImplementedException();
		}
	}
}
