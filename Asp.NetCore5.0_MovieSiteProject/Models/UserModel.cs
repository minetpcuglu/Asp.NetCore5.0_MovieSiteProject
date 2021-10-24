using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(20,ErrorMessage ="Max 20 karakter içermeli")]
        public string    UserName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "{0} Karakter uzunlugu {2}-{1} aralıgında olmalıdır",MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress()]
        public string Mail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")] //karsılastırma
        public string RePassword { get; set; }
        
        [Url]
        public string Url { get; set; }
    
        [Range(1900,2021)]
        public int BirthYear { get; set; }
    }
}
