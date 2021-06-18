using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ToDoList.Common;
using ToDoList.DAL.Common;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Memory
{
    /// <summary>
    /// Объект под райтер в слое данных
    /// </summary>
    public class ToDoListJSONWriter : IToDoListWriter
    {
        /// <summary>
        /// Считывание списка задач из файла
        /// </summary>
        public async Task GetAllFromFile()
        {
            using (FileStream fs = new FileStream(Config.jsonPath, FileMode.OpenOrCreate))
            {
                ToDoListDAO.toDoList = await System.Text.Json.JsonSerializer.DeserializeAsync<List<ToDoListEntity>>(fs);
            }
        }

        /// <summary>
        /// Записывание списка задач в файл
        /// </summary>
        public async Task SetAllToFile()
        {
            using (FileStream fs = new FileStream(Config.jsonPath, FileMode.OpenOrCreate))
            {
                await System.Text.Json.JsonSerializer.SerializeAsync<List<ToDoListEntity>>(fs, ToDoListDAO.toDoList);
            }
        }
    }
}
