using ToDoList.BLL.Services;
using ToDoList.DAL.Memory;

namespace ToDoList.Common
{
    public static class DependencyResolver
    {
        private static ToDoListMemory toDoListDAO { get; } = new ToDoListMemory();
        public static ToDoListService toDoListService { get; } = new ToDoListService(toDoListDAO);
    }
}
