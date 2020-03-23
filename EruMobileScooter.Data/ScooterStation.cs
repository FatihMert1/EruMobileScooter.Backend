using System.Collections.Generic;

namespace EruMobileScooter.Data{

    public class ScooterStation : BaseEntity {
        
        /**
        * Scooter Istasyonunun genel kapasitesi
        */
        public int MaxCapacity { get; set; }

        /**
        * Scooter Istasyonunun Anlık Kapasitesi
        */
        public int CurrentCapacity { get; set; }

        /**
        * Scooter Istasyonunun Bulundugu Yer
        */
        public string Location { get; set; }
    }
}