using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.BLL.Services;
using ToDoList.Common.Exceptions;
using ToDoList.DAL.Common;
using ToDoList.DAL.Memory;

namespace ToDoList.Common
{
    public static class DependencyResolver
    {
        private static IToDoListDAO toDoListDAO { get; set; }
        public static ToDoListService toDoListService { get; set; } 

        public static async Task GetTypeDAL()
        {
            try { 
                using (FileStream fs = new FileStream(Config.filePath, FileMode.OpenOrCreate))
                {
                    Config.restoredConfig = await JsonSerializer.DeserializeAsync<ConfigObject>(fs);
                }
            }
            catch
            {
                throw new JSONException();
            }

            if (Config.restoredConfig.TypeDAL == Config.MemoryDAO)
                toDoListDAO = new ToDoListMemory();
            //else if (Config.restoredConfig.TypeDAL == Config.FileDAO)
            //    toDoListDAO = new ToDoListFile();
            else
                throw new JSONException();

            toDoListService = new ToDoListService(toDoListDAO);
        }
    }
}
