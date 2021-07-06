using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities.Configuration
{
	public class ConfigurationDAL
	{
		/// <summary>
		/// выбор способа хранения данных
		/// </summary>
		public TypeOfDAO type { get; set; }
		/// <summary>
		/// имя файла базы данных
		/// </summary>
		public string fileName { get; set; }
		/// <summary>
		/// путь расположения файла базы данных
		/// </summary>
		public string filePath { get; set; }
	}
}
