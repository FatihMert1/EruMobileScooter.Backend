namespace EruMobileScooter.Data
{
    public class ActiveScooter : BaseEntity {

        public string ScooterId { get; set; }
        public Scooter Scooter { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}