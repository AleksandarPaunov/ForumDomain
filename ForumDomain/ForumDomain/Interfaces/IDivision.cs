using System;
using System.Collections.Generic;

namespace ForumDomain
{
    public interface IDivision
    {
        List<ICategory> Categories { get;}

        Guid Id { get; set; }

        string Name { get; set; }

        void AddCategory(ICategory cat);

        void DeleteCategory(ICategory cat);

        void PrintListofCategories();
    }
}