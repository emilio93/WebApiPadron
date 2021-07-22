using System.Collections;
using System.Linq;

namespace WebApiPadron
{
    public interface ICitizenLogic
    {
        public ICitizen[] Citizens
        {
            get;
            set;
        }
        public string[] getLongestNombres(int quantity = 10);
        public string[] getLeastCommonNombres(int quantity = 1);
        public int[] getElectoralDistrictsWithMostCitizens(int quantity = 1);
        public int[] getElectoralDistrictsWithLeastCitizens(int quantity = 1);
        public int getCitizenCountInElectoralDistrict(int codElec);
    }
}
