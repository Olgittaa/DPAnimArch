﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OALProgramControl
{
    public interface EXEASTNode
    {
        String GetNodeValue();
        String Evaluate(EXEAbstractScope Scope, CDClassPool ExecutionSpace);
        bool VerifyReferences(EXEAbstractScope Scope, CDClassPool ExecutionSpace);
        void PrintPretty(string indent, bool last);
        string ToCode();
    }
}
