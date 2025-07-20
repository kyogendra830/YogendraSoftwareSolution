    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogendraSoftwareSolution.Model.Models
{
    public class RegistrationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Gender { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string PhonenNo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
        public DateTime? DOB { get; set; }
    }
}
