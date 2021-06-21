using System.Threading.Tasks;

namespace ToDoList.DAL.Common
{
    /// <summary>
    /// Интерфейс для райтера в слое данных
    /// </summary>
    public interface IToDoListWriter
    {
        /// <summary>
        /// Считывание списка задач из файла
        /// </summary>
        public Task GetAllFromFile();

        /// <summary>
        /// Записывание списка задач в файл
        /// </summary>
        public Task SetAllToFile();
    }
}
