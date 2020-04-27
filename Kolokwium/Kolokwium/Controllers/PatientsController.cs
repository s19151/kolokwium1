using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IDbService _dbService;
        public PatientsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int idPatient)
        {
            try
            {
                _dbService.DeletePatient(idPatient);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}