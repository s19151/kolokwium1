using Kolokwium.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DAL
{
    public interface IDbService
    {
        public MedicamentDataResponse GetMedicamentData(int idMedicament);
        public void DeletePatient(int idPatient);
    }
}
