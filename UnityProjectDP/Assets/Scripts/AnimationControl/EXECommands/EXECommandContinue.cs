using OALProgramControl.Visitor;

namespace OALProgramControl
{
    public class EXECommandContinue : EXECommand
    {
        public override void Accept(IConvertToCodeVisitor visitor)
        {
            visitor.VisitContinue(this);
        }

        protected override bool Execute(OALProgram OALProgram)
        {
            return true;//return SuperScope.PropagateControlCommand(LoopControlStructure.Continue);
        }
        public override string ToCodeSimple()
        {
            return "continue";
        }
    }
}
