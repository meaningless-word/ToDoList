namespace ToDoList.Common
{
    public static class Config
    {
        public const string MemoryDAO = "Memory";
        public const string FileDAO = "File";

        public static string filePath = "Config.json";
        public static ConfigObject restoredConfig;
    }
}
