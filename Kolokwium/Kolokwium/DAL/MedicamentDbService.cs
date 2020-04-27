using Kolokwium.DTO.Responses;
using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DAL
{
    public class MedicamentDbService : IDbService
    {
        private readonly string _dbConnectionString = "Data Source=db-mssql;Initial Catalog=s19151;Integrated Security=True";
        public MedicamentDataResponse GetMedicamentData(int idMedicament)
        {
            MedicamentDataResponse medicamentData = new MedicamentDataResponse();

            using (var con = new SqlConnection(_dbConnectionString))
            using (var cmd = con.CreateCommand())
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM Medicament WHERE IdMedicament = @id";
                cmd.Parameters.AddWithValue("id", idMedicament);

                var dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                    //dodac nowe klasy do rzucania specyficznych wyjatkow
                    throw new Exception("Brak leku o podanym Id");
                }

                Medicament med = new Medicament();
                med.IdMedicament = idMedicament;
                med.Name = dr["Name"].ToString();
                med.Description = dr["Description"].ToString();
                med.Type = dr["Type"].ToString();
                dr.Close();

                List<Prescription> presList = new List<Prescription>();
                cmd.CommandText = $"select Prescription.* from prescription" +
                    $"inner join prescription_medicament on prescription_medicament.idprescription = prescription.idprescription" +
                    $"where idmedicament = @id";

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Prescription pres = new Prescription();
                    pres.IdPrescription = Convert.ToInt32(dr["IdPrescription"].ToString());
                    pres.Date = dr["Date"].ToString();
                    pres.DueDate = dr["DueDate"].ToString();
                    pres.IdPatient = Convert.ToInt32(dr["IdPatient"].ToString());
                    pres.IdDoctor = Convert.ToInt32(dr["IdDoctor"].ToString());

                    presList.Add(pres);
                }
                dr.Close();
            }

            return medicamentData;
        }

        public void DeletePatient(int IdPatient)
        {
            using (var con = new SqlConnection(_dbConnectionString))
            using (var cmd = con.CreateCommand())
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SELECT 1 FROM Prescription WHERE IdPatient = @id";
                cmd.Parameters.AddWithValue("id", IdPatient);

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    throw new Exception("sa dane");
                }
                dr.Close();

                cmd.CommandText = "DELETE FROM Patient WHERE IdPatient = @id";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
