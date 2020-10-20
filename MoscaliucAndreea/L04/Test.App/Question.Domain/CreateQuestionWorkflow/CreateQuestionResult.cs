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

            public QuestionCreated(Guid profileId, string body)
            {
                QuestionId = profileId;
                Body = body;
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
