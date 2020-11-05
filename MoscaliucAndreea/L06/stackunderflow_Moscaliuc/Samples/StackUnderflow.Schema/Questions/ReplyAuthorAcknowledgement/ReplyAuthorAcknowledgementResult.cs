using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.ReplyAuthorAcknowledgement
{
    [AsChoice]
    public static partial class ReplyAuthorAcknowledgementResult
    {
        public interface IReplyAuthorAcknowledgementResult { }

        public class AuthorAcknowledgementSent : IReplyAuthorAcknowledgementResult
        {
            public AuthorAcknowledgementSent(int questionId, int userId)
            {
                QuestionId = questionId;
                UserId = userId;
            }

            public int QuestionId { get; }
            public int UserId { get; }
        }

        public class AuthorAcknowledgementNotSent : IReplyAuthorAcknowledgementResult
        {
            public AuthorAcknowledgementNotSent(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }
    }
}
