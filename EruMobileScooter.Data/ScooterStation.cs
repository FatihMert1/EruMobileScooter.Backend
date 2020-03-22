using System.Collections.Generic;

namespace EruMobileScooter.Data{

    public class ScooterStation : BaseEntity {

        public ScooterStation()
        {
            Scooters = new HashSet<Scooter>();
        }
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
        
        /**
        * Istasyonun İcinde Bulundurdugu Scooterlar
        */
        public ICollection<Scooter> Scooters { get; set; }

    }
}