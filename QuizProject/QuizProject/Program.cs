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
                4
                ),
                new Question("What is the capital of Turkey?",
                new string[] {"Paris", "Berlin", "Madrid", "Ankara"},
                4
                ),
                new Question("What's this language?",
                new string[] {"Python", "C++", "C#", "C"},
                3
                ),
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();


            Console.ReadKey();
        }
    }
}
