using Configs;
using Core.States;
using Core.Turns;
using Input;
using UnityEngine;
using Zenject;

namespace Core.AI
{
    [RequireComponent(typeof(Player))]
    public abstract class BaseAI : MonoBehaviour
    {
        [SerializeField] private Vector2 _actionCooldownMinMax;

        protected ITurnsProvider TurnsProvider;
        protected IInputController InputController;
        private ICurrentStateProvider _currentStateProvider;
        private PlayerID _playerId;
        private float _actionCooldownLeft;

        [Inject]
        private void Inject(
            ITurnsProvider turnsProvider, 
            IInputController inputController,
            ICurrentStateProvider currentStateProvider)
        {
            TurnsProvider = turnsProvider;
            InputController = inputController;
            _currentStateProvider = currentStateProvider;
        }

        private void Start()
        {
            _playerId = GetComponent<Player>().PlayerID;
            StartCooldown();
        }

        private void Update()
        {
            if (_playerId != TurnsProvider.CurrentPlayerID)
            {
                return;
            }

            if (_actionCooldownLeft <= 0)
            {
                Act(_currentStateProvider.CurrentState);
            }
            else
            {
                _actionCooldownLeft -= Time.deltaTime;
            }
        }

        private void Act(IState state)
        {
            switch (state)
            {
                case StartTurnState:
                    StartCooldown();
                    StartTurnAct();
                    break;
                case UseDiceState:
                    StartCooldown();
                    UseDiceAct();
                    break;
            }
        }

        protected abstract void StartTurnAct();

        protected abstract void UseDiceAct();

        private void StartCooldown()
        {
            _actionCooldownLeft = Random.Range(_actionCooldownMinMax.x, _actionCooldownMinMax.y);
        }
    }
}