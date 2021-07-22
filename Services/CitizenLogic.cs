using System.Collections;
using System.Linq;

namespace WebApiPadron
{
    public class CitizenLogic : ICitizenLogic
    {
        private ICitizen[] _citizens;
        public ICitizen[] Citizens
        {
            get => _citizens;
            set => _citizens = value;
        }

        /// <summary>
        /// Constructs the CitizenLogic object.
        /// </summary>
        public CitizenLogic()
        {
        }

        /// <summary>
        /// Gets the n citizens with longest names.
        /// </summary>
        public string[] getLongestNombres(int quantity = 10)
        {
            ICitizen[] sortedCitizens = Citizens
                .OrderByDescending(citizen => citizen.Nombre.Replace(" ", "").Length)
                .ToArray();
            ArrayList longestNombres = new ArrayList();
            int listCounter = 0;
            for (int i = 0; i < quantity; )
            {
                if (i == 0 || sortedCitizens[listCounter].Nombre != (string)longestNombres[i-1])
                {
                    longestNombres.Add(sortedCitizens[listCounter].Nombre);
                    i++;
                }
                listCounter++;
            }
            return longestNombres.Cast<string>().ToArray();
        }

        /// <summary>
        /// Gets the n citizens with shortest names.
        /// </summary>
        public string[] getLeastCommonNombres(int quantity = 1)
        {
            string[] nombres = (string[])Citizens
                .GroupBy(item => item.Nombre)
                .OrderBy(g => g.Count())
                .Select(g => g.Key)
                .Take(quantity)
                .ToArray();
            return nombres;
        }

        /// <summary>
        /// Gets the n electoral districts with most citizens.
        /// </summary>
        public int[] getElectoralDistrictsWithMostCitizens(int quantity = 1)
        {
            int[] codElec = Citizens
                .GroupBy(item => item.CodElec)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(quantity)
                .ToArray();
            return codElec;
        }

        /// <summary>
        /// Gets the n electoral districts with least citizens.
        /// </summary>
        public int[] getElectoralDistrictsWithLeastCitizens(int quantity = 1)
        {
            int[] codElec = Citizens
                .GroupBy(item => item.CodElec)
                .OrderBy(g => g.Count())
                .Select(g => g.Key)
                .Take(quantity)
                .ToArray();
            return codElec;
        }

        /// <summary>
        /// Get the citizen count in an electoral district.
        /// </summary>
        public int getCitizenCountInElectoralDistrict(int codElec)
        {
            int count = Citizens.Count(citizen => citizen.CodElec == codElec);
            return count;
        }
    }
}
