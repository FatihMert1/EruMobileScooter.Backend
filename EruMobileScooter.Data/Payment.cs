namespace EruMobileScooter.Data
{
    public class Payment : BaseEntity {


        /**
        *   Hizmet Ucreti
        */
        public double Price { get; set; }
        /**
        * User Foreign Key
        */
        public string UserId { get; set; }
        /**
        *   Odemeyi Gerceklestiren User
        */
        public User User { get; set; }
        /**
        *   ScooterTransportHistory Foreign Key
        */
        public string ScooterTransportHistoryId { get; set; }
        /**
        *   Hizmet
        */
        public ScooterTransportHistory ScooterTransportHistory { get; set; }
    }
}