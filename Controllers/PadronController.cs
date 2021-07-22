using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebApiPadron.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PadronController : ControllerBase
    {
        private readonly ILogger<PadronController> _logger;
        private readonly IPadronReader _padronReader;
        private readonly ICitizenLogic _citizenLogic;

        public PadronController(ILogger<PadronController> logger)
        {
            _padronReader = PadronFileReader.GetIntance();
            _logger = logger;
            _citizenLogic = new CitizenLogic(_padronReader.getCitizens());
        }


        [HttpGet("names/longest/{quantity}")]
        public IEnumerable<string> GetLongestNames(int quantity)
        {
            return this._citizenLogic.getLongestNombres(quantity);
        }

        [HttpGet("names/longest")]
        public string GetLongestName()
        {
            return this._citizenLogic.getLongestNombres(1)[0];
        }

        [HttpGet("name/leastCommon/{quantity}")]
        public IEnumerable<string> GetLeastCommonNames(int quantity)
        {
            return _citizenLogic.getLeastCommonNombres(quantity);
        }


        [HttpGet("names/leastCommon")]
        public string GetLeastCommonNames()
        {
            return this._citizenLogic.getLeastCommonNombres(1)[0];
        }

        [HttpGet("electoralDistricts/mostCitizens/{quantity}")]
        public IEnumerable<int> GetElectoralDistrictsWithMostCitizens(int quantity)
        {
            return this._citizenLogic.getElectoralDistrictsWithMostCitizens(quantity);
        }

        [HttpGet("electoralDistricts/mostCitizens")]
        public int GetElectoralDistrictsWithMostCitizens()
        {
            return this._citizenLogic.getElectoralDistrictsWithMostCitizens(1)[0];
        }


        [HttpGet("electoralDistricts/leastCitizens/{quantity}")]
        public IEnumerable<int> GetElectoralDistrictsWithLeastCitizens(int quantity)
        {
            return this._citizenLogic.getElectoralDistrictsWithLeastCitizens(quantity);
        }


        [HttpGet("electoralDistricts/leastCitizens")]
        public int GetElectoralDistrictsWithLeastCitizens()
        {
            // public int getCitizenCountInElectoralDistrict(int codElec);
            return this._citizenLogic.getElectoralDistrictsWithLeastCitizens(1)[0];
        }
    }
}
