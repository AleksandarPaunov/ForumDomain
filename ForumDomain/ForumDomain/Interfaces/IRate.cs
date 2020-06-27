namespace ForumDomain
{
    public interface IRate
    {
        byte Score { get; set; }

        ITheme Theme { get; }

        IUse User { get; }
    }
}