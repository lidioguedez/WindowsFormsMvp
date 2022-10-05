using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMvp.Model
{
    public interface IPetRepository
    {
        void add(PetModel petModel);
        void edit(PetModel petModel);
        void delete(int id);
        DataTable GetById(int id);
        IEnumerable<PetModel> GetAll();
        IEnumerable<PetModel> GetByValue(string value);

    }
}
