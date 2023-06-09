﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace FlashcardLibrary.Data
{
    public class Flashcard : Base
    {
        public Flashcard(string ObjectName)
        {
            this.ObjectName = ObjectName;
            Attachments ??= new List<Attachment>();
        }
        public Guid? CategoryID { get; set; }
        public Category? Category { get; set; }

        public List<Attachment> Attachments { get; set; }

        public static async Task<Flashcard> GetFlashCard(bool isUsingDefaultAPI, string searchTerm)
        {
            using var context = new FlashcardContext();
            List<Flashcard> existingFlashcards = context.Flashcard.ToList();
            Flashcard existingCard = existingFlashcards.Find(x => x.ObjectName == searchTerm) ?? new(searchTerm);
            if (existingFlashcards.Find(x => x.ObjectName == searchTerm) != null)
            {
                return existingCard;
            }
            string dictionaryURL = GetAPIURL(existingCard.ObjectName, isUsingDefaultAPI);

            // T API call to return the flashcard.
            var responseString = await GlobalVariable.client.GetStringAsync(dictionaryURL);
            dynamic responseArray = JArray.Parse(responseString);
            int count = 1;
            foreach (dynamic item in responseArray)
            {
                if ((((String)item.meta.id).StartsWith(existingCard.ObjectName + ":") || ((String)item.meta.id) == existingCard.ObjectName) && item.shortdef != null) {
                    // Deserialize JSON to flashcard
                    existingCard.Attachments.Add(GenerateFlashcardData(item, count++));
                }
            }

            
            foreach (Attachment att in existingCard.Attachments)
            {
                att.Save();
            }
            existingCard.Save();
            context.Flashcard.Add(existingCard);
            context.SaveChanges();

            return existingCard;
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

        private static Attachment GenerateFlashcardData(dynamic item, int order)
        {
            Attachment attachment = new()
            {
                Order = order,
                Pronunciation = item.hwi != null && item.hwi.prs != null ? item.hwi.prs[0].mw : string.Empty,
                Definition = String.Join(", ", item.shortdef),
                //Sound = item.hwi != null && item.hwi.prs != null ? item.hwi.prs[0].sound.audio : string.Empty,
            };
            return attachment;
        }

        public string DisplayData
        {
            get
            {
                StringBuilder result = new();

                result.Append(this.ObjectName);
                result.Append(Environment.NewLine);

                foreach (Attachment attachment in this.Attachments)
                {
                    result.Append(attachment.Order);
                    result.Append(' ');
                    result.Append('[');
                    result.Append(attachment.Pronunciation);
                    result.Append(']');
                    result.Append(": ");
                    result.Append(attachment.Definition);
                    result.Append(Environment.NewLine);
                }

                return result.ToString();
            }
        }
    }
}
