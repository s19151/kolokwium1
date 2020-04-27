using Kolokwium.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DAL
{
    interface IDbService
    {
        public MedicamentDataResponse GetMedicamentData(int idMedicament);
    }
}
