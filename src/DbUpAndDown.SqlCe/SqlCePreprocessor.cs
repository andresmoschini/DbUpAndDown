using System.Text.RegularExpressions;
using DbUpAndDown.Engine;

namespace DbUpAndDown.SqlCe
{
    /// <summary>
    /// This preprocessor makes minor adjustments to your sql to make it compatible with SqlCe
    /// </summary>
    public class SqlCePreprocessor : IScriptPreprocessor
    {
        /// <summary>
        /// Performs some proprocessing step on a script
        /// </summary>
        public string Process(string contents)
        {
            return Regex.Replace(contents, @"nvarchar\s?\(max\)", "ntext", RegexOptions.IgnoreCase);
        }
    }
}