using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ForumDomain
{
    public class Following : IFollow
    {

        public IUse User { get; set; }

        public ITheme Theme { get; set; }


        public Following(IUse u, ITheme t)
        {
            this.User = u;
            this.Theme = t;
            FollowingProccess();

        }


        private void FollowingProccess()
        {
            if (User.ThemesFollowed.Contains(Theme) || Theme.UsersFollowing.Contains(User))
            {
                throw new ArgumentException("This theme is already being followed by this user");

            }
            else
            {
                User.ThemesFollowed.Add(Theme);
                Theme.UsersFollowing.Add(User);
            }

        }

    }
}
