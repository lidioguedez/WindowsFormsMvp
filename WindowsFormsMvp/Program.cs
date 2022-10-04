using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMvp.Model;
using WindowsFormsMvp.View;
using System.Configuration;
using WindowsFormsMvp.Presenter;

namespace WindowsFormsMvp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnection = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
            //IPetView view = new PetView();
            //IPetRepository repository = new PetRepository(sqlConnection);
            //new PetPresenter(view,repository);
            IMainView view = new MainView();
            new MainPresenter(view, sqlConnection);
            Application.Run((Form)view);
        }
    }
}
