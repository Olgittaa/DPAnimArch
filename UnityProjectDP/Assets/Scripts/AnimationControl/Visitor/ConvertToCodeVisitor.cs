using System;

namespace OALProgramControl.Visitor
{
    public interface IConvertToCodeVisitor
    {
        string VisitAssignment(EXECommandAssignment command);
        string VisitBreak(EXECommandBreak command);
        string VisitCall(EXECommandCall command);
        string VisitContinue(EXECommandContinue command);
        string VisitQueryCreate(EXECommandQueryCreate command);
        string VisitQueryDelete(EXECommandQueryDelete command);
        string VisitScope(EXEAbstractScope command);
        string VisitQueryRelate(EXECommandQueryRelate command);
        string VisitQuerySelect(EXECommandQuerySelect command);
        string VisitQuerySelectRelatedBy(EXECommandQuerySelectRelatedBy command);
        string VisitQueryUnrelate(EXECommandQueryUnrelate exeCommandQueryUnrelate);
    }
}