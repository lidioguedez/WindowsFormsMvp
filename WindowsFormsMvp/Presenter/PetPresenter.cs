using System;
using System.Collections.Generic;
using System.Data;
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
       // private DataTable dt;

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
            //if (entyValue == false)
            //    if (int.TryParse(this.view.SearchValue, out _))
            //    {
            //        dt = repository.GetById(Convert.ToInt32(this.view.SearchValue));
            //        petBindingSource.DataSource = dt;
            //    }
            //    else
            //    petList = repository.GetByValue(this.view.SearchValue);
            //else
            //{
            //    petList = repository.GetAll();
            //    petBindingSource.DataSource = petList;
            //} 

            if (entyValue == false)
                 petList = repository.GetByValue(this.view.SearchValue);
            else petList = repository.GetAll();
            petBindingSource.DataSource = petList;
            this.view.GridFocus();
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFields();

        }

        private void SavePet(object sender, EventArgs e)
        {
            var petModel = new PetModel();
            petModel.Id = Convert.ToInt32(view.PetID);
            petModel.name = view.PetNAme;
            petModel.type = view.PetType;
            petModel.colour = view.PetColour;
            try
            {
                new Common.ModelDataValidations().validate(petModel);
                if (view.IsEdit)
                {
                    repository.edit(petModel);
                    view.Message = "Pet edited successfulity";

                }
                else
                {
                    repository.add(petModel);
                    view.Message = "Pet added successfuly";
                }
                view.IsSuccessful = true;
                LoadAllPetList();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
                
            }
        }

        private void CleanViewFields()
        {
            view.PetID = "0";
            view.PetNAme = "";
            view.PetType = "";
            view.PetColour = "";
        }

        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            try
            {
                var pet = (PetModel)petBindingSource.Current;
                repository.delete(pet.Id);
                view.IsSuccessful = true;
                LoadAllPetList();
            }
            catch (Exception)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not delete pet";
            }
        }

        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            var pet = (PetModel)petBindingSource.Current;
            view.PetID =  pet.Id.ToString();
            view.PetNAme = pet.name;
            view.PetType = pet.type;
            view.PetColour = pet.colour;
            view.IsEdit = true;

        }

        private void AddNewPet(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

    }
}
