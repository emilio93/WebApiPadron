namespace WebApiPadron
{
    public interface ICitizen
    {
        /// <summary>
        /// Cedula number of the citizen.
        /// </summary>
        int Cedula
        {
            get;
            set;
        }

        /// <summary>
        /// Electoral code to determine the location of the citizen's electoral district.
        /// The first digit is the province, digits 2 and 3 are the canton and the last three
        /// digits are the district.
        /// </summary>
        int CodElec
        {
            get;
            set;
        }

        /// <summary>
        /// Expiration date of citizen's cedula.
        /// </summary>
        string FechaCaduc
        {
            get;
            set;
        }

        /// <summary>
        /// The number of the receptor council.
        /// </summary>
        int Junta
        {
            get;
            set;
        }

        /// <summary>
        /// Full name of the citizen.
        /// </summary>
        string Nombre
        {
            get;
            set;
        }

        /// <summary>
        /// First last name of the citizen.
        /// </summary>
        string PrimerApellido
        {
            get;
            set;
        }

        /// <summary>
        /// Second last name of the citizen.
        /// </summary>
        string SegundoApellido
        {
            get;
            set;
        }
    }


}