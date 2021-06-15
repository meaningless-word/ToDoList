namespace ToDoList.DAL.Entities
{
    public class ToDoListEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }
    }
}
