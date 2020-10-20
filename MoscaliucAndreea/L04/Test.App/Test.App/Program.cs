using System;
using System.Collections.Generic;
using System.Net;
using Question.Domain.CreateQuestionWorkflow;
using static Question.Domain.CreateQuestionWorkflow.CreateQuestionResult;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new CreateQuestionCmd("Titul", string.Empty, "Intrebare?", "c#");
            var result = CreateQuestion(cmd);

            result.Match(
                    ProcessQuestionCreated,
                    ProcessQuestionNotCreated,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }

        private static ICreateQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateQuestionResult ProcessQuestionNotCreated(QuestionNotCreated questionNotCreatedResult)
        {
            Console.WriteLine($"Question not created: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }

        private static ICreateQuestionResult ProcessQuestionCreated(QuestionCreated question)
        {
            Console.WriteLine($"Question {question.QuestionId}");
            return question;
        }

        public static ICreateQuestionResult CreateQuestion(CreateQuestionCmd createQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(createQuestionCommand.Body))
            {
                var errors = new List<string>() { "Invlaid body" };
                return new QuestionValidationFailed(errors);
            }

            if (new Random().Next(10) > 1)
            {
                return new QuestionNotCreated("Question body could not be verified");
            }

            var questionId = Guid.NewGuid();
            var result = new QuestionCreated(questionId, createQuestionCommand.Body);

            //execute logic
            return result;
        }
    }
}
