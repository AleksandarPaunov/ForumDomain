using System;
using System.Collections.Generic;

namespace ForumDomain
{
    public interface ICategory
    {
        string Description { get; set; }

        IDivision Div { get; set; }

        Guid ID { get; set; }

        string Name { get; set; }

        List<ITheme> Themes { get;}

        List<IUse> UsersFollowing { get;}

        bool IsThemeInCategory(List<ITheme> themes, string themeName);

        void AddTheme(ITheme theme);
    }
}