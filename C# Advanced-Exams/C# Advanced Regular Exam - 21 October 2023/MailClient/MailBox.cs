namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            this.Capacity = capacity;
            this.Inbox = new List<Mail>();
            this.Archive = new List<Mail>();
        }
        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Capacity > Inbox.Count)
                Inbox.Add(mail);
        }

        public bool DeleteMail(string sender)
        {
            Mail mail = Inbox.FirstOrDefault(m => m.Sender == sender);
            
            return Inbox.Remove(mail);
        }

        public int ArchiveInboxMessages()
        {
            int count = Inbox.Count;
            Archive = Inbox.ToList();
            Inbox.Clear();
            return count;
        }

        public string GetLongestMessage()
        {
            return Inbox.OrderByDescending(m => m.Body.Length).First().ToString();
        }

        public string InboxView()
        {
            return "Inbox:" +
                   Environment.NewLine +
                   string.Join(Environment.NewLine, Inbox);
        }
    }
}
