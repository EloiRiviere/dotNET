using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.TextFormatting;

namespace PasswordsManager.Models
{
    public class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string Label { get; set; }

        [InverseProperty(nameof(PasswordTag.Tag))]
        public List<PasswordTag> Passwords { get; set; }

        public Tag(int id, string label, List<PasswordTag> passwords)
        {
            this.Id = id;
            this.Label = label;
            this.Passwords = passwords;
        }
    }
}
