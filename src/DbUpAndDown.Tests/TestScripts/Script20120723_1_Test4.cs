using System;
using System.Data;
using DbUpAndDown.Engine;

namespace DbUpAndDown.Tests.TestScripts
{
    public class Script20120723_1_Test4 : IScript
    {
        public string ProvideScript(Func<IDbCommand> commandFactory)
        {
            return "test4";
        }
    }
}
