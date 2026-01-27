using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProject
{
    class Quiz
    {
        private Question[] _questions;
        private int _score;

        public Quiz(Question[] questions)
        {
            this._questions = questions;
            _score = 0;
        }
        
        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the quiz!");
            int questionNum = 1;
            
            foreach (Question question in _questions)
            {
                Console.WriteLine($"Question: {questionNum++}");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();
                if (question.isCorrectAnswer(userChoice))
                {
                    Console.WriteLine("Correct!");
                    _score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! Correct answer was: {question.Answers[question.CorrectAnswerIndex]}");
                }
            }
            DisplayResults();
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

        private void DisplayResults()
        {
            Console.WriteLine($"Your score is: {_score}/{_questions.Length}");

            double scoreAverage = (double)_score / _questions.Length;
            if (scoreAverage >= 0.8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Well Done!");
                Console.ResetColor();
            }
            else if (scoreAverage >= 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Not Bad!");
                Console.ResetColor();
            }
            else if (scoreAverage >= 0.3)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Meh!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Booo!");
                Console.ResetColor();
            }
        }
    }
}
