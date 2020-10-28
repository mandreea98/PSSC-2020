using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Question.Domain.CreateQuestionWorkflow;
using static Question.Domain.CreateQuestionWorkflow.CreateQuestionResult;
using LanguageExt;
using LanguageExt.Common;
using static Question.Domain.CreateQuestionWorkflow.QuestionBody;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmd = UnverifiedBody.Create("text", new List<string>() {"tag1", "tag2", "tag3"});

            cmd.Match(
                    Succ: question =>
                    {
                        VoteQuestion(question);
                        Console.WriteLine("Can vote!");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Question could not be published. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );
            Console.ReadLine();
        }

        private static void VoteQuestion(UnverifiedBody body)
        {
            var verifiedQuestionResult = new VerifyQuestionService().VerifyBody(body);
            verifiedQuestionResult.Match(
                    voteQuestion =>
                    {
                        new VoteQuestionService().SendPermissionToVote(voteQuestion);
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("Question could not be verified, votting is not allowed.");
                        return Unit.Default;
                    }
                );
        }
    }
}
