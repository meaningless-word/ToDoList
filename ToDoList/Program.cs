using System;
using ToDoList.BLL.Models;
using ToDoList.Common;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            var toDoListService = DependencyResolver.toDoListService;

            toDoListService.Create(new ItemCreation
            {
                Name = "Задача №1",
                Text = "Вот эта вот задача №1",
                Priority = 4
            });

            toDoListService.Create(new ItemCreation
            {
                Name = "Задача №2",
                Text = "Вот эта вот задача №2",
                Priority = 2
            });

            toDoListService.Create(new ItemCreation
            {
                Name = "Задача №3",
                Text = "Вот эта вот задача №3",
                Priority = 42
            });

            var test = toDoListService.GetAll();

            foreach(var item in test)
            {
                Console.WriteLine($"id = {item.Id}, name = {item.Name}, text = {item.Text}, " +
                    $"priority = {item.Priority}, checked = {item.Checked}");
            }

            Console.WriteLine("________");

            test = toDoListService.GetAllSortedByPriority(false);

            foreach (var item in test)
            {
                Console.WriteLine($"id = {item.Id}, name = {item.Name}, text = {item.Text}, " +
                    $"priority = {item.Priority}, checked = {item.Checked}");
            }

            Console.ReadLine();
        }
    }
}
