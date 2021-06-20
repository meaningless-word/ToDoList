using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BLL.Models
{
	public class ItemDelivered
	{
        /// <summary>
        /// Id задачи
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Признак исполнения
        /// </summary>
        public bool Checked { get; set; }
    }
}
