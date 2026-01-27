namespace QuizProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question("What is the capital of Germany?",
                new string[] {"Paris", "Berlin", "Madrid", "Ankara"},
                1
                ),
                new Question("What is 2 + 2?",
                new string[] {"6", "20", "3", "4"},
                3
                ),
                new Question("What is the capital of Turkey?",
                new string[] {"Paris", "Berlin", "Madrid", "Ankara"},
                3
                ),
                new Question("What's this language?",
                new string[] {"Python", "C++", "C#", "C"},
                2
                ),
                new Question("Which one is an animal?",
                new string[] {"Car", "Bird", "Phone", "Water"},
                1
                ),
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();


            Console.ReadKey();
        }
    }
}
