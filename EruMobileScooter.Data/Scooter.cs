namespace EruMobileScooter.Data{

    public class Scooter : BaseEntity {

        /**
        * Scooter'ın Şarj Durumu. %20 şarj kaldı
        */
        public int ChargeState { get; set; }
        /**
        * Scooter'ın Numarası. 55 Numaralı Scooter.
        */
        public int Number { get; set; }
        /**
        * Scooter'ın Gidebilecegi Maxsimum Mesafe. Maximum 5 km gidebilir.
        */
        public int MaxRange { get; set; }
        /**
        * Scooter üzerindeki barcode bilgisi
        */
        public string Barcode { get; set; }
        /**
        * Scooter'ın Anlık Aldıgı Mesafe. 2 km lik yol yapıldı.
        */
        public int CurrentRange { get; set; }
        /**
        * Scooter'ın Anlık Lokasyon Bilgisi. Şuanda IBF nin orada
        */
        public string Location { get; set; }
    }
}