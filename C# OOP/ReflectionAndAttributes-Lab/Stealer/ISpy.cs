using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer
{
    public interface ISpy
    {
        string StealFieldInfo(string className, params string[] fieldsNames);

        string AnalyzeAccessModifiers(string className);

        string RevealPrivateMethods(string className);
    }
}
