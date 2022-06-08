using System;
using OALProgramControl.Visitor;

namespace OALProgramControl
{
    public abstract class EXECommand
    {
        public EXEAbstractScope SuperScope { get; set; }

        public abstract void Accept(IConvertToCodeVisitor visitor);

        public Boolean PerformExecution(OALProgram OALProgram)
        {
            Boolean Result = Execute(OALProgram);

            return Result;
        }
        protected abstract Boolean Execute(OALProgram OALProgram);
        public EXEAbstractScope GetSuperScope()
        {
            return this.SuperScope;
        }
        public virtual void SetSuperScope(EXEAbstractScope SuperScope)
        {
            this.SuperScope = SuperScope;
        }
        protected EXEAbstractScope GetTopLevelScope()
        {
            EXEAbstractScope CurrentScope = this.SuperScope;

            while (CurrentScope.SuperScope != null)
            {
                CurrentScope = CurrentScope.SuperScope;
            }

            return CurrentScope;
        }
        public virtual Boolean IsComposite()
        {
            return false;
        }
        public virtual String ToCode(String Indent = "")
        {
            return Indent + ToCodeSimple() + ";\n";
        }
        public virtual String ToCodeSimple()
        {
            return "Command";
        }
    }
}
