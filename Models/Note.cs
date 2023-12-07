using SQLite;

namespace Notes.Models
{
    class Note
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Color { get; set; } = "#ffffff";
        public string Date { get; set; }
    }
    //I create this class because Maui can't binding a Color class
    class NoteTemporary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Color Color { get; set; } = Colors.White;
        public string Date { get; set; }
    }
}
