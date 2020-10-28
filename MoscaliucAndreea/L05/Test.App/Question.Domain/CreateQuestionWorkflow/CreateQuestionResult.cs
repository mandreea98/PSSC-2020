using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using System.Linq;

namespace Question.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }

        public class QuestionCreated : ICreateQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Body { get; private set; }
            public int VoteScore { get; private set; }
            public IReadOnlyCollection<Vote> TotalVotes { get; private set; }

            public QuestionCreated(Guid profileId, string body, int voteScore, IReadOnlyCollection<Vote> totalVotes)
            {
                QuestionId = profileId;
                Body = body;
                VoteScore = voteScore;
                TotalVotes = totalVotes;
            }
        }

        public class QuestionNotCreated : ICreateQuestionResult
        {
            public string Reason { get; set; }

            public QuestionNotCreated(string reason)
            {
                Reason = reason;
            }
        }

        public class QuestionValidationFailed : ICreateQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
