using System;
using System.Collections.Generic;
using System.Text;

namespace ForumDomain
{
    public static class Factory
    {
        public static Division CreateDivision(string name)
        {
            return new Division(name);
        }
        public static Category CreateCategory(IDivision division, string name, string describtion)
        {
            return new Category(division,name,describtion);
        }

        public static Comment CreateComment(string comment, IUse user, ITheme theme)
        {
            return new Comment(comment, user, theme);

        }
        public static Following CreateFollowing(IUse user,ITheme theme)
        {
            return new Following(user, theme);
        }
        public static Notifications CreateNotification(ITheme theme,IComment comment)
        {
            return new Notifications(theme, comment);
        }

        public static Rating CreateRating(ITheme theme,IUse user,byte score)
        {
            return new Rating(theme, user, score);
        }

        public static Theme CreateTheme(string name,string describtion,IUse user,ICategory category)
        {
            return new Theme(name, describtion, user, category);
        }

        public static IUse CreateUser(string name,string email)
        {
            return new User(name, email);
        }

    }
}
