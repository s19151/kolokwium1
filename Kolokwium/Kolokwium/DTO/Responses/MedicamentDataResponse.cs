using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTO.Responses
{
    public class MedicamentDataResponse
    {
        public Medicament Medicament { get; set; }
        public List<Prescription> PrescriptionList { get; set; }
    }
}
