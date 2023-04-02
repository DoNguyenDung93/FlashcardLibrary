namespace FlashcardLibrary.Data
{
    public class Attachment : Base
    {
        public Attachment(int attachmentType) 
        {
            this.AttachmentType = attachmentType;
        }
        public Guid? FlashcardID { get; set; }
        public Flashcard? Flashcard { get; set; }

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
