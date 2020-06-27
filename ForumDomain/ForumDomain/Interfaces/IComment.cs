using System;

namespace ForumDomain
{
    public interface IComment
    {
        IUse Author { get; set; }

        DateTime CreatedOn { get; set; }

        Guid ID { get; set; }

        string Message { get; set; }

        INotify Notification { get; set; }

        ITheme Theme { get; set; }
    }
}