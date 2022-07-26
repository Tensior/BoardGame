using System.Threading;
using System.Threading.Tasks;
using Input;
using UIMediation.Mediators;
using UnityEngine;

namespace Core.States
{
    public abstract class UseDiceState : IState
    {
        private readonly UseDiceMediator _useDiceMediator;
        private readonly IInputProvider _inputProvider;
        private readonly PassTurnState _passTurnState;

        private int _animationPeriodMs;
        private int _animationPeriodDecreaseStepMs;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        protected abstract int Min { get; }
        protected abstract int Max { get; }

        protected UseDiceState(UseDiceMediator useDiceMediator, IInputProvider inputProvider, PassTurnState passTurnState)
        {
            _useDiceMediator = useDiceMediator;
            _inputProvider = inputProvider;
            _passTurnState = passTurnState;
        }

        void IState.Enter()
        {
            _useDiceMediator.Show();

            _animationPeriodMs = Constants.UseDiceAnimationPeriodMs;
            _animationPeriodDecreaseStepMs = 0;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            
            UseDiceAnimationAsync();
        }

        IState IState.Update()
        {
            if (_inputProvider.IsDiceStopped)
            {
                _animationPeriodDecreaseStepMs = Constants.UseDiceAnimationPeriodDecreaseStepMs;
            }
            
            if (_animationPeriodMs <= 0)
            {
                _cancellationTokenSource.Cancel();
                return _passTurnState;
            }

            return null;
        }

        void IState.Exit()
        {
            _useDiceMediator.Hide();
        }

        private async Task UseDiceAnimationAsync()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                _useDiceMediator.SetNumber(Random.Range(Min, Max + 1));
                
                await Task.Delay(_animationPeriodMs, _cancellationToken);

                DecreaseAnimationSpeed();
            }
        }

        private void DecreaseAnimationSpeed()
        {
            _animationPeriodMs -= _animationPeriodDecreaseStepMs;
        }
    }
}