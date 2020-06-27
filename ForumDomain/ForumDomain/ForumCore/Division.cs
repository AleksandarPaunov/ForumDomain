using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ForumDomain
{
    public class Division : IDivision
    {

        public string Name { get; set; }

        public Guid Id { get; set; }

        public List<ICategory> Categories { get; set; } = new List<ICategory>();

        public Division(string n)
        {


            this.Name = n;
            this.Id = new Guid();
        }



        public void AddCategory(ICategory cat)
        {
            if (IsCategoryInDivision(cat.Div.Categories, cat.Name))
            {
          
                throw new ArgumentException($"Category - with this name {cat.Name} already exist!");
           
            }
            else
            {
                Categories.Add(cat);
                Console.WriteLine("Category - {0} is now created", cat.Name);
            }
        }

        public void DeleteCategory(ICategory cat)
        {
            if (IsCategoryInDivision(cat.Div.Categories, cat.Name))
            {
                Categories.Remove(cat);

                Console.WriteLine("Category {0} is now deleted", cat.Name);
            }
            else
            {
                throw new ArgumentException("No such category found in the database");
            }
        }

        public void PrintListofCategories()
        {

            Console.WriteLine("Full list of created categories in this division:");
            Console.WriteLine();
            foreach (var category in Categories)
            {

                Console.WriteLine($"{category.Name} " +
                                  $"\r\n {category.Description}");
                
            }



        }
        private bool IsCategoryInDivision(List<ICategory> categories, string catName)
        => categories.Any(c => c.Name == catName);


    }
}
