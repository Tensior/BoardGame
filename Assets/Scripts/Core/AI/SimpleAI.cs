using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Core.AI
{
    public class SimpleAI : BaseAI
    {
        private readonly List<Action> _actions = new();

        protected override void StartTurnAct()
        {
            _actions.Clear();
            
            if (TurnsProvider.IsSmallDiceAvailable)
            {
                _actions.Add(ChooseSmallDice);
            }

            if (TurnsProvider.IsLargeDiceAvailable)
            {
                _actions.Add(ChooseLargeDice);
            }

            _actions[Random.Range(0, _actions.Count)]?.Invoke();
        }

        protected override void UseDiceAct()
        {
            InputController.IsDiceStopped = true;
        }

        private void ChooseSmallDice()
        {
            InputController.IsSmallDiceChosen = true;
        }

        private void ChooseLargeDice()
        {
            InputController.IsLargeDiceChosen = true;
        }
    }
}