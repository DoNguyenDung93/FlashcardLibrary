namespace FlashcardLibrary.Data
{
    public class Flashcard : Base
    {
        public Flashcard(string ObjectName)
        {
            this.ObjectName = ObjectName;
            this.Attachments = new();
        }

        public List<Attachment> Attachments { get; set; }
        public List<Attachment> Meanings { get => GetAttachments((int)AttachmentTypeEnum.Meaning); }
        public List<Attachment> Pronunciations { get => GetAttachments((int)AttachmentTypeEnum.Pronunciation); }
        public List<Attachment> Synonyms { get => GetAttachments((int)AttachmentTypeEnum.Synonym); }
        public List<Attachment> Antonyms { get => GetAttachments((int)AttachmentTypeEnum.Antonym); }
        
        private List<Attachment> GetAttachments(int type) => Attachments.FindAll(x => x.AttachmentType == type).ToList();
    }
}
