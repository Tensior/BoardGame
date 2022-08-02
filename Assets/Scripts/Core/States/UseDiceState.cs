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

        private int _animationPeriodMs;
        private int _animationPeriodDecreaseStepMs;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        protected abstract int Min { get; }
        protected abstract int Max { get; }

        protected UseDiceState(UseDiceMediator useDiceMediator, IInputProvider inputProvider)
        {
            _useDiceMediator = useDiceMediator;
            _inputProvider = inputProvider;
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
                return StatesContainer.PassTurnState;
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
                
                _useDiceMediator.Number = GetNewRandom(_useDiceMediator.Number, Min, Max + 1);
                
                await Task.Delay(_animationPeriodMs, _cancellationToken);

                DecreaseAnimationSpeed();
            }
        }

        private void DecreaseAnimationSpeed()
        {
            _animationPeriodMs -= _animationPeriodDecreaseStepMs;
        }

        private int GetNewRandom(int prevValue, int min, int max)
        {
            var tryCount = 100;
            
            while (tryCount > 0)
            {
                var value = Random.Range(min, max);
                if (value != prevValue)
                {
                    return value;
                }

                --tryCount;
            }

            return prevValue;
        }
    }
}