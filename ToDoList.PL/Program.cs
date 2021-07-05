using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using ToDoList.BLL.Interface;
using ToDoList.Entities.Configuration;
using ToDoList.IOC;
using ToDoList.PL.Menus;

namespace ToDoList.PL
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// Добавить в проект NuGet пакеты Microsoft.Exensions.Configuration.Json и Microsoft.Exensions.Configuration.Binder
			// В проекте COMMON\ToDoList.Entities создать папку Configuration, в которую добавить класс ConfigurationDAL, описывающий структуру конфигурационного объекта. 
			// В нашем случае у него будет свойство type
			// B класс TypeOfDAO, содержащий enum'ку, для "расшифровки" констант, определяющих набор значений свойства type конфигурационного класса.
			// В проект PL\ToDoList.PL добавляется файл appsettings.json, свойство "Copy To Output Directory" которого устанавливается в "Copy always"
			// Файл заполняется с указанием типа = 1

			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
				.AddJsonFile("appsettings.json", false)
				.Build();

			// из секции "configurationDal" читается значение типа ConfigurationDAL
			var configurationDAL = configuration.GetSection("configurationDal").Get<ConfigurationDAL>();

			var dr = new DependencyResolver(configurationDAL);

			await DependencyResolver.GetTypeDAL();
			IToDoListLogic toDoListLogic = dr.toDoListLogic;

			MainMenu mainMenu = new MainMenu(toDoListLogic);

			mainMenu.Choose();

			await DependencyResolver.SetTypeDAL();
		}
	}
}
