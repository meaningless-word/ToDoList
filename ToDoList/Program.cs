using System.Threading.Tasks;
using ToDoList.IOC;
using ToDoList.PLL.Views;

namespace ToDoList
{
	class Program
	{
		public static MainMenu mainMenu;
		public static TaskListMenu taskListMenu;
		public static TaskProcessingMenu taskProcessingMenu;
		public static TaskFindingMenu taskFindingMenu;

		static async Task Main(string[] args)
		{
			await DependencyResolver.GetTypeDAL();
			var toDoListLogic = DependencyResolver.toDoListLogic;

			mainMenu = new MainMenu(toDoListLogic);
			taskListMenu = new TaskListMenu(toDoListLogic);
			taskProcessingMenu = new TaskProcessingMenu(toDoListLogic);
			taskFindingMenu = new TaskFindingMenu(toDoListLogic);

			mainMenu.Choose();

			//toDoListService.Create(new ItemCreation
			//{
			//    Name = "Задача №1",
			//    Text = "Вот эта вот задача №1",
			//    Priority = 4
			//});

			//toDoListService.Create(new ItemCreation
			//{
			//    Name = "Задача №2",
			//    Text = "Вот эта вот задача №2",
			//    Priority = 2
			//});

			//toDoListService.Create(new ItemCreation
			//{
			//    Name = "Задача №3",
			//    Text = "Вот эта вот задача №3",
			//    Priority = 42
			//});

			//toDoListService.Create(new ItemCreation
			//{
			//    Name = "Задача №4",
			//    Text = "Вот эта вот задача №4",
			//    Priority = 23
			//});

			// await toDoListService.SetAllToFile();

			//var test = toDoListService.GetAll();

			//foreach(var item in test)
			//{
			//    Console.WriteLine($"id = {item.Id}, name = {item.Name}, text = {item.Text}, " +
			//        $"priority = {item.Priority}, checked = {item.Checked}");
			//}

			//Console.ReadLine();
		}
	}
}
