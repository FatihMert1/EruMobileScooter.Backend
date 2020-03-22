namespace EruMobileScooter.Data
{
    public class ScooterHistory : BaseEntity{

        public Scooter Scooter { get; set; }

        public ScooterStation ScooterStation { get; set; }

        public User User { get; set; }
    }
}