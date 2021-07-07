using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ToDoList.Entities;

namespace ToDoList.DAL
{
	public class MemoryContext
	{
		private string _fileLocation;

		public string fileLocation { get => _fileLocation; }

		public List<Job> jobs { get; set; }

		public MemoryContext(string filePath)
		{
			_fileLocation = filePath;
			jobs = new List<Job>();

			if (File.Exists(_fileLocation))
			{
				using (StreamReader r = new StreamReader(_fileLocation))
				{
					string json = r.ReadToEnd();
					jobs = JsonConvert.DeserializeObject<List<Job>>(json);
				}
			}
		}
	}
}
