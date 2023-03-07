namespace Azami.Models
{
    public class EntryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
        public virtual UserModel? User { get; set; }
    }
}
