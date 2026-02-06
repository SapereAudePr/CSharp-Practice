using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    class ChatApp
    {
        private readonly IWriter _writer;

        public void Terminal()
        {
            Console.WriteLine("Welcome! What would you like to do?");

            IWriter writer = new Censor();
            Chat chat = new Chat(writer);

            string? userInput = Console.ReadLine();

            chat.SendMessage(userInput);

            
        }
    }
}
