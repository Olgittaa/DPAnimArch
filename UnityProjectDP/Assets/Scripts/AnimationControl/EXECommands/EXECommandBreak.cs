using OALProgramControl.Visitor;

namespace OALProgramControl
{
    public class EXECommandBreak : EXECommand
    {
        public override void Accept(IConvertToCodeVisitor visitor)
        {
            visitor.VisitBreak(this);
        }

        protected override bool Execute(OALProgram OALProgram)
        {
            return true;//return SuperScope.PropagateControlCommand(LoopControlStructure.Break);
        }
        public override string ToCodeSimple()
        {
            return "break";
        }
    }
}
