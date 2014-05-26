﻿using System.Text.RegularExpressions;
using DbUpAndDown.Engine;

namespace DbUpAndDown.SQLite
{
    /// <summary>
    /// This preprocessor makes adjustments to your sql to make it compatible with Sqlite
    /// </summary>
    public class SQLitePreprocessor : IScriptPreprocessor
    {
        /// <summary>
        /// Performs some proprocessing step on a SQLite script
        /// </summary>
        public string Process(string contents)
        {
            return Regex.Replace(contents, @"n?varchar\s?\(max\)", "text", RegexOptions.IgnoreCase);
        }
    }
}