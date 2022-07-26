using System.Linq;
using Configs;
using UnityEngine;

namespace Core.Players
{
    public class PlayersProvider : MonoBehaviour, IPlayersProvider
    {
        [SerializeField] private Player[] _players;
        
        Player IPlayersProvider.GetPlayer(PlayerID playerID)
        {
            return _players.FirstOrDefault(player => player.PlayerID == playerID);
        }
    }
}