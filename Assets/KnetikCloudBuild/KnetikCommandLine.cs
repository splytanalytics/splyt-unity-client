using System.Collections.Generic;

namespace KnetikCloudBuild
{
    public static class KnetikCommandLine
    {
        private const string CLIParameterStartChar = "-";

        private static readonly Dictionary<string, string> sCommandLinePairs = new Dictionary<string, string>();

        public static void ParseCommandLine()
        {
            string[] args = System.Environment.GetCommandLineArgs();

            for (int i = 0; i < args.Length;)
            {
                // Some args are a keyword, and others are a key/value pair
                if (args[i].StartsWith(CLIParameterStartChar))
                {
                    bool advanceOverValue = false;

                    if ((i + 1) < args.Length)
                    {
                        if (!args[i + 1].StartsWith(CLIParameterStartChar))
                        {
                            // This is a value
                            sCommandLinePairs[args[i]] = args[i + 1];
                            advanceOverValue = true;
                        }
                    }

                    if (!advanceOverValue)
                    {
                        sCommandLinePairs[args[i]] = string.Empty;
                        i++;
                    }
                    else
                    {
                        i += 2;
                    }
                }
                else
                {
                    // Skip over a non parameter
                    i++;
                }
            }
        }

        public static string GetArg(string name)
        {
            return sCommandLinePairs.ContainsKey(name) ? sCommandLinePairs[name] : null;
        }

        public static bool ContainsKey(string name)
        {
            return sCommandLinePairs.ContainsKey(name);
        }
    }
}
