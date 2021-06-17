using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.BLL.Common;
using ToDoList.Common.Exceptions;
using ToDoList.BLL.Models;
using ToDoList.DAL.Common;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Services
{
    public class ToDoListService : IToDoListBLL
    {
        private readonly IToDoListDAO _toDoListDAL;

        public ToDoListService(IToDoListDAO toDoListDAL)
        {
            _toDoListDAL = toDoListDAL;
        }

        public void Create(ItemCreation itemCreation)
        {
            if (String.IsNullOrEmpty(itemCreation.Name))
                throw new PropertyIsNotValid();

            if (String.IsNullOrEmpty(itemCreation.Text))
                throw new PropertyIsNotValid();

            if (itemCreation.Priority < 0)
                throw new PropertyIsNotValid();

            var toDoListEntity = new ToDoListEntity()
            {
                Name = itemCreation.Name,
                Text = itemCreation.Text,
                Priority = itemCreation.Priority
            };

            if (_toDoListDAL.Create(toDoListEntity) == 0)
                throw new Exception();
        }

        public void Delete(int id)
        {
            if (!CheckId(id))
                throw new InfoIsNotValid();

            if (_toDoListDAL.Delete(id) == 0)
                throw new Exception();
        }

        public IEnumerable<ToDoListEntity> GetAll()
        {
            return _toDoListDAL.GetAll();
        }

        public IEnumerable<ToDoListEntity> GetAllSortedByPriority(bool asc = true)
        {
            if (asc)
                return GetAll().OrderBy(item => item.Priority);

            return GetAll().OrderByDescending(item => item.Priority);
        }

        public ToDoListEntity GetByName(string name)
        {
            var item = _toDoListDAL.GetByName(name);

            if (item == null)
                throw new InfoIsNotValid();

            return item;
        }

        public void CheckItem(int id, bool check)
        {
            if (!CheckId(id))
                throw new InfoIsNotValid();

            if (_toDoListDAL.CheckItem(id, check) == 0)
                throw new Exception();
        }

        private bool CheckId(int id)
        {
            var list = GetAll();

            if (id < 0 || id > list.ToList().Count)
                return false;

            return true;
        }
    }
}
