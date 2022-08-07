namespace Core.Players
{
    public interface IPlayerProvider
    {
        IPlayer[] Players { get; }
        IPlayer GetPlayer(Configs.PlayerID playerID);
    }
}