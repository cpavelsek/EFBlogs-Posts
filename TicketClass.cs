using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tickets.csv
{
    public class TicketClass
    {
        public UInt64 ticketID { get; set; }
        public string summary { get; set; }
        public string watching { get; set; }
        public string assigned { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }

        public UInt64 TicketID
        {
            //grab the Ticket Number
            get
            {
                return this.ticketID;
            }
            //let user set ticket number
            set
            {

                this.ticketID = value;
            }
        }
        public virtual string DisplayTicket()
        {
            return $"{TicketID}{summary}{watching}{assigned}{status}{priority}{submitter}";
         
        }
        


    }

    public class Task : TicketClass
    {
        public string projectName { get; set; }
        public string dueDate { get; set; }

        public override string DisplayTicket()
        {
            return $"{ticketID}{summary}{watching}{assigned}{status}{priority}{submitter}{projectName}{dueDate}";

        }

    }

    public class Enhancements : TicketClass
    {
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public double estimate { get; set; }

        public override string DisplayTicket()
        {
            return $"{base.DisplayTicket()} Software: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}\n";
        }
    }
}
