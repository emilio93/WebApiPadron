using System.Collections;
using System.IO;
using System.Linq;

namespace WebApiPadron
{

    public class PadronFileReader : IPadronReader
    {
        private static string FILEPATH = @"padron-electoral\PADRON_COMPLETO.txt";
        private static PadronFileReader _instance = null;

        private string _filepath;
        public string Filepath
        {
            get => _filepath;
            set => _filepath = value;
        }

        private IList _citizens;
        public static PadronFileReader GetIntance()
        {
            if (PadronFileReader._instance == null)
            {
                PadronFileReader._instance = new PadronFileReader(PadronFileReader.FILEPATH);
            }
            return PadronFileReader._instance;
        }

        private PadronFileReader(string filepath)
        {
            Filepath = filepath;
            _citizens = new ArrayList();

            using (FileStream fs = File.Open(Filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    _citizens.Add(new Citizen(line));
                }
            }
        }



        Citizen[] IPadronReader.getCitizens()
        {
            return _citizens.Cast<Citizen>().ToArray();
        }
    }
}
