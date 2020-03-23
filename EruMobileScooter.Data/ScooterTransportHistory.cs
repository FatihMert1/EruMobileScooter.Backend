using System;

namespace EruMobileScooter.Data{

    public class ScooterTransportHistory : BaseEntity {

        /**
        * Scooter Foreign Key
        */
        public string ScooterId { get; set; }
        /**
        *   Transport İsleminin Gerceklestigi Scooter.
        */
        public Scooter Scooter { get; set; }
        /**
        *   FromScooter Foreign Key
        */
        public string FromStationId { get; set; }
        /**
        * Scooter'ın Alindigi Istasyon
        */
        public ScooterStation FromStation { get; set; }
        /**
        *   ToStation Foreign Key
        */
        public string ToStationId { get; set; }
        /**
        *   Scooter'ın Teslım Edildigi İstasyon
        */
        public ScooterStation ToStation { get; set; }
        /**
        *  Scooter'ın İstasyondan Cıkıs Saati.!-- Scooter Saat 2 de A Istasyondan Cıkıs Yaptı
        */
        public DateTime FromStationOutTime { get; set; }
        /**
        *  Scooter'ın Yeni istasyonuna Bırakılma Saati. Scooter Saat 4 te B istasyonuna bırakıldı
        */
        public DateTime ToStationInTime { get; set; }

        /**
        *   User Foreign Key
        */
        public string UserId { get; set; }
        /**
        *   Scooter'ı Alan User
        */
        public User User { get; set; }
    }
}