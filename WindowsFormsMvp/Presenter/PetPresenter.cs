using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMvp.Model;
using WindowsFormsMvp.View;

namespace WindowsFormsMvp.Presenter
{
    public class PetPresenter
    {
        private IPetView view;
        private IPetRepository repository;
        private BindingSource petBindingSource;
        private IEnumerable<PetModel> petList;

        public PetPresenter(IPetView view, IPetRepository repository)
        {
            this.petBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler method to view events 
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;
            //Set Pet binding source
            this.view.SetPetListBindingSource(petBindingSource);
            //Load Pet list view
            LoadAllPetList();
            //Grid Focus
            this.view.GridFocus();
            //Show view
            this.view.Show();
        }

        private void LoadAllPetList()
        {
            petList = repository.GetAll();
            petBindingSource.DataSource = petList;
        }

        private void SearchPet(object sender, EventArgs e)
        {
            bool entyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (entyValue == false)
                petList = repository.GetByValue(this.view.SearchValue);
            else petList = repository.GetAll();
            petBindingSource.DataSource = petList;
            this.view.GridFocus();
        }

        private void CancelAction(object sender, EventArgs e)
        {
            
        }

        private void SavePet(object sender, EventArgs e)
        {
            
        }

        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewPet(object sender, EventArgs e)
        {
            
        }

    }
}
