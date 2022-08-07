using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Core.Players
{
    public class PlayerProvider : IPlayerProvider
    {
        private readonly IPlayer[] _players;
        private readonly Dictionary<PlayerID, IPlayer> _playersDict;

        public PlayerProvider(IPlayer[] players)
        {
            _players = players;
            _playersDict = players.ToDictionary(player => player.PlayerID, player => player);
        }

        IPlayer[] IPlayerProvider.Players => _players;

        IPlayer IPlayerProvider.GetPlayer(PlayerID playerID)
        {
            _playersDict.TryGetValue(playerID, out var player);
            return player;
        }
    }
}