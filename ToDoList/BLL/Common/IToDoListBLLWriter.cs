using System.Threading.Tasks;

namespace ToDoList.BLL.Common
{
    /// <summary>
    /// Интерфейс для райтера в бизнес-логике
    /// </summary>
    public interface IToDoListBLLWriter
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
