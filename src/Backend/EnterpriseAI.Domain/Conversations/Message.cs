namespace EnterpriseAI.Domain
{

    public class Message
    {
        public Guid Id { get; private set; }

        public MessageRole Role { get; private set; }

        public string Content { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public int SequenceNumber { get; private set; }

        private Message()
        {
            // Required by EF
        }
        private Message(
                MessageRole role,
                string content)
        {
            Id = Guid.NewGuid();
            Role = role;
            Content = content;
            SequenceNumber = 0;
            CreatedOn = DateTime.UtcNow;
        }

        public void Edit() { }

        public void AddAttachment() { }

        public void AddCitation() { }

        private static Message Create(MessageRole role, string content)
        {   
            return new Message(role, content);
        }
        public static Message CreateUserMessage(string content)
        {
           
            return Create(MessageRole.User, content);
        }

        public static Message CreateAssistantMessage(string content)
        {
            return Create(MessageRole.User, content);
        }

        public static Message CreateSystemMessage(string content)
        {
            return Create(MessageRole.User, content);

        }

        public void IncrementSequenceNumber()
        {
            SequenceNumber++;
        }
    }
}
