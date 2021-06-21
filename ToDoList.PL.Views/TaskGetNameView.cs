using System;
using ToDoList.PL.Interface;

namespace ToDoList.PL.Views
{
	public class TaskGetNameView : IView
	{
		public string Display()
		{
			Console.WriteLine("Введите");
			Console.Write("фрагмент текста для поиска: ");
			string part = Console.ReadLine();
			return part;
		}

		public void Show()
		{
			throw new NotImplementedException();
		}
	}
}
