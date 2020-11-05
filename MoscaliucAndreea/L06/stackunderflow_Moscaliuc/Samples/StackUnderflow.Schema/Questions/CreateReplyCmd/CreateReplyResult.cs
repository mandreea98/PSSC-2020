using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.CreateReplyCmd
{
    [AsChoice]
    public static partial class CreateReplyResult
    {

        public interface ICreateReplyResult { }

        public class ReplyCreated : ICreateReplyResult
        {
            public ReplyCreated(int id, int questionId, string body)
            {
                Id = id;
                QuestionId = questionId;
                Body = body;
            }

            public int Id { get; set; }
            public int QuestionId { get; set; }
            public string Body { get; set; }
        }

        public class InvalidRequest:ICreateReplyResult
        {
            public InvalidRequest(string message)
            {
                Message = message; 
            }
            public string Message { get; }
        }
    }
}
