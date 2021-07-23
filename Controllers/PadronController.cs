using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebApiPadron.Controllers
{
    /// <summary>
    /// Ejemplo de controlador que muestra como usar el controlador de padrón.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PadronController : ControllerBase
    {
        private readonly ILogger<PadronController> _logger;
        private readonly ICitizenLogic _citizenLogic;

        /// <summary>   
        /// El constructor obtiene la lista de ciudadanos y crea un objeto para
        /// el manejo de la lógica de estos datos.
        /// </summary>
        public PadronController(ILogger<PadronController> logger, ICitizenLogic citizenLogic)
        {
            _logger = logger;
            _citizenLogic = citizenLogic;
        }

        /// <summary>
        /// Obtiene la lista de los n ciudadanos con nombres más largos.
        /// </summary>
        [HttpGet("names/longest/{quantity}")]
        public IEnumerable<string> GetLongestNames(int quantity)
        {
            return this._citizenLogic.getLongestNombres(quantity);
        }

        /// <summary>
        /// Obtiene el ciudadano con el nombre más largo.
        /// </summary>
        [HttpGet("names/longest")]
        public string GetLongestName()
        {
            return this._citizenLogic.getLongestNombres(1)[0];
        }

        /// <summary>
        /// Obtiene la lista de los n ciudadanos con nombres menos comunes.
        /// </summary>
        [HttpGet("names/leastCommon/{quantity}")]
        public IEnumerable<string> GetLeastCommonNames(int quantity)
        {
            return _citizenLogic.getLeastCommonNombres(quantity);
        }

        /// <summary>
        /// Obtiene el ciudadano con el nombre menos común.
        /// </summary>
        [HttpGet("names/leastCommon")]
        public string GetLeastCommonNames()
        {
            return this._citizenLogic.getLeastCommonNombres(1)[0];
        }

        /// <summary>
        /// Obtiene la lista de los n distritos electorles con más ciudadanos.
        /// </summary>
        [HttpGet("electoralDistricts/mostCitizens/{quantity}")]
        public IEnumerable<int> GetElectoralDistrictsWithMostCitizens(int quantity)
        {
            return this._citizenLogic.getElectoralDistrictsWithMostCitizens(quantity);
        }

        /// <summary>
        /// Obtiene el distrito electoral con más ciudadanos.
        /// </summary>
        [HttpGet("electoralDistricts/mostCitizens")]
        public int GetElectoralDistrictsWithMostCitizens()
        {
            return this._citizenLogic.getElectoralDistrictsWithMostCitizens(1)[0];
        }

        /// <summary>
        /// Obtiene la lista de los n distritos electorles con menos ciudadanos.
        /// </summary>
        [HttpGet("electoralDistricts/leastCitizens/{quantity}")]
        public IEnumerable<int> GetElectoralDistrictsWithLeastCitizens(int quantity)
        {
            return this._citizenLogic.getElectoralDistrictsWithLeastCitizens(quantity);
        }

        /// <summary>
        /// Obtiene el distrito electoral con menos ciudadanos.
        /// </summary>
        [HttpGet("electoralDistricts/leastCitizens")]
        public int GetElectoralDistrictsWithLeastCitizens()
        {
            // public int getCitizenCountInElectoralDistrict(int codElec);
            return this._citizenLogic.getElectoralDistrictsWithLeastCitizens(1)[0];
        }
    }
}
