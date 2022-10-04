using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMvp.Repositories;
using System.Data.SqlClient;
using System.Data;
using WindowsFormsMvp.Model;

namespace WindowsFormsMvp.View
{
    public class PetRepository : BaseRepository, IPetRepository
    {
        public PetRepository(string connectionString)
        {
            this.connectionstring = connectionString;
        }


        public void add(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public void edit(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public PetModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetModel> GetAll()
        {
            var listPets = new List<PetModel>();

            using (var connection = new SqlConnection(connectionstring))
            using (var cmd = new SqlCommand())
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText= "Select * From Pet order by Pet_Id desc";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.name = reader[1].ToString();
                        petModel.type = reader[2].ToString();
                        petModel.colour = reader[3].ToString();
                        listPets.Add(petModel);
                    }
                }
            }

                return listPets;
        }

        public IEnumerable<PetModel> GetByValue(string value)
        {
            var listPets = new List<PetModel>();
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;

            using (var connection = new SqlConnection(connectionstring))
            using (var cmd = new SqlCommand())
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = @"Select * From Pet 
                                    where Pet_Id=@id or Pet_Name like @name+'%'
                                    order by Pet_Id desc";
                cmd.Parameters.Add("@id",SqlDbType.Int).Value = petId;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = petName;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.name = reader[1].ToString();
                        petModel.type = reader[2].ToString();
                        petModel.colour = reader[3].ToString();
                        listPets.Add(petModel);
                    }
                }
            }

            return listPets;
        }
    }
}
