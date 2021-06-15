using System.Collections.Generic;
using System.Linq;
using ToDoList.DAL.Common;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Memory
{
    public class ToDoListMemory : IToDoListDAO
    { 
        public int Create(ToDoListEntity toDoListEntity)
        {
            toDoListEntity.Id = GetLastId() + 1;
            toDoListEntity.Checked = false;

            MemoryDAO.toDoList.Add(toDoListEntity);

            return toDoListEntity.Id;
        }

        public int Delete(int id)
        {
            MemoryDAO.toDoList.Remove(GetById(id));

            return id;
        }

        public IEnumerable<ToDoListEntity> GetAll()
        {
            return MemoryDAO.toDoList.ToList();
        }

        public ToDoListEntity GetByName(string name)
        {
            return MemoryDAO.toDoList.FirstOrDefault(item => item.Name == name);
        }

        public int CheckItem(int id, bool check)
        {
            var item = GetById(id);

            item.Checked = check;

            return id;
        }

        private ToDoListEntity GetById(int id)
        {
            return MemoryDAO.toDoList.FirstOrDefault(item => item.Id == id);
        }

        private int GetLastId()
        {
            return (MemoryDAO.toDoList.Count == 0) ? 0 : MemoryDAO.toDoList.Max(item => item.Id);
        }
    }
}
