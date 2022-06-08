﻿using System;
using System.Linq;

namespace OALProgramControl
{
    public class EXEASTNodeLeaf : EXEASTNode
    {
        private String Value { get; }

        public EXEASTNodeLeaf(String Value)
        {
            this.Value = Value;
        }

        public String GetNodeValue()
        {
            return this.Value;
        }
        public String Evaluate(EXEAbstractScope Scope, CDClassPool ExecutionSpace)
        {
            String Result = null;

            String ValueType = EXETypes.DetermineVariableType("", this.Value);
            if (ValueType == null)
            {
                return Result;
            }

            // If we have simple value, e.g. 5, 3.14, "hi Madelyn", we are good
            if (!EXETypes.ReferenceTypeName.Equals(ValueType))
            {
                Result = this.Value;
            }
            // We got here because we have a variable name, the variable is of primitive value, or object reference, or set reference
            else
            {
                EXEPrimitiveVariable ThisVariable = Scope.FindPrimitiveVariableByName(this.Value);
                if(ThisVariable != null)
                {
                    return ThisVariable.Value;
                }

                EXEReferencingVariable ThisRefVariable = ((EXEScope)Scope).FindReferencingVariableByName(this.Value);
                if (ThisRefVariable != null)
                {
                    return ThisRefVariable.ReferencedInstanceId.ToString();
                }

                EXEReferencingSetVariable ThisRefSetVariable = ((EXEScope)Scope).FindSetReferencingVariableByName(this.Value);
                if (ThisRefSetVariable != null)
                {
                    return String.Join(",", ThisRefSetVariable.GetReferencingVariables().Select(variable => variable.ReferencedInstanceId.ToString()).ToList());
                }
            }

            /*Console.WriteLine("Operand: " + this.Value);
            Console.WriteLine("Result: " + Result);*/

            return Result;
        }

        public bool VerifyReferences(EXEAbstractScope Scope, CDClassPool ExecutionSpace)
        {
            bool Result = false;
            if (!EXETypes.ReferenceTypeName.Equals(EXETypes.DetermineVariableType("", this.Value)))
            {
                Result = true;
            }
            else
            {
                Result = ((EXEScope)Scope).VariableNameExists(this.Value);
            }
            return Result;
        }

        //https://stackoverflow.com/questions/1649027/how-do-i-print-out-a-tree-structure
        public void PrintPretty(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(this.Value);
        }

        public string ToCode()
        {
            return this.Value;
        }
    }
}
