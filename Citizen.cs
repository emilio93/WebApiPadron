using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiPadron
{
    public class Citizen : ICitizen
    {
        private int _cedula;
        public int Cedula 
        { 
            get => _cedula; 
            set => _cedula = value; 
        }
        private int _codElec;
        public int CodElec 
        { 
            get => _codElec; 
            set => _codElec = value; 
        }
        private string _fechaCaduc;
        public string FechaCaduc 
        { 
            get => _fechaCaduc; 
            set => _fechaCaduc = value; 
        }
        private int _junta;
        public int Junta 
        { 
            get => _junta; 
            set => _junta = value; 
        }
        private string _nombre;
        public string Nombre 
        { 
            get => _nombre; 
            set => _nombre = value; 
        }
        private string _primerApellido;
        public string PrimerApellido 
        { 
            get => _primerApellido; 
            set => _primerApellido = value; 
        }
        private string _segundoApellido;
        public string SegundoApellido 
        { 
            get => _segundoApellido; 
            set => _segundoApellido = value; 
        }

        public Citizen(string citizenRegister)
        {
            parseRegister(citizenRegister);
        }

        private void parseRegister(string citizenRegister)
        {
            string[] fields = citizenRegister.Split(',');
            Cedula = Int32.Parse(fields[0]);
            CodElec = Int32.Parse(fields[1]);
            // Relleno fields[2]
            FechaCaduc = fields[3].Trim();
            Junta = Int32.Parse(fields[4]);
            Nombre = fields[5].Trim();
            PrimerApellido = fields[6].Trim();
            SegundoApellido = fields[7].Trim();
        }
    }
}
