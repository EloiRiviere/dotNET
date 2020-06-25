using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordsManager.Models
{
    public class Password
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Pass { get; set; }

        public string Url { get; set; }

        [InverseProperty(nameof(PasswordTag.Password))]
        public List<PasswordTag> Tags { get; set; }

        override
        public string ToString()
        {
            return "Id : " + this.Id + " | Login : " + this.Login + " | Label : " + this.Label + " | Pass : " + this.Pass + " | Url : " + this.Url + " | Tags : " + this.Tags;
        }
    }
}
