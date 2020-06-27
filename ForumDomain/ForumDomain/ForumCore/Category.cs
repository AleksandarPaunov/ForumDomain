using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumDomain
{
    public class Category:ICategory
    {
        public IDivision Div { get; set; }

        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ITheme> Themes { get; set; } = new List<ITheme>();

        public List<IUse> UsersFollowing { get; set; } = new List<IUse>();



        public Category(IDivision hardware)
        {

        }

        public Category(IDivision d, string n, string des)
        {
            this.Div = d;
            this.Name = n;
            this.Description = des;

            d.AddCategory(this);
        }

        public void AddTheme(ITheme theme)
        {
            if (IsThemeInCategory(theme.categorie.Themes, theme.Name))
            {
                throw new Exception($"{theme.Name} already exist in this category {Name}!");
               
            }
            else
            {
                Themes.Add(theme);
            }

        }

        public bool IsThemeInCategory(List<ITheme> themes, string themeName)
            => themes.Any(t => t.Name == themeName);
    }
}
