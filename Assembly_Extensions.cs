using System.IO;
using System.Reflection;

namespace System
{
    public static class AssemblyExtensions
    {
        public static string GetManifestResourceString(this Assembly assembly, string resourcePath)
        {
            if (resourcePath is null)
                throw new ArgumentNullException(nameof(resourcePath));

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}
