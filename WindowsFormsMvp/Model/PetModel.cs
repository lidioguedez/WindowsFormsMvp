using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsMvp.Model
{
    public class PetModel
    {
        //campos
        [DisplayName("Pet ID")]
        public int Id { get; set; }

        [DisplayName("Pet Name")]
        [Required(ErrorMessage= "Pet name is requerid")]
        [StringLength(50,MinimumLength = 3,ErrorMessage = "Pet name must be between 3 and 50 characters")]
        public string name { get; set; }

        [DisplayName("Pet Type")]
        [Required(ErrorMessage = "Pet type is requerid")]
        [StringLength(50,MinimumLength =3,ErrorMessage = "Pet type must be between 3 and 50 characters")]
        public string type { get; set; }

        [DisplayName("Pet Colour")]
        [Required(ErrorMessage = "Pet Colour is requerid" )]
        [StringLength(50,MinimumLength =3,ErrorMessage = "Pet colour must be between 3 and 50 characters")]
        public string colour { get; set; }
    }
}
