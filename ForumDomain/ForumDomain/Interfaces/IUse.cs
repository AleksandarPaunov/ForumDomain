using System;
using System.Collections.Generic;

namespace ForumDomain
{
    public interface IUse
    {
        string Email { get; set; }

        IFollow Follow { get; set; }

        Guid Id { get; set; }

        string Nickname { get; set; }

        Stack<INotify> NotificationsSentToUser { get;}

        string Password { get; set; }

        List<ITheme> ThemesFollowed { get;}

        List<ITheme> UserThemes { get;}

        IComment AddComment(Theme them, string com);

        void ChangePassword();

        ITheme CreateTheme(string name, string describtion, ICategory cat);

        void FollowTheme(Theme theme);

        void PrintCreatedThemes();

        void PrintFollowedThemes();

        void RateTheme(ITheme them, byte score);

        void ShowAllUserComments();

        void ViewNotifications();

        void ViewTheme(Theme theme);
    }
}