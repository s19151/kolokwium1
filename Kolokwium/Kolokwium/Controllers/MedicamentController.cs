using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [ApiController]
    [Route("api/medicaments")]
    public class MedicamentController : ControllerBase
    {
        public MedicamentController()

        [HttpGet("{id}")]
        public IActionResult GetMedicamentData(int idMedicament)
        {
            return NotFound();
        }
    }
}