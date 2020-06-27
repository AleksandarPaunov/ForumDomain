namespace ForumDomain
{
    public interface IFollow
    {
        ITheme Theme { get; set; }

        IUse User { get; set; }
    }
}