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

        public IEnumerable<PetModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PetModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}
