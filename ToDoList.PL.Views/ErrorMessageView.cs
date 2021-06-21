using System;
using ToDoList.PL.Interface;

namespace ToDoList.PL.Views
{
	public class ErrorMessageView : IView
	{
		private string _message;
		public ErrorMessageView(string message)
		{
			_message = message;
		}
		public void Show()
		{
			ConsoleColor originalColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(_message);
			Console.ForegroundColor = originalColor;
		}
	}
}
