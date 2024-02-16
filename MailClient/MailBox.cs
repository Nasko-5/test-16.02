using MailClient;
using System.Collections.Generic;
using System;

namespace MailClient
{
    public class MailBox
    {
        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        //•	Method IncomingMail(Mail mail) – adds an entry to the Inbox collection, if the Capacity allows it.
        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count + 1 <= Capacity)
            {
                //Console.WriteLine("Adding mail");
                Inbox.Add(mail);
            } else
            {
                //Console.WriteLine($"Inbox full!");
            }
        }

        //•	Method DeleteMail(string sender) – Finds and removes the first mail from the Inbox by a given sender, if such exists, and returns boolean(true if it is removed, otherwise – false)
        
        public bool DeleteMail(string sender)
        {
            try
            {
                //Console.WriteLine($"Deleting mail of {sender}");
                Inbox.Remove(Inbox.First(a => a.Sender == sender));
                return true;
            } catch
            {
                //Console.WriteLine($"Couldnt find mail from {sender}");
                return false;
            }
        }

        //•	Method ArchiveInboxMessages() – The method moves all inbox mails to the Archive.Returns the number of mails moved.
        public int ArchiveInboxMessages()
        {
            //Console.WriteLine("Moving mail to archive...");
            int mailsMoved = Inbox.Count();
            foreach (Mail mail in Inbox)
            {
                Archive.Add(mail);
            }
            Inbox = new List<Mail>();
            return mailsMoved;
        }
        
        //•	Method GetLongestMessage() – returns the ToString() method of the Mail with the longest Body.
        public object GetLongestMessage()
        {
            //Console.WriteLine($"Getting longest message...");
            Mail a = Inbox.OrderByDescending(m => m.Body.Length).ToArray()[0];

            return a.ToString();
        }
        
        //•	Method InboxView() – returns a string in the following format:
        //   "Inbox:
        //   {Mail1}
        //   {Mail2}
        //   {…}
        //   {Mailn}
        public string InboxView()
        {
            return $"Inbox:\n{string.Join("\n", Inbox.Select(m => m.ToString()))}";
        }

    }
}
