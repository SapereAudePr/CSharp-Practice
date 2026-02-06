
namespace InterfacePractice
{
    public interface IWriter
    {
        string CensorText(string text);
    }

    public class Censor : IWriter
    {
        string[] badWords =
        [
            "fuck",
            "shit",
        ];

        public string CensorText(string text)
        {
            foreach (string word in badWords)
            {
                text = text.Replace(word, "[CENSORED]");
            }
            return text;
        }
    }

    public class Chat
    {
        private readonly IWriter _innerWriter;

        public Chat(IWriter innerWriter)
        {
            _innerWriter = innerWriter;
        }
        public void SendMessage(string message)
        {
            string censor = _innerWriter.CensorText(message);
            Console.WriteLine(censor);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new Censor();
            Chat chat = new Chat(writer);

            chat.SendMessage("fuck you");

            Console.ReadKey();
        }
    }
}
