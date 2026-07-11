namespace EnterpriseAI.Domain
{

    public class Message 
    {
        public Guid Id { get; private set; }

        public MessageRole Role { get; private set; }

        public string Content { get; private set; } 

        public DateTime CreatedOn { get; private set; }


        public Message(string content)
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            Content = content;

        }

        public void Edit() { }

        public void AddAttachment() { }

        public void AddCitation() { }

        public static Message CreateUserMessage(string content)
        {
            var msg = new Message(content);
            msg.Role = MessageRole.User;
           
            return msg;
        }

        public static Message CreateAssistantMessage(string content)
        {
            var msg = new Message(content);
            msg.Role = MessageRole.Assistant;
            return msg;
        }

        public static Message CreateSystemMessage(string content)
        {
            var msg = new Message(content);
            msg.Role = MessageRole.System;
            return msg;
        }
    }
}
