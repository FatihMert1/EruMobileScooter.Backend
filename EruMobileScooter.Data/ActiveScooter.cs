namespace EruMobileScooter.Data
{
    public class ActiveScooter : BaseEntity {


        public Scooter Scooter { get; set; }

        public User User { get; set; }
    }
}