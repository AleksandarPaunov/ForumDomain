using System;
using System.Collections.Generic;
using System.Text;

namespace ForumDomain
{
    public static class PasswordGenerator
    {
       
        private static string AllLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static string Numbers = "0123456789";
        private static string SpecialChar = "~!@#$%^&*()_+=`|':;.,/?<>";
        private static Random random = new Random();
        static StringBuilder password = new StringBuilder();
        

        public static string GeneratePassword()
        {
            for (int i = 0; i < 4; i++)
            {
                char specialChar = GenerateChar(AllLetters);
                InsertAtRandomPosition(password, specialChar);
                
            }
            for (int i = 0; i < 4; i++)
            {
                char specialChar = GenerateChar(Numbers);
                InsertAtRandomPosition(password, specialChar);
            }
            for (int i = 0; i < 2 ; i++)
            {

                char specialChar = GenerateChar(SpecialChar);
                InsertAtRandomPosition(password, specialChar);
            }
            return password.ToString().Substring(0,8);
        }

        private static void InsertAtRandomPosition(StringBuilder password, char character)
        { 
            int randomPosition = random.Next(password.Length + 1);
            password.Insert(randomPosition, character); 
        }

        private static char GenerateChar(string availableChars) 
        { 
            int randomIndex = random.Next(availableChars.Length); 
            char randomChar = availableChars[randomIndex]; 
            return randomChar; 
        }
    }

}
