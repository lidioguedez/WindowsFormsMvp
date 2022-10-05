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
        private bool isSuccessful;
        private bool isEdit;


        public PetView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl.TabPages.Remove(tabPagePetDetail);
            this.dataGridView1.Select();
        }

        //Propiedades
        public string PetID
        {
            get { return txtPetId.Text; }
            set { txtPetId.Text = value; }
        }
        public string PetNAme
        {
            get { return txtPetName.Text; }
            set { txtPetName.Text = value; }
        }
        public string PetType
        {
            get { return txtPetType.Text; }
            set { txtPetType.Text = value; }
        }
        public string PetColour
        {
            get { return txtPetColour.Text; }
            set { txtPetColour.Text = value; }
        }
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private void AssociateAndRaiseViewEvents()
        {
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                //Ejemplo directo sin metodo
                // this.dataGridView1.Select();
            };
            btnSerach.Click += (s, e) => 
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
                //Ejemplo directo sin metodo
               // this.dataGridView1.Select();
            };
            btnAddNew.Click += delegate { 
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl.TabPages.Remove(tabPageList);
                tabControl.TabPages.Add(tabPagePetDetail);
                tabPagePetDetail.Text = "Add New Pet";
            };
            btnEdit.Click += delegate {
                EditControl();
            };
            btnDelete.Click += delegate {
                var result = MessageBox.Show("Estas seguro de eliminar la mascota seleccionada", "Advertencia",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(message);
                }
            };
            btnSave.Click += delegate { 
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl.TabPages.Remove(tabPagePetDetail);
                    tabControl.TabPages.Add(tabPageList);
                    tabPagePetDetail.Text = "Pet list";
                }
               
                txtSearch.Text = "";
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                txtSearch.Focus();
                MessageBox.Show(message);
            };
            btnCancel.Click += delegate {
                tabControl.TabPages.Remove(tabPagePetDetail);
                tabControl.TabPages.Add(tabPageList);
                tabPagePetDetail.Text = "Pet list";
                CancelEvent?.Invoke(this, EventArgs.Empty);
                this.dataGridView1.Select();
            };

            dataGridView1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EditControl();
                }
            };

            dataGridView1.CellDoubleClick += delegate
            {
                EditControl();
            };

        }


        //Eventos
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        private void EditControl()
        {
            EditEvent?.Invoke(this, EventArgs.Empty);
            tabControl.TabPages.Remove(tabPageList);
            tabControl.TabPages.Add(tabPagePetDetail);
            tabPagePetDetail.Text = "Edit Pet";
            txtPetId.Focus();
        }

        //Metodos
        public void SetPetListBindingSource(BindingSource petList)
        {
            dataGridView1.DataSource = petList;
        }

        private static PetView instance;
        public static PetView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PetView();
                instance.MdiParent = parentContainer;
                instance.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }

            return instance;
        }

        

        //Ejemplo con Metodo
        public void GridFocus()
        {
            this.dataGridView1.Select();
        }

        private void txtPetId_KeyDown(object sender, KeyEventArgs e)
        {
            goFocusControlTxt(sender,e);
        }

        private void txtPetName_KeyDown(object sender, KeyEventArgs e)
        {
            goFocusControlTxt(sender, e);
        }

        private void txtPetType_KeyDown(object sender, KeyEventArgs e)
        {
            goFocusControlTxt(sender, e);
        }

        private void txtPetColour_KeyDown(object sender, KeyEventArgs e)
        {
            goFocusControlTxt(sender, e);
        }

        private void goFocusControlTxt(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
