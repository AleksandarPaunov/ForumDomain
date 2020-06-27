using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForumDomain
{
    public class User : IUse
    {
        public Guid Id { get; set; }

        internal string nickname;

        internal static int guestList = 0;

        public string Email { get; set; }

        public string Password { get; set; }

        List<IComment> Comments { get; set; } = new List<IComment>();

        public List<ITheme> UserThemes { get; set; } = new List<ITheme>();

        Dictionary<ITheme, IRate> RatingsForThemes { get; set; } = new Dictionary<ITheme, IRate>();

        public List<ITheme> ThemesFollowed { get; set; } = new List<ITheme>();

        public IFollow Follow { get; set; }

        public Stack<INotify> NotificationsSentToUser { get; set; } = new Stack<INotify>();

        public string Nickname
        {

            get { return nickname; }
            set
            {
                if (value == null)
                {
                    guestList++;
                    nickname = "Guest" + guestList;
                }
                else
                {
                    nickname = value;
                }
            }
        }



        public User(string name, string email)


        {
            this.Id = Guid.NewGuid();
            this.Nickname = name;
            this.Password = PasswordGenerator.GeneratePassword();
            this.Email = email;

            Console.WriteLine($"User: {Nickname} is succesfully created.");
            Console.WriteLine($"Sending initial password {Password} to {Email}......");


        }

        public IComment AddComment(Theme them, string com)
        {
            var commen = Factory.CreateComment(com, this, them);
            them.Comments.Add((commen));
            Comments.Add(commen);

            return commen;

        }



        public void ShowAllUserComments()
        {
            if (Comments.Count < 1)
            {
                Console.WriteLine("This user does not have recorded comments");
            }
            else
            {


                var allUserComments = from com in Comments
                                      where com.Author == this
                                      select com;
                foreach (var com in Comments)
                {
                    Console.WriteLine($"{Nickname} created comment:" +
                                      $"\r\n{com.Message}" +
                                      $"\r\n In theme: {com.Theme.Name}" +
                                      $"\r\n Created on: {com.CreatedOn}");
                }
            }
        }



        public ITheme CreateTheme(string name, string describtion, ICategory cat)
        {
            ITheme th = Factory.CreateTheme(name, describtion, this, cat);
            if (th.IsThemeInCategoryCheckByName(th.categorie.Themes, name))
            {
                throw new Exception($"Theme {name} already exist in {th.categorie}");
            }
            else if (th.IsThemeInCategoryCheckByDescription(th.categorie.Themes, describtion))
            {
                throw new Exception($"Theme {describtion} already exist in {th.categorie}");

            }
            else
            {
                UserThemes.Add(th);
                th.User = this;
                return th;
            }
        }

        public void PrintCreatedThemes()
        {
            foreach (ITheme theme in UserThemes)
            {
                Console.WriteLine(UserThemes.Count);
                Console.WriteLine(theme.Name + " " + theme.Describtion + " " + theme.publishedON + " " + theme.User.Nickname);
                Console.WriteLine();
            }
        }



        public void RateTheme(ITheme them, byte score)
        {
            IRate rate = Factory.CreateRating(them, this, score);
            if (RatingsForThemes.TryAdd(them, rate))
            {
                Console.WriteLine($"Your rating {score} for {them.Name} is succesfully added");
                them.UserRatings.Add(this, rate);


            }
            else
            {
                Console.WriteLine($"You have already rated this theme- {them.Name}");
            }




        }



        public void ViewTheme(Theme theme)

        {
            theme._views++;
            Console.WriteLine($"This theme has been viewed {theme._views} times.");
        }



        public void FollowTheme(Theme theme)

        {
            if (!ThemesFollowed.Contains(theme) || theme.UsersFollowing.Contains(this))
            {
                ThemesFollowed.Add(theme);
                theme.UsersFollowing.Add(this);
            }
            else
            {
                throw new Exception($"Theme {theme.Name} is already followed by {Nickname}!");
            }
        }


        public void PrintFollowedThemes()
        {
            var topicsFollowed = from topic in ThemesFollowed
                                 select topic.Name;
            Console.WriteLine();
            Console.Write("Themes followed: ");
            if (topicsFollowed.Count() < 1)
            {
                Console.Write("You are currently not following any topics.");
            }
            else
            {

                foreach (var topic in topicsFollowed)
                {
                    Console.Write(topic);
                }
            }
        }



        public void ViewNotifications()

        {
            Console.WriteLine();
            Console.WriteLine("Your notifications in descending order:");
            while (NotificationsSentToUser.Count > 0)
            {
                var notification = NotificationsSentToUser.Pop();

                Console.WriteLine($"\r\n{notification.Comment.Message} " +
                                  $"\r\nCreated by:{notification.Comment.Author.Nickname}" +
                                  $"\r\nOn:{notification.Comment.CreatedOn}");


            }
        }

        public void ChangePassword()
        {
            string oldPassword = null;
            string newPassword = null;
            int counter = 0;
            while (oldPassword != Password && counter < 3)
            {
                Console.Write("Please enter your old password for your account:");
                oldPassword = Console.ReadLine();
                if (oldPassword == Password)
                {

                    do
                    {
                        Console.Write("Please type your new password for your account: ");
                        newPassword = Console.ReadLine();


                    } while (newPassword.Length < 6);

                    Password = newPassword;
                    Console.WriteLine("Your password has been changed!");
                    break;
                }
                else
                {
                    counter++;

                    if (counter < 3)
                    {
                        Console.WriteLine("Wrong password for this account!Please try again:");


                    }

                    else
                    {
                        Console.WriteLine("Your account is temporary locked please contact administrator!");
                        break;
                    }




                }

            }



        }


    }
}
