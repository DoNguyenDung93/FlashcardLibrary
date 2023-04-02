using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FlashcardLibrary.Data
{
    public abstract class Base
    {
        [Key]
        public Guid ObjectID { get; set; }

        [Required]
        public string ObjectName { get; set; } = string.Empty;
        public int IsDeleted { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
