using System.Collections.Generic;

namespace EruMobileScooter.Data
{
    public class EnergyStation : BaseEntity
    {

        public EnergyStation()
        {
            EnergyGenerators = new HashSet<EnergyGenerator>();
        }

        /**
        * Enerji Kapasitesi. Toplam 1 MW
        */
        public double EnergyCapacity { get; set; }
        /**
        * Anlık Üretilen Enerji
        */
        public double CurrentEnergy { get; set; }

        /**
        * Istasyonun Sahip Oldugu EnergyGenerators
        */
        public ICollection<EnergyGenerator> EnergyGenerators { get; set; }
    }
}