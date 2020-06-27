using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ForumDomain
{
    public class Comment : IComment
    {


        public Guid ID { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public IUse Author { get; set; }

        public ITheme Theme { get; set; }

        public INotify Notification { get; set; }

        public Comment(string commen, IUse au, ITheme th)
        {

            this.Message = commen;
            this.Author = au;
            this.Theme = th;
            CreatedOn = DateTime.Now;
            this.Notification = Factory.CreateNotification(th, this);
        }



    }
}
