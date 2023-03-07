namespace Azami.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MasterPassword { get; set; }
        public virtual List<EntryModel> Entries { get; set; }
    }
}
