using System.Text.RegularExpressions;

namespace RegexPractical
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RegexMatches();
            //RegexMatch();
            //RegexIsMatch();
            RegexReplace();
            //RegexExample();

            Console.ReadKey();
        }

        // Returns *ALL* matches || T<MATCHCOLLECTION>
        static void RegexMatches()
        {
            string input = "A228 b765 c12 wqD Xdw U723";
            string pattern = @"[A-Z]\d+";
            MatchCollection res = Regex.Matches(input, pattern, RegexOptions.Multiline);

            foreach (Match m in res)
            {
                string x = m.Value;
                Console.WriteLine(x);
            }
        }

        // Returns *ONE* match || T<MATCH>
        static void RegexMatch()
        {
            string input = "A228 b765 c12 wqD Xdw U723";
            string pattern = @"[A-Z]\d+";
            Match res = Regex.Match(input, pattern, RegexOptions.Multiline);
            if (res.Success)
            {
                string matchRes = res.Value;
                Console.WriteLine(matchRes);
            }
        }

        // Returns *BOOL* for match || T<BOOL>
        static void RegexIsMatch()
        {
            string input = "A228 b765 c12 wqD Xdw U723";
            string pattern = @"[A-Z]\d+";
            bool res = Regex.IsMatch(input, pattern);
            Console.WriteLine(res);
        }

        // Manipulate the input with groups or replace the whole match with a *string* || T>STRING>
        static void RegexReplace()
        {
            string input = "User-551-ID:153-Session:691";
            string pattern = @"(\w+\-\d+)-(\w+:\d+)-(\w+:\d+)";
            string res = Regex.Replace(input, pattern, "1 | ******* | 3");
            Console.WriteLine(res);

            string inpt = "DQW259FFQWF582@259A";
            string pattrn = @"[a-zA-Z@]";
            string result = Regex.Replace(inpt, pattrn, "");
            Console.WriteLine(result);
        }

        static void RegexExample()
        {
            string pattern = @"(?<username>'.*?').*?(?<userId>\d+\.\d+\.\d+\.\d+).*?SessionID: (?<sessionId>.*). Status: \d+.";
            var fileRoot = @"C:\Users\38125\Desktop\C#Practice\RegexPracticalApp\RegexPractical\Input.txt";
            var input = File.ReadAllText(fileRoot);

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string username = match.Groups["username"].Value;
                string userId = match.Groups["userId"].Value;
                string sessionId = match.Groups["sessionId"].Value;

                Console.WriteLine(
                    $"Username: {username} | " +
                    $"User ID: {userId} | " +
                    $"Session ID: {sessionId}");
            }
        }
    }
}
