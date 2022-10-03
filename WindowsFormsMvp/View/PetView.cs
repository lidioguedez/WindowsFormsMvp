using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMvp.View
{
    public partial class PetView : Form, IPetView
    {
        private string message;
        private bool isSuccessfu;
        private bool isEdit;


        public PetView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl.TabPages.Remove(tabPagePetDetail);
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSerach.Click += delegate { SearchEvent?.Invoke(this,EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter )
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };


        }

        //Propiedades
        public string PetID {
            get { return txtPetId.Text; }
            set { txtPetId.Text = value; }
        }
        public string PetNAme {
            get { return txtPetName.Text; }
            set { txtPetName.Text = value; }
        }
        public string PetType {
            get { return txtPetType.Text; }
            set { txtPetType.Text = value; }
        }
        public string PetColour {
            get { return txtPetColour.Text; }
            set { txtPetColour.Text = value; }
        }
        public string SearchValue {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit {
            get { return isEdit; }
            set { isEdit = value; } 
        }
        public bool IsSuccessful {
            get { return isSuccessfu; }
            set { IsSuccessful = value; } 
        }
        public string Message {
            get { return message; }
            set { message = value; } 
        }


        //Eventos
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;


        //Metodos
        public void SetPetListBindingSource(BindingSource petList)
        {
            dataGridView1.DataSource = petList;
        }

    }
}
