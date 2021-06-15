using System.Collections.Generic;
using ToDoList.BLL.Models;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Common
{
    public interface IToDoListBLL
    {
        void Create(ItemCreation itemCreation);
        void Delete(int id);
        IEnumerable<ToDoListEntity> GetAll();
        IEnumerable<ToDoListEntity> GetAllSortedByPriority(bool asc = true);
        ToDoListEntity GetByName(string name);
        void CheckItem(int id, bool check);
    }
}
