
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tickets.csv;

namespace TicketingSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            string file = "ticketInfo.txt";
            string userInput;
            TicketClass ticketInfo = new TicketClass();
            EnhancementsClass enhancements = new EnhancementsClass();
            TaskClass task = new TaskClass();
            do
            {
                //gather input to have user enter ticket
                Console.WriteLine("1 - Access Open Support Ticket");
                Console.WriteLine("2 - Submit New Support Ticket");      
                Console.WriteLine("Enter anything else to quit.");

                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    if (File.Exists(file))
                    {
                        ticketInfo.DisplayTicket();
                        enhancements.DisplayTicket();
                        
                   

                        StreamReader sr = new StreamReader(file);

                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            //form array
                            string[] ticketArray = line.Split(',');
                            //show data
                            
                            Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}\nSoftware: {7}, Cost: {8}, Reason: {9}, Estimate: {10}\nProject Name: {11}, Due Date: {12}",
                                             ticketArray[0], ticketArray[1], ticketArray[2], ticketArray[3], ticketArray[4], ticketArray[5], ticketArray[6], ticketArray[7], ticketArray[8], ticketArray[9], ticketArray[10], ticketArray[11], ticketArray[12]);
                            
                          
                           
                               
                        }

                        Console.WriteLine(" Please select from the options below.");

                    }
                    else
                    {
                        Console.WriteLine("Ticket ID not found");
                    }

                }
                else if (userInput == "2")
                {
                    //Create New Ticket
                    StreamWriter ticket = new StreamWriter(file);
                    for (int i = 0; i < 7; i++)
                    {

                        
                        //Start Gathering Ticket Info
                        Console.WriteLine("Enter a Ticket ID ");
                        //store response
                        ticketInfo.TicketID = UInt64.Parse(Console.ReadLine());
                        //Console.WriteLine(ticketInfo.TicketID);
                        //ticketInfo.ticketID = UInt64.Parse(ticketID);

                        Console.WriteLine("Please enter a Summary. ");
                        ticketInfo.summary = Console.ReadLine();
                        // string summary = Console.ReadLine();

                        Console.WriteLine("Is this Open Item? ");
                        ticketInfo.status = Console.ReadLine();
                        //string open = Console.ReadLine();

                        Console.WriteLine("How high of a Priority is this?  Please answer High, Medium or Low ");
                        ticketInfo.priority = Console.ReadLine();
                        //  string priority = Console.ReadLine();

                        Console.WriteLine("Enter Submitter Name. ");
                        ticketInfo.submitter = Console.ReadLine();
                        // string submitter = Console.ReadLine();

                        Console.WriteLine("Who do you want this assigned to. ");
                        ticketInfo.assigned = Console.ReadLine();
                        //string assigned = Console.ReadLine();

                        Console.WriteLine("Who do you want to watch this. ");
                        ticketInfo.watching = Console.ReadLine();
                        // string watcher = Console.ReadLine();

                        Console.WriteLine("Would you like to add enhancements? (Yes to add)");
                        string userAnswer = Console.ReadLine();
                        if(userAnswer == "yes" || userAnswer == "Yes")
                        {
                            Console.WriteLine("What Software are you using?");
                            enhancements.software = Console.ReadLine();
                            Console.WriteLine("What is the cost?");
                            enhancements.cost = double.Parse(Console.ReadLine());
                            Console.WriteLine("What is the reason?");
                            enhancements.reason = Console.ReadLine();
                            Console.WriteLine("What is the estimate?");
                            enhancements.estimate = double.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Would you like to add a task? (Yes to add)");
                        string useranswerTwo = Console.ReadLine();
                        if(useranswerTwo == "yes" || useranswerTwo == "Yes")
                        {
                            Console.WriteLine("Please enter a project name.");
                            task.projectName = Console.ReadLine();
                            Console.WriteLine("Please enter a due Date");
                            task.dueDate = Console.ReadLine();
                            task.DisplayTicket();
                        }

                       

                     


                        //save information
                        ticket.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", ticketInfo.TicketID, ticketInfo.summary, ticketInfo.status, ticketInfo.priority, ticketInfo.submitter, ticketInfo.assigned, ticketInfo.watching,
                            enhancements.software, enhancements.cost, enhancements.reason, enhancements.estimate,
                            task.projectName, task.dueDate);
                        break;
                    }
                    ticket.Close();
                }
            }
            while (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4");
        }
    }
}