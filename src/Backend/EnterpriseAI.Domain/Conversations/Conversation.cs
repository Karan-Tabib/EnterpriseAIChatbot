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

        public ConversationStatus Status { get; private set; }
        public IReadOnlyCollection<Message> Messages => _messages;


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
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Message content cannot be null or empty.", nameof(content));
            }

            var message = Message.CreateUserMessage(content);
            _messages.Add(message);
            message.IncrementSequenceNumber();
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


        public void GenerateTitle() { }
        public Message AddAssistantMessage(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException(nameof(content));

            var message = Message.CreateAssistantMessage(content);
            _messages.Add(message);
            message.IncrementSequenceNumber();
            UpdatedOn = DateTime.UtcNow;
            return message;

        }
        public void ClearHistory() { }
        public void GenerateSummary() { }

        public void Archive() { }

        public void Restore() { }

        public void Delete() { }
    }
}
