using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ForumDomain
{
    public class Rating : IRate
    {

        private byte _score;

        private IUse _user;

        private ITheme _theme;

        public IUse User { get { return _user; } private set { } }

        public ITheme Theme { get { return _theme; } private set { } }

        public byte Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (value < 0)
                {
                    _score = 0;
                }
                else if (value >= 0 || value <= 10)
                {
                    _score = value;
                }
                else
                {
                    Console.WriteLine("Rating cant be more than 10!Rating automatically set to the maximum.");
                    _score = 10;
                };
            }
        }

        public Rating()
        {

        }

        public Rating(ITheme th, IUse us, byte sc)
        {
            this.Theme = th;
            this.User = us;
            this.Score = sc;
        }
    }
}