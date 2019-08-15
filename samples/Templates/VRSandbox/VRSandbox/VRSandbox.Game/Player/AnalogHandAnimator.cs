using System;
using Xenko.Animations;
using Xenko.Engine;
using Xenko.VirtualReality;

namespace VRSandbox.Player
{
    interface IAnalogHandAnimator
    {

    }

    public class AnalogHandAnimator : SyncScript
    {
        float _maxFrame;

        float oldValue;

        public AnimationComponent animComponent;
        public PlayingAnimation playingAnim;
        string _animName;
        Func<float> _analogValueSelectorFn;

        public AnalogHandAnimator(AnimationComponent animComponent, string animationName, Func<float> analogValueSelectorFn)
        {
            this.animComponent = animComponent;
            this.animComponent.Play(animationName);
            _animName = animationName;
        }

        public void Start()
        {
            oldValue = _analogValueSelectorFn.Invoke();
        }

        public override void Update()
        {
            float newValue = _analogValueSelectorFn.Invoke();
            float diff = newValue - oldValue;

            int comp = newValue.CompareTo(oldValue);

            if (diff > 0) // increased since last frame
            {
            }
            else if (diff < 0) // decreased since last frame
            {
            }

            playingAnim.TimeFactor = diff;
        }
    }

    
}
