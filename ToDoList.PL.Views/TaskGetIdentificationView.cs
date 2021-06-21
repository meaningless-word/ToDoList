using System;
using ToDoList.PL.Interface;

namespace ToDoList.PL.Views
{
	public class TaskGetIdentificationView : IView
	{
		public int Display()
		{
			int id = 0;
			try
			{
				Console.WriteLine("Введите");
				Console.Write("идентификатор задачи: ");
				id = int.Parse(Console.ReadLine());
			}
			catch (Exception ex)
			{
				new ErrorMessageView(ex.Message).Show();
			}
			return id;
		}

		public void Show()
		{
			throw new NotImplementedException();
		}
	}
}
