using System;
using System.Collections.Generic;

namespace ForumDomain
{
    public interface ITheme
    {
        DateTime publishedON { get; set; }

        ICategory categorie { get; set; }

        List<IComment> Comments { get;}

        string Describtion { get; set; }

        string Name { get; set; }

        IUse User { get; set; }

        Dictionary<IUse, IRate> UserRatings { get;}

        List<IUse> UsersFollowing { get;}

        void AverageThemeRating();

        bool IsThemeInCategoryCheckByDescription(List<ITheme> themes, string themeName);

        bool IsThemeInCategoryCheckByName(List<ITheme> themes, string themeName);

        void ShowAllComments();

        void ShowThemeInfo();

        void UsersFollowingTheme();
    }
}