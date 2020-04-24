using NLog;
using BlogsConsole.Models;
using System;
using System.Linq;

namespace BlogsConsole
{
    class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            logger.Info("Program started");
            try
            {
                var db = new BloggingContext();
                //initialize users choice
                string UserChoice = "";

                // display choices to user
                Console.WriteLine("1) Add a Blog");
                Console.WriteLine("2) Create New Post");
                Console.WriteLine("3) Display All Blogs");
                UserChoice = Console.ReadLine();

                if(UserChoice == "1") { 
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };

                
                db.AddBlog(blog);
                logger.Info("Blog added - {name}", name);
                }

                if(UserChoice == "2")
                {

                    var query = db.Blogs.OrderBy(b => b.Name);

                    Console.WriteLine("All blogs in the database:");
                    foreach (var item in query)
                    {
                        Console.WriteLine($"{item.BlogId}) {item.Name}");
                    }
                    Console.Write("Select which blog you would like to post to.");
                    var blogSelection = Console.ReadLine();

                    //Add New Post
                    Console.Write("Enter your new post Title: ");
                    var postTitle = Console.ReadLine();
                    Console.Write("Enter your post Content: ");
                    var postContent = Console.ReadLine();

                    var addPost = new Post { Title = postTitle, Content = postContent };

                    db.AddPost(addPost);
                    logger.Info("Post added - {postTitle}", postTitle);
                }

                if(UserChoice == "3") { 
                // Display all Blogs from the database
                var query = db.Blogs.OrderBy(b => b.Name);

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}