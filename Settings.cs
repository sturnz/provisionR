namespace Jasmin1
{
    public static class Settings
    {
        public static void MakeMeABeautifulTitle(this string title)
        {
            var list = new List<string>();
            string patternLineBreaker = "";
            string patternTitle = "";
            
            for(int i = 0; i < title.Length*2+1; i++)
            {
                if(i%2 == 0) patternLineBreaker += '+';
                else patternLineBreaker += '-';
            }

            foreach (char c in title) patternTitle += $"|{Char.ToUpper(c)}";
            patternTitle += '|';

            Console.WriteLine($"{patternLineBreaker}\n{patternTitle}\n{patternLineBreaker}\n\n");

        }
    }
}
