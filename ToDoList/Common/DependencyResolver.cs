using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.BLL.Services;
using ToDoList.Common.Exceptions;
using ToDoList.DAL.Memory;

namespace ToDoList.Common
{
    /// <summary>
    /// Объект для создания бизнес-логики
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// Объект под DAO
        /// </summary>
        private static ToDoListMemory toDoListDAO { get; } = new ToDoListMemory();

        /// <summary>
        /// Объект под райтер
        /// </summary>
        private static ToDoListJSONWriter toDoListJSONWriter { get; } = new ToDoListJSONWriter();

        /// <summary>
        /// Объект под бизнес-логику
        /// </summary>
        public static ToDoListService toDoListService { get; } = new ToDoListService(toDoListDAO, toDoListJSONWriter);

        /// <summary>
        /// Считывает значение конфиги, и если это JSON, то считывает записанные в файле JSON значения
        /// </summary>
        public static async Task GetTypeDAL()
        {
            try
            {
                using (FileStream fs = new FileStream(Config.configPath, FileMode.OpenOrCreate))
                {
                    Config.restoredConfig = await JsonSerializer.DeserializeAsync<ConfigObject>(fs);
                }

                if (Config.restoredConfig.TypeDAL == "JSON")
                    await toDoListService.GetAllFromFile();
            }
            catch
            {
                throw new JSONException();
            }
        }
    }
}
