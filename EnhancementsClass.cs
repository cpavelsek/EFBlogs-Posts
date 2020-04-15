using System;
using System.Collections.Generic;
using System.Text;

namespace Tickets.csv
{
    class EnhancementsClass
    {
        public UInt64 ticketID { get; set; }
        public string summary { get; set; }
        public string watching { get; set; }
        public string assigned { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public double estimate { get; set; }


        public string DisplayTicket()
        {
            return $"{ticketID}{summary}{watching}{assigned}{status}{priority}{submitter}{software}{cost}{reason}{estimate}";


        }


    }
    
}
