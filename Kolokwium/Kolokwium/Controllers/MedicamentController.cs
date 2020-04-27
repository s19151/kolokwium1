using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [ApiController]
    [Route("api/medicaments")]
    public class MedicamentController : ControllerBase
    {
        private IDbService _dbService;

        public MedicamentController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMedicamentData(int idMedicament)
        {
            try
            {
                return Ok(_dbService.GetMedicamentData(idMedicament));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}