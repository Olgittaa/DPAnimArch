namespace OALProgramControl.Visitor
{
    public class PythonVisitor : IConvertToCodeVisitor
    {
        public string VisitAssignment(EXECommandAssignment command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitBreak(EXECommandBreak command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitCall(EXECommandCall command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitContinue(EXECommandContinue command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitQueryCreate(EXECommandQueryCreate command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitQueryDelete(EXECommandQueryDelete command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitScope(EXEAbstractScope command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitQueryRelate(EXECommandQueryRelate command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitQuerySelect(EXECommandQuerySelect command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitQuerySelectRelatedBy(EXECommandQuerySelectRelatedBy command)
        {
            throw new System.NotImplementedException();
        }

        public string VisitQueryUnrelate(EXECommandQueryUnrelate exeCommandQueryUnrelate)
        {
            throw new System.NotImplementedException();
        }
    }
}