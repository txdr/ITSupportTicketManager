using System;
using System.Collections.Generic;
using System.Text;

namespace ITSupportTicketManager
{
    public class Ticket
    {
        private string _id = "";
        private string _description = "";
        private string _priority = "Low";
        private string _status = "Open";

        public static readonly string[] AllowedPriorities = { "Low", "Medium", "High" };
        public static readonly string[] AllowedStatuses = { "Open", "In Progress", "Closed" };

        public string Id
        {
            get => _id;
            set => _id = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Id cannot be empty.")
                : value.Trim();
        }

        public string Description
        {
            get => _description;
            set => _description = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Description cannot be empty.")
                : value.Trim();
        }

        public string Priority
        {
            get => _priority;
            set
            {
                var v = (value ?? "").Trim();
                if (Array.IndexOf(AllowedPriorities, v) < 0)
                    throw new ArgumentException($"Priority must be one of: {string.Join(", ", AllowedPriorities)}");
                _priority = v;
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                var v = (value ?? "").Trim();
                if (Array.IndexOf(AllowedStatuses, v) < 0)
                    throw new ArgumentException($"Status must be one of: {string.Join(", ", AllowedStatuses)}");
                _status = v;
            }
        }

        public DateTime DateCreated { get; private set; } = DateTime.UtcNow;

        public Ticket() { }

        public Ticket(string id, string description, string priority, string status)
        {
            Id = id;
            Description = description;
            Priority = priority;
            Status = status;
            DateCreated = DateTime.UtcNow;
        }

        public void CloseTicket() => Status = "Closed";

        public void ReopenTicket() => Status = "Open";

        public string GetSummary() =>
            $"[{Id}] ({Priority}) \"{Description}\" | Status: {Status} | Created (UTC): {DateCreated:yyyy-MM-dd HH:mm}";

    }
}
