namespace Core.Players
{
    public interface IPlayersProvider
    {
        Player GetPlayer(Configs.PlayerID playerID);
    }
}