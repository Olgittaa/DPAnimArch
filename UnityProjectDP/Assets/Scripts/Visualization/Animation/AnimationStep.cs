using OALProgramControl;

namespace Assets.Scripts.Visualization.Animation
{
    public abstract class AnimationStep
    {
        protected int step;

        protected readonly AnimArch.Visualization.Animating.Animation Animation
            = Singleton<AnimArch.Visualization.Animating.Animation>.Instance;

        protected OALCall Call { get; set; }

        public int Step
        {
            get => step;
            set => step = value;
        }

        public abstract void Execute();

        public bool Check()
        {
            return step < 7;
        }
    }

    internal class ZeroAnimationStep : AnimationStep
    {
        public ZeroAnimationStep(OALCall call)
        {
            Call = call;
        }

        public override void Execute()
        {
            Animation.HighlightClass(Call.CallerClassName, true);
            step++;
            Animation.Step = new FirstAnimationStep(Call);
        }
    }

    internal class FirstAnimationStep : AnimationStep
    {
        public FirstAnimationStep(OALCall call)
        {
            Call = call;
        }

        public override void Execute()
        {
            Animation.HighlightMethod(Call.CallerClassName, Call.CallerMethodName, true);
            step++;
            Animation.Step = new SecondAnimationStep(Call);
        }
    }

    internal class SecondAnimationStep : AnimationStep
    {
        public SecondAnimationStep(OALCall call)
        {
            Call = call;
        }

        public override void Execute()
        {
            Animation.StartCoroutine(Animation.AnimateFill(Call));
            step++;
            Animation.Step = new ThirdAnimationStep(Call);
        }
    }

    internal class ThirdAnimationStep : AnimationStep
    {
        public ThirdAnimationStep(OALCall call)
        {
            Call = call;
        }

        public override void Execute()
        {
            Animation.HighlightEdge(Call.RelationshipName, true);
            step++;
            Animation.Step = new ForthAnimationStep(Call);
        }
    }

    internal class ForthAnimationStep : AnimationStep
    {
        public ForthAnimationStep(OALCall call)
        {
            Call = call;
        }

        public override void Execute()
        {
            Animation.HighlightClass(Call.CallerClassName, true);
            step++;
            Animation.Step = new FifthAnimationStep(Call);
        }
    }

    internal class FifthAnimationStep : AnimationStep
    {
        public FifthAnimationStep(OALCall call)
        {
            Call = call;
        }

        public override void Execute()
        {
            
            Animation.HighlightMethod(Call.CallerClassName, Call.CallerMethodName, true);
            step++;
            Animation.Step = new SixthAnimationStep(Call);
        }
    }

    internal class SixthAnimationStep : AnimationStep
    {
        public SixthAnimationStep(OALCall call)
        {
            Call = call;
        }

        public override void Execute()
        {
            Animation.HighlightClass(Call.CallerClassName, false);
            Animation.HighlightMethod(Call.CallerClassName, Call.CallerMethodName, false);
            Animation.HighlightClass(Call.CalledClassName, false);
            Animation.HighlightMethod(Call.CalledClassName, Call.CalledMethodName, false);
            Animation.HighlightEdge(Call.RelationshipName, false);
            step++;
        }
    }
}