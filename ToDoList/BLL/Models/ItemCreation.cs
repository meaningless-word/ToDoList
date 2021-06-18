namespace ToDoList.BLL.Models
{
    /// <summary>
    /// Вводимые параметры из UI
    /// </summary>
    public class ItemCreation
    {
        /// <summary>
        /// Имя задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Text { get; set; }
    }
}
