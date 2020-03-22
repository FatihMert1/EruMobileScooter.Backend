using System.Collections.Generic;

namespace EruMobileScooter.Data
{
    public class EnergyStation : BaseEntity
    {

        public EnergyStation()
        {
            EnergyCreators = new HashSet<EnergyCreator>();
        }

        /**
        * Enerji Kapasitesi. Toplam 1 MW Bir Türbin
        */
        public int EnergyCapacity { get; set; }
        /**
        * Anlık Üretilen Enerji
        */
        public int CurrentEnergy { get; set; }

        /**
        * Istasyonun Sahip Oldugu EnergyCreators
        */
        public ICollection<EnergyCreator> EnergyCreators { get; set; }
    }
}