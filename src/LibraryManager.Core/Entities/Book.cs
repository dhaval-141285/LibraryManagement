namespace LibraryManager.Core.Entities
{
    public class Book
    {
        //public int Id { get; set; }
        //public int UserId { get; set; }
        //public string? Title { get; set; }
        //public string? Author { get; set; }
        //public string? ISBN { get; set; }
        //public int PublishYear { get; set; }
        //public User? User { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Author { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? BorrowedBy { get; set; } = null;
    }
}