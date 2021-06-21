using System.Collections.Generic;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Memory
{
    /// <summary>
    /// Объект под список задач
    /// </summary>
    public static class ToDoListDAO
    {
        /// <summary>
        /// Список задач
        /// </summary>
        public static List<Job> toDoList = new List<Job>();
    }
}
