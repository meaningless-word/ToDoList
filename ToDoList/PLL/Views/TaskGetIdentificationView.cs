using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.PLL.Views
{
	public class TaskGetIdentificationView
	{
		public int Show()
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
				ErrorMessageView.Show(ex.Message);
			}
			return id;
		}
	}
}
