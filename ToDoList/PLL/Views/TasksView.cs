using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Models;

namespace ToDoList.PLL.Views
{
	public class TasksView
	{
		public void Show(IEnumerable<ItemDelivered> tasks)
		{
			Display(tasks);
		}

		private void Display(IEnumerable<ItemDelivered> tasks)
		{
			Console.WriteLine("{0}:{1}:{2}:{3}:{4}", "наименование".PadRight(30, '.'), "текст".PadRight(50, '.'), "приоритет.", "[v]", "Id".PadRight(6, '.'));
			tasks.ToList().ForEach(x =>
			{
				Console.WriteLine("{0,-30}:{1,-50}:{2,10}:{3,3}:{4,6}", x.Name, x.Text, x.Priority, x.Checked ? "[v]" : "[.]", x.Id);
			});
		}
	}
}
