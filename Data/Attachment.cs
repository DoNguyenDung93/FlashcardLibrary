namespace FlashcardLibrary.Data
{
    public class Attachment : Base
    {
        public Attachment(int type) 
        {
            this.AttachmentType = type;
        }

        public int AttachmentType { get; set; }
        public string? Example { get; set; }
    }

    public enum AttachmentTypeEnum
    {
        Meaning = 0,
        Pronunciation = 1,
        Synonym = 2,
        Antonym = 3,
    }
}
