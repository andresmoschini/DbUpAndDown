using System;
using System.Collections.Generic;
using DbUpAndDown.Engine.Transactions;

namespace DbUpAndDown.Engine
{
    /// <summary>
    /// Provides scripts to be executed.
    /// </summary>
    public interface IScriptProvider
    {
        /// <summary>
        /// Gets all scripts that should be executed.
        /// </summary>
        IEnumerable<SqlScript> GetScripts(IConnectionManager connectionManager);
    }
}