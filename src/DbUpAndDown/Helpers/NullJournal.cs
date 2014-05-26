using System;
using DbUpAndDown.Engine;

namespace DbUpAndDown.Helpers
{
    /// <summary>
    /// Enables multiple executions of idempotent scripts.
    /// </summary>
    public class NullJournal : IJournal
    {
        /// <summary>
        /// Returns an empty array of length 0
        /// </summary>
        /// <returns></returns>
        public SqlScript[] GetExecutedScripts()
        {
            return new SqlScript[0];
        }

        /// <summary>
        /// Does not store the script, simply returns
        /// </summary>
        /// <param name="script"></param>
        public void StoreExecutedScript(SqlScript script)
        { }
    }
}
