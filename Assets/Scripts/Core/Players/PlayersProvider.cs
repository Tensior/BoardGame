using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Core.Players
{
    public class PlayersProvider : IPlayersProvider
    {
        private readonly Player[] _players;
        private readonly Dictionary<PlayerID, Player> _playersDict;

        public PlayersProvider(Player[] players)
        {
            _players = players;
            _playersDict = players.ToDictionary(player => player.PlayerID, player => player);
        }

        Player[] IPlayersProvider.Players => _players;

        Player IPlayersProvider.GetPlayer(PlayerID playerID)
        {
            _playersDict.TryGetValue(playerID, out var player);
            return player;
        }
    }
}