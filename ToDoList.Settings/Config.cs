namespace ToDoList.Settings
{
	/// <summary>
	/// Статический метод конфигурации
	/// </summary>
	public static class Config
	{
		/// <summary>
		/// Константа необходимости использовать ОЗУ
		/// </summary>
		public const string MemoryDAO = "Memory";

		/// <summary>
		/// Константа необходимости использовать ПЗУ в формате JSON
		/// </summary>
		public const string JSONDAO = "JSON";

		/// <summary>
		/// Путь до файла конфигурации
		/// </summary>
		public const string configPath = "Config.json";

		/// <summary>
		/// Путь до файла JSON со списком задач
		/// </summary>
		public const string jsonPath = "Base.json";

		/// <summary>
		/// Объект для описания файла конфигурации
		/// </summary>
		public static ConfigObject restoredConfig;
	}

	/// <summary>
	/// Объект для описания файла конфигурации
	/// </summary>
	public class ConfigObject
	{
		/// <summary>
		/// Тип используемой памяти (Memory или JSON)
		/// </summary>
		public string TypeDAL { get; set; }
	}
}
