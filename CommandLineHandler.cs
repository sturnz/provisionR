namespace Jasmin1
{
    public class CommandLineHandler
    {
         
        public Dictionary<string, string> Read(string[] args)
        {
            var arguments = new Dictionary<string, string>();

            for(int i = 0; i <= args.Length-2; i+=2)
            {
                arguments.Add(args[i], args[i+1]);
            }
            return arguments;
        }

        public bool CheckFormat(Dictionary<string, string> args)
        {
            foreach(string key in args.Keys)
            {
                if (!key.StartsWith('-')) 
                {
                    return false;
                } 
            }
            return true;
        }

        public bool CheckKeys(Dictionary<string, string> args)
        {
            var validKeys = new List<string>()
            {
                "-dir",
                "-pa",
                "-dak",
                "-dav",
                "-ft"
            };

            foreach (var key in args.Keys) if (!validKeys.Contains(key)) return false;
            return true;
        }

        public bool CheckValues (Dictionary<string, string> dict)
        {
            throw new NotImplementedException();
        }       
    }
}
