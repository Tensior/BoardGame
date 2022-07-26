using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(TurnsConfigSO), menuName = "Configs/" + nameof(TurnsConfigSO), order = 0)]
    public class TurnsConfigSO : ScriptableObject
    {
        public List<PlayerTurnData> PlayerTurnData;
    }
}
