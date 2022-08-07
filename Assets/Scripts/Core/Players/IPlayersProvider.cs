namespace Core.Players
{
    public interface IPlayersProvider
    {
        Player[] Players { get; }
        Player GetPlayer(Configs.PlayerID playerID);
    }
}