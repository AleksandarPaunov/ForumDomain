using System.Collections.Generic;

namespace ForumDomain
{
    public interface INotify
    {
        IComment Comment { get; set; }

        ITheme Theme { get; set; }

        IUse User { get; set; }

        List<IUse> UsersFollowing { get;}
    }
}