namespace FlashcardLibrary.Data
{
    public class Attachment : Base
    {
        public Attachment() {}
        public Guid? FlashcardID { get; set; }
        public Flashcard? Flashcard { get; set; }
        public int Order { get; set; }
        public string? Definition { get; set; }
        public string? Pronunciation { get; set; }
        public string? Synonym { get; set; }
        public string? Example { get; set; }
        public byte[]? Sound { get; set; }
    }
}
