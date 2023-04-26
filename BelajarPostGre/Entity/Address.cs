namespace BelajarPostGre.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = new User();
        public string AddressName { get; set; } = string.Empty;
    }
}
