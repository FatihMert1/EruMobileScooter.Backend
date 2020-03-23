namespace EruMobileScooter.Data
{
    public class EnergyGenerator : BaseEntity {


        /**
        * Enerji Kapasitesi. 1 MW lık Bir Rüzgar Türbini
        */
        public int EnergyCapacity { get; set; }

        /**
        * Anlık Üretilen Enerji
        */
        public int CurrentEnergy { get; set; }
        
        /**
        * EnergyCreator Type. Rüzgar Tübini, Biyogaz, Günes Paneli
        */
        public EnergyCreatorType Type { get; set; }


    }

    public enum EnergyCreatorType {
        NONE = 0,
        WIND = 1,
        SUN = 2,
        WATER = 3,
        BIOGAS = 4
    }
}