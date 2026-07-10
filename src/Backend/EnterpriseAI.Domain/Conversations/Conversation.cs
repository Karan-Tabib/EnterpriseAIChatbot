using System;

namespace EnterpriseAI.Domain
{
    public class Conversation
    {

        public Guid Id { get; private set; }

        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; set; }

        public string Title { get; private set; }


        private readonly List<Message> _messages;

        public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();


        private Conversation()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = CreatedOn;
            Title = "New Conversation";
            _messages = [];
        }

        public static Conversation Create()
        {
            return new Conversation();
        }

        public void AddUserMessage(string content)
        {
            if (content == null || String.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Message content cannot be null or empty.", nameof(content));
            }
           
            _messages.Add(Message.CreateUserMessage(content));
        }
       
        public void Rename(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(nameof(title));

            Title = title.Trim();

            UpdatedOn = DateTime.UtcNow;
        }
        public void UpdateTitle(string title)
        {
            Title = title;
            UpdatedOn = DateTime.UtcNow;
        }

        public void Archive() { }

        public void GenerateTitle() { }
        public void AddAssistantMessage() { }
        public void ClearHistory() { }
        public void GenerateSummary() { }
    }
}
