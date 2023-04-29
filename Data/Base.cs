using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public void Save()
        {
            if (CreatedDateTime == DateTime.MinValue)
                CreatedDateTime = DateTime.Now;

            UpdatedDateTime = DateTime.Now;
        }

        [NotMapped]
        public bool IsDeletedBool
        {
            get => IsDeleted == GlobalVariable.GlobalYesFlag;
            set 
            {    
                if (value == true)
                    IsDeleted = GlobalVariable.GlobalYesFlag;
                else
                    IsDeleted = GlobalVariable.GlobalNoFlag;
            }
        }
    }
}
