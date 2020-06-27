using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ForumDomain
{
    public class Theme : ITheme
    {

        public DateTime publishedON { get; set; }

        public string Name { get; set; }

        public string Describtion { get; set; }

        public IUse User { get; set; }

        public ICategory categorie { get; set; }

        public Dictionary<IUse, IRate> UserRatings { get; set; } = new Dictionary<IUse, IRate>();

        public List<IComment> Comments { get; set; } = new List<IComment>();

        public List<IUse> UsersFollowing { get; set; } = new List<IUse>();

        internal long _views = 0;
        public long View { get { return _views; } set { _views = value; } }


        public Theme(string n, string desc, IUse a, ICategory cat)
        {
            this.Name = n;
            this.Describtion = desc;
            this.User = a;
            this.categorie = cat;
            publishedON = DateTime.Now;
            View = 0;


        }


        public void ShowThemeInfo()
        {
            Console.WriteLine($"Theme name: {Name}" +
                              $"\r\n Author: {User.Nickname}" +
                              $"\r\n Category: {categorie.Name}" +
                              $"\r\n Describtion: {Describtion}" +
                              $"\r\n Date published: {publishedON}" +
                              $"\r\n Numbers of views: {_views}");
        }


        public void ShowAllComments()

        {
            var themeComments = from com in Comments
                                orderby com.CreatedOn
                                select com;
            foreach (var comment in themeComments)
            {

                Console.WriteLine($"{comment.Author.Nickname} said:\r\n" +
                                  $"{comment.Message} \r\n" +
                                  $"commented on: {comment.CreatedOn} \r\n" +
                                  $"about the topic: {comment.Theme.Name}");

            }
        }


        public void AverageThemeRating()
        {
            if (UserRatings.Count < 1)
            {
                throw new Exception($"This theme {Name} has not rating.");
            }

            else
            {
                var values = from score in UserRatings
                             select score.Value.Score;
                double average = values.Average(num => Convert.ToDouble(num));
                Console.Write(average);
            }
        }



        public void UsersFollowingTheme()
        {
            var usersFollowing = from user in UsersFollowing
                                 select user.Nickname;
            Console.Write("Users following: ");

            if (UsersFollowing.Count < 1)
            {
                throw new Exception("No users following this theme");
            }
            else
            {


                foreach (var userN in usersFollowing)
                {

                    Console.Write(userN);
                }
            }
        }

        public bool IsThemeInCategoryCheckByName(List<ITheme> themes, string themeName)
          => themes.Any(t => t.Name == themeName);

        public bool IsThemeInCategoryCheckByDescription(List<ITheme> themes, string themeName)
          => themes.Any(t => t.Describtion == Describtion);


    }
}
    