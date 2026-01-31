// Models/Folder.cs
namespace TextEditor.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int DocumentCount { get; set; } // Computed property
    }
}