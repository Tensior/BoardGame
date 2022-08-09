using System.Collections.Generic;
using UIView.ViewModels.Base;
using UnityEngine;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class PlayerMoveDirectionsVM : ShowableViewModel
    {
        private readonly ObservableList<ArrowVM> _arrows = new ();
        private Vector3 _position;

        [Binding]
        public ObservableList<ArrowVM> Arrows => _arrows;

        [Binding]
        public Vector3 Position
        {
            get => _position;
            set
            {
                if (value == _position)
                {
                    return;
                }

                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
    }
}