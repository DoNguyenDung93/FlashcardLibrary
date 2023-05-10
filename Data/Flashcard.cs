using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace FlashcardLibrary.Data
{
    public class Flashcard : Base
    {
        public Flashcard(string ObjectName)
        {
            this.ObjectName = ObjectName;
        }
        public Guid? CategoryID { get; set; }
        public Category? Category { get; set; }

        public List<Attachment>? Attachments { get; set; }
        public List<Attachment>? Meanings { get => GetAttachments((int)AttachmentTypeEnum.Meaning); }
        public List<Attachment>? Pronunciations { get => GetAttachments((int)AttachmentTypeEnum.Pronunciation); }
        public List<Attachment>? Synonyms { get => GetAttachments((int)AttachmentTypeEnum.Synonym); }
        public List<Attachment>? Antonyms { get => GetAttachments((int)AttachmentTypeEnum.Antonym); }
        public List<Attachment>? Examples { get => GetAttachments((int)AttachmentTypeEnum.Example); }

        private List<Attachment>? GetAttachments(int type)
        {
            if (Attachments != null) {
                return Attachments.FindAll(x => x.AttachmentType == type).ToList();
            }
            return null;
        }

        public static async void GetFlashCard(string searchTerm, bool isUsingDefaultAPI, Flashcard flashcard)
        {
            string dictionaryURL = GetAPIURL(searchTerm, isUsingDefaultAPI);

            // TODO: do API call to return the flashcard.
            var responseString = await GlobalVariable.client.GetStringAsync(dictionaryURL);
            dynamic responseArray = JArray.Parse(responseString);
            foreach (var item in responseArray)
            {
                // Deserialize JSON to flashcard
            }
        }

        private static string GetAPIURL(string searchTerm, bool isUsingDefaultAPI)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var url = isUsingDefaultAPI ? configuration.GetSection("DefaultAPI").GetValue<String>("URL") : configuration.GetSection("MedicalAPI").GetValue<String>("URL");
            var key = isUsingDefaultAPI ? configuration.GetSection("DefaultAPI").GetValue<String>("Key") : configuration.GetSection("MedicalAPI").GetValue<String>("Key");

            url ??= string.Empty;
            key ??= string.Empty;

            return String.Concat(url, "/", searchTerm, "?key=", key);
        }
    }
}
