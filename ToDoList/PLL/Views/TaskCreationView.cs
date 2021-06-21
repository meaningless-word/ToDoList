using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Models;

namespace ToDoList.PLL.Views
{
	public class TaskCreationView
	{
		public ItemCreation Show()
		{
			ItemCreation itemCreation = new ItemCreation();

			try
			{
				Console.WriteLine("Введите");
				Console.Write("наименование задачи: ");
				itemCreation.Name = Console.ReadLine();
				Console.Write("текст задачи: ");
				itemCreation.Text = Console.ReadLine();
				Console.Write("приоритет: ");
				itemCreation.Priority = int.Parse(Console.ReadLine());
			}
			catch (Exception ex)
			{
				ErrorMessageView.Show(ex.Message);
			}
			return itemCreation;
		}
	}
}
