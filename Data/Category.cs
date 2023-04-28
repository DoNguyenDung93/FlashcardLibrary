namespace FlashcardLibrary.Data
{
    public class Category: Base
    {
        public Category(string ObjectName) 
        {
            this.ObjectName = ObjectName;
        }

        public List<Flashcard>? Flashcards { get; set; }
    }
}
