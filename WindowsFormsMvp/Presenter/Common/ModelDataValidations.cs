using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsMvp.Presenter.Common
{
    public class ModelDataValidations
    {
        public void validate(object model)
        {
            string errorMessage = "";
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            if (isValid == false)
            {
                foreach(var iten in results)
                {
                    errorMessage += "- " + iten.ErrorMessage + "\n";
                    throw new Exception(errorMessage); 
                }
            }
        }
    }
}
