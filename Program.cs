using System;
using System.Text;
using System.Drawing;


namespace ForumDomain
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Division hardware = Factory.CreateDivision("Hardware");
            ICategory processor = Factory.CreateCategory(hardware, "Процесори, памети, охлаждания, захранвания, оувърклок", "Всичко за компонентите и овърклока");
            var videoCard = Factory.CreateCategory(hardware, "Видеокарти", "Охлажданe, овърклок, тестове за производителност");
            Console.WriteLine();
            hardware.PrintListofCategories();
            Console.WriteLine();
            hardware.DeleteCategory(processor);
            
            Console.WriteLine();
            hardware.PrintListofCategories();
            Console.ReadKey();
            Console.Clear();

            var jay = Factory.CreateUser("Jay","qwerty@qwerty.com");
            Console.WriteLine();
            var rey = Factory.CreateUser("Rey","examle@example.com");
            Console.WriteLine();
            var faye = Factory.CreateUser("Faye","faye@gmail.com");

            jay.ChangePassword();
            
            
            Console.ReadKey();
            Console.Clear();
            
            var nvidia = Factory.CreateTheme("Nvidia", "Rate with one sentence", jay, videoCard);
            Theme amd = Factory.CreateTheme("AMD", "Rate with one sentence", rey, processor);
            rey.FollowTheme(nvidia);

            nvidia.ShowThemeInfo();
            jay.ViewTheme(nvidia);
            jay.AddComment(nvidia, "Overpriced");
            rey.ViewTheme(nvidia);
            rey.AddComment(nvidia, "the best!!!");
            faye.ViewTheme(nvidia);
            faye.AddComment(nvidia, "suggesting it.");
            nvidia.ShowAllComments();

            Console.ReadKey();
            Console.Clear();

            rey.RateTheme(nvidia, 5);
            jay.RateTheme(nvidia, 3);
            faye.RateTheme(nvidia, 8);
            Console.Write($"{nvidia.Name}theme average rating is: ");
            nvidia.AverageThemeRating();
            Console.WriteLine();       
            Console.WriteLine($"{nvidia.Name} theme has been viewed:{nvidia._views} times");


            Console.ReadKey();
            Console.Clear();
           

            jay.FollowTheme(amd);

            amd.UsersFollowingTheme();
            jay.PrintFollowedThemes();

            faye.AddComment(amd, "Quick question for the topic? ");
            rey.AddComment(amd, "Quick answer....");
            jay.ViewNotifications();

            Console.WriteLine(jay.NotificationsSentToUser.Count);

        }
    }
}
