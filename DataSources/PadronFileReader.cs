using System.Collections;
using System.IO;
using System.Linq;

namespace WebApiPadron
{

    public class PadronFileReader : IPadronReader
    {
        private static string FILEPATH = @"padron-electoral\PADRON_COMPLETO.txt";

        private string _filepath;
        public string Filepath
        {
            get => _filepath;
            set => _filepath = value;
        }

        private IList _citizens;

        /// <summary>
        /// Crea una nueva instancia de la clase.
        /// </summary>
        public PadronFileReader()
        {
            this.Filepath = FILEPATH;
            this.readFileToList();
        }

        /// <summary>
        /// Obtiene una lista de ciudadanos a partir del arrchivo de texto del
        /// padrón electoral completo.
        /// </summary>
        private void readFileToList()
        {
            using (FileStream fs = File.Open(Filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                this.setCitizenList(sr);
            }
        }

        /// <summary>
        /// Asigna una lista de ciudadanos a la propiedad _citizens a partir de 
        /// un StreamReader.
        /// </summary>
        private void setCitizenList(StreamReader sr)
        {
            _citizens = new ArrayList();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                _citizens.Add(new Citizen(line));
            }
        }

        /// <summary>
        /// Obtiene la lista de ciudadanos.
        /// </summary>
        Citizen[] IPadronReader.getCitizens()
        {
            return _citizens.Cast<Citizen>().ToArray();
        }
    }
}
