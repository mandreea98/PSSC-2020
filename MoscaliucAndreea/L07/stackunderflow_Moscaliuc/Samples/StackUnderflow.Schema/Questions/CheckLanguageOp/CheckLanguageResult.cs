using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.CheckLanguageOp
{
    [AsChoice]
    public static partial class CheckLanguageResult
    {
        public interface ICheckLanguageResult { }

        public class ValidReply : ICheckLanguageResult
        {
            public ValidReply(string body)
            {
                Body = body;
            }

            public string Body { get; }
        }

        public class InvalidReply : ICheckLanguageResult
        {
            public InvalidReply(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }

        public class ManualReview : ICheckLanguageResult
        {
            public ManualReview(string body)
            {
                Body = body;
            }
            public string Body { get;}
        }
    }
}
