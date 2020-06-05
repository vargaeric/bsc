using System;
using System.Collections.Generic;

namespace PersonalAgenda
{
    internal class Activity
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<int> Participants { get; }

        public Activity(
            int id,
            string name,
            string description,
            string startDate,
            string endDate,
            List<int> participants
        )
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = ProcessData.getDateTimeFormat(startDate);
            EndDate = ProcessData.getDateTimeFormat(endDate);
            Participants = participants;
        }

        public override string ToString()
        {
            string output = "";

            output += $"-----Activity ({Id})----------\n";
            output += $"Name: {Name}\n";
            output += $"Description: {Description}\n";
            output += $"Start date: {ProcessData.getDateTimeInString(StartDate)}\n";
            output += $"End date: {ProcessData.getDateTimeInString(EndDate)}\n";
            output += $"Participants: {string.Join(", ", Participants.ToArray())}\n";
            output += "---------------------------\n\n";

            return output;
        }
    }
}