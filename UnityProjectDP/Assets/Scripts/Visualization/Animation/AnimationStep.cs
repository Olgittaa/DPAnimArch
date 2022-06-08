using OALProgramControl;

namespace Assets.Scripts.Visualization.Animation
{
    abstract class AnimationStep
    {
        protected OALCall call;
        protected int step;

        float timeModifier = 1f;

        public OALCall Call
        {
            get => Call;
            set => Call = value;
        }

        public int Step
        {
            get => step;
            set => step = value;
        }

        public float TimeModifier
        {
            get => timeModifier;
            set => timeModifier = value;
        }

        public void AddStep()
        {
            step++;
        }

        public abstract void Execute();
    }

    class ZeroAnimationStep : AnimationStep
    {
        public override void Execute()
        {
            Singleton<AnimArch.Visualization.Animating.Animation>.Instance
                .HighlightClass(Call.CallerClassName, true);
        }
    }

    class FirstAnimationStep : AnimationStep
    {
        public override void Execute()
        {
            Singleton<AnimArch.Visualization.Animating.Animation>.Instance
                .HighlightMethod(Call.CallerClassName, Call.CallerMethodName, true);
        }
    }

    class SecondAnimationStep : AnimationStep
    {
        public override void Execute()
        {
            Singleton<AnimArch.Visualization.Animating.Animation>.Instance.StartCoroutine(
                Singleton<AnimArch.Visualization.Animating.Animation>.Instance.AnimateFill(Call));
            TimeModifier = 0f;
        }
    }

    class ThirdAnimationStep : AnimationStep
    {
        public override void Execute()
        {
            Singleton<AnimArch.Visualization.Animating.Animation>.Instance.HighlightEdge(Call.RelationshipName, true);
            TimeModifier = 0.5f;
        }
    }

    class ForthAnimationStep : AnimationStep
    {
        public override void Execute()
        {
            Singleton<AnimArch.Visualization.Animating.Animation>.Instance
                .HighlightClass(Call.CallerClassName, true);
            TimeModifier = 1f;
        }
    }

    class FifthAnimationStep : AnimationStep
    {
        public override void Execute()
        {
            Singleton<AnimArch.Visualization.Animating.Animation>.Instance
                .HighlightMethod(Call.CallerClassName, Call.CallerMethodName, true);
            TimeModifier = 1.25f;
        }
    }

    class SixthAnimationStep : AnimationStep
    {
        public override void Execute()
        {
            AnimArch.Visualization.Animating.Animation animation =
                Singleton<AnimArch.Visualization.Animating.Animation>.Instance;
            animation.HighlightClass(Call.CallerClassName, false);
            animation.HighlightMethod(Call.CallerClassName, Call.CallerMethodName, false);
            animation.HighlightClass(Call.CalledClassName, false);
            animation.HighlightMethod(Call.CalledClassName, Call.CalledMethodName, false);
            animation.HighlightEdge(Call.RelationshipName, false);
            TimeModifier = 1f;
        }
    }
}