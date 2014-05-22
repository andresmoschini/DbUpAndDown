
using System.IO;
using System.Reflection;
using System.Text;

namespace DbUpAndDown.Engine
{
    /// <summary>
    /// Represents a SQL Server script that comes from an embedded resource in an assembly. 
    /// </summary>
    public class SqlScript
    {
        private readonly string contents;
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlScript"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="contents">The contents.</param>
        public SqlScript(string name, string contents)
        {
            this.name = name;
            this.contents = contents;
        }

        /// <summary>
        /// Gets the contents of the script.
        /// </summary>
        /// <value></value>
        public virtual string Contents
        {
            get { return contents; }
        }

        /// <summary>
        /// Gets the name of the script.
        /// </summary>
        /// <value></value>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Load a script form a file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SqlScript FromFile(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                var fileName = new FileInfo(path).Name;
                return FromStream(fileName, fileStream);
            }
        }

        /// <summary>
        /// Load a script form a stream
        /// </summary>
        /// <param name="scriptName"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static SqlScript FromStream(string scriptName, Stream stream)
        {
            using (var resourceStreamReader = new StreamReader(stream, Encoding.Default, true))
            {
                string c = resourceStreamReader.ReadToEnd();
                return new SqlScript(scriptName, c);
            }
        }

        /// <summary>
        /// Load a script from resource
        /// </summary>
        /// <param name="scriptName"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static SqlScript FromResource(string scriptName, Assembly assembly)
        {
            using (var stream = assembly.GetManifestResourceStream(scriptName))
            {
                return FromStream(scriptName, stream);
            }
        }
    }
}