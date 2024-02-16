namespace MailClient
{
    public class Mail
    {
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Body { get; set; }

        public Mail (string sender, string reciever, string body)
        {
            Sender = sender;
            Reciever = reciever;
            Body = body;
        }

        public override string ToString()
        {
            return $"From: {Sender} / To: {Reciever}\n" +
                   $"Message: {Body}";
        }
    }
}
