using System;
using System.Collections.Generic;
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
        PetModel GetById(int id);
        IEnumerable<PetModel> GetAll();
        IEnumerable<PetModel> GetByValue();

    }
}
