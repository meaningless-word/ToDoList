using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ToDoList.BLL.Entities;
using ToDoList.PL.Interface;

namespace ToDoList.PL.Views
{
	public class TasksView : IView
	{
		private IEnumerable<ItemDelivered> _tasks;

		public TasksView(IEnumerable<ItemDelivered> tasks)
		{
			_tasks = tasks;
		}

		public void Show()
		{
			Display(_tasks);
		}

		private void Display(IEnumerable<ItemDelivered> tasks)
		{
			Console.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}", "наименование".PadRight(30, '.'), "текст".PadRight(50, '.'), "срок".PadRight(10, '.'), "приоритет.", "[v]", "Id".PadRight(6, '.'));
			tasks.ToList().ForEach(x =>
			{
				Console.WriteLine("{0,-30}:{1,-50}:{2,10}:{3,10}:{4,3}:{5,6}", x.Name, x.Text, x.ExpireDate.ToString("dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo), x.Priority, x.Checked ? "[v]" : "[.]", x.Id);
			});
		}
	}
}
