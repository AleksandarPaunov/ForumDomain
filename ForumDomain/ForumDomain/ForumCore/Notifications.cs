using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumDomain
{
    public class Notifications : INotify
    {
        public ITheme Theme { get; set; }

        public List<IUse> UsersFollowing { get; set; } = new List<IUse>();

        public IComment Comment { get; set; }

        public IUse User { get; set; }


        public Notifications(ITheme t, IComment c)

        {
            this.Theme = t;
            this.Comment = c;
            SendNotificationsToUsers();
        }


        private void SendNotificationsToUsers()
        {

            var userFollowingThisTheme = Theme.UsersFollowing.Select(x => x);
            int count = userFollowingThisTheme.Count();
            if (count > 0)
            {
                foreach (var userNotify in userFollowingThisTheme)
                {
                    if (userNotify.ThemesFollowed.Contains(Theme))
                    {
                        userNotify.NotificationsSentToUser.Push(this);
                    }

                }
            }
            else
            {
                throw new ArgumentException("No users following this topic.");
            }


        }
    }
}
