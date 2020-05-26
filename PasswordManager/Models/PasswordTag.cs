using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordsManager.Models
{
    public class PasswordTag
    {
        public int PasswordId { get; set; }

        public int TagId { get; set; }

        [ForeignKey(nameof(PasswordId))]
        public Password Password { get; set; }

        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; }

        public PasswordTag(int passwordid, int tagid, Password password, Tag tag)
        {
            this.PasswordId = passwordid;
            this.TagId = tagid;
            this.Password = password;
            this.Tag = tag;
        }
    }
}
