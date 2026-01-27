using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProject
{
    class Quiz
    {
        private Question[] questions;

        public Quiz(Question[] questions)
        {
            this.questions = questions;
        }

        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the quiz!");
            int questionNum = 1;
            foreach (Question question in questions)
            {
                Console.WriteLine($"Question: {questionNum++}");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();
                if (question.isCorrectAnswer(userChoice))
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Wrong! Correct answer is: {question.CorrectAnswerIndex}");
                }
            }
        }

        private void DisplayQuestion(Question question)
        {
            Console.Write("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(question.QuestionText);

            

            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("     ");
                Console.Write($"{i + 1}-");
                Console.ResetColor();
                Console.WriteLine($"{question.Answers[i]}");
            }
        }

        private int GetUserChoice()
        {
            Console.Write("Your answer (number): ");
            string? input;
            int choice;

            while (!int.TryParse(input = Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                if (input == null)
                {
                    throw new InvalidOperationException("Invalid input");
                }

                Console.WriteLine("Invalid choice");
                input = Console.ReadLine();
            }

            return choice - 1;
        }
    }
}
