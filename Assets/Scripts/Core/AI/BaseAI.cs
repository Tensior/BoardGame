using Configs;
using Core.States;
using Core.Turns;
using UnityEngine;
using Zenject;

namespace Core.AI
{
    [RequireComponent(typeof(Player))]
    public abstract class BaseAI : MonoBehaviour
    {
        [SerializeField] private Vector2 _actionCooldownMinMax;
        
        private GameStateManager _gameStateManager;
        private ITurnsProvider _turnsProvider;
        private PlayerID _playerId;
        private float _actionCooldownLeft;

        [Inject]
        private void Inject(GameStateManager gameStateManager, ITurnsProvider turnsProvider)
        {
            _gameStateManager = gameStateManager;
            _turnsProvider = turnsProvider;
        }

        private void Start()
        {
            _playerId = GetComponent<Player>().PlayerID;
        }

        private void Update()
        {
            if (_playerId != _turnsProvider.CurrentPlayerID)
            {
                return;
            }

            if (_actionCooldownLeft <= 0)
            {
                Act(_gameStateManager.CurrentState);
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
                    /*_actionCooldownLeft = Random.Range(_actionCooldownMinMax.x, _actionCooldownMinMax.y);
                    StartTurnAct();
                    break;*/
                case UseDiceState:
                    _actionCooldownLeft = Random.Range(_actionCooldownMinMax.x, _actionCooldownMinMax.y);
                    UseDiceAct();
                    break;
            }
        }
    }
}