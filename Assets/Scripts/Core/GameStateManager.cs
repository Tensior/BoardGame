using Core.States;
using UnityEngine;

namespace Core
{
    public class GameStateManager : MonoBehaviour
    {
        private FiniteStateMachine _fsm;
        /*private ITurnsProvider _turnsProvider;
        private IPlayersProvider _playersProvider;

        [Inject]
        private void Inject(ITurnsProvider turnsProvider, IPlayersProvider playersProvider)
        {
            _turnsProvider = turnsProvider;
            _playersProvider = playersProvider;
        }*/
        
        private void Awake()
        {
            _fsm = new FiniteStateMachine();
        }

        private void Update()
        {
            var stateToSwitch = _fsm.CurrentState.Update();
            if (stateToSwitch != null)
            {
                _fsm.ChangeState(stateToSwitch/*, _playersProvider.GetPlayer(_turnsProvider.CurrentPlayerID)*/);
            }
        }
    }
}