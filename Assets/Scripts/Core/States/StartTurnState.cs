using Configs;
using Core.Turns;
using Input;
using UIMediation.Mediators;

namespace Core.States
{
    public class StartTurnState : IState
    {
        private readonly IInputProvider _inputProvider;
        private readonly GameTurnMediator _gameTurnMediator;
        private readonly ITurnsProvider _turnsProvider;
        private IState _stateToSwitch;

        public StartTurnState(IInputProvider inputProvider, GameTurnMediator gameTurnMediator, ITurnsProvider turnsProvider)
        {
            _inputProvider = inputProvider;
            _gameTurnMediator = gameTurnMediator;
            _turnsProvider = turnsProvider;
        }

        void IState.Enter()
        {
            _stateToSwitch = null;
            
            _gameTurnMediator.Show();

            _gameTurnMediator.SetDicesAvailability(
                _turnsProvider.IsSmallDiceAvailable,
                _turnsProvider.IsLargeDiceAvailable);

            /*switch (_turnsProvider.CurrentPlayerID)
            {
                case PlayerID.Player:
                    _gameTurnMediator.Show();
                    break;
                case PlayerID.Enemy1:
                    _gameTurnMediator.Hide();
                    break;
            }*/
        }

        IState IState.Update()
        {
            if (_inputProvider.IsSmallDiceChosen)
            {
                _stateToSwitch = StatesContainer.SmallUseDiceState;
            }
            else if (_inputProvider.IsLargeDiceChosen)
            {
                _stateToSwitch = StatesContainer.LargeUseDiceState;
            }
            
            return _stateToSwitch;
        }

        void IState.Exit()
        {
            //TODO: Hide turn interface or make it non-interactable
        }
    }
}