using System.Collections.Generic;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Memory
{
    public static class MemoryDAO
    {
        public static List<ToDoListEntity> toDoList = new List<ToDoListEntity>();
    }
}
