using System;
using System.Threading.Tasks;
using ToDoList.BLL.Interface;
using ToDoList.IOC;
using ToDoList.PL.Menus;

namespace ToDoList.PL
{
	class Program
	{
		static async Task Main(string[] args)
		{
			await DependencyResolver.GetTypeDAL();
			IToDoListLogic toDoListLogic = DependencyResolver.toDoListLogic;

			MainMenu mainMenu = new MainMenu(toDoListLogic);

			mainMenu.Choose();

			await DependencyResolver.SetTypeDAL();
		}
	}
}
