using System.Collections.Generic;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.Common
{
    public interface IToDoListDAO
    {
        int Create(ToDoListEntity toDoListEntity);
        int Delete(int id);
        IEnumerable<ToDoListEntity> GetAll();
        ToDoListEntity GetByName(string name);
        int CheckItem(int id, bool check);
    }
}
