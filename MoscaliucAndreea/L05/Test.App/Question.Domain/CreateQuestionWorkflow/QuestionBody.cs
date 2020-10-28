using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class QuestionBody
    {
        public interface IQuestionBody { }

        public class UnverifiedBody : IQuestionBody
        {
            public string Body { get; private set; }
            public List<string> Tags { get; private set; }

            private UnverifiedBody(string body, List<string> tags)
            {
                Body = body;
                Tags = tags;
            }

            public static Result<UnverifiedBody> Create(string body, List<string> tags)
            {
                if(IsQuestionBodyValid(body))
                {
                    if (AreTagsValid(tags))
                    {
                        return new UnverifiedBody(body, tags);
                    }
                    else
                    {
                        return new Result<UnverifiedBody>(new InvalidQuestionTag(tags));
                    }
                }
                else
                {
                    return new Result<UnverifiedBody>(new InvalidQuestionException(body));
                }
            }

            private static bool IsQuestionBodyValid(string body)
            {
                if(body.Length <=1000)
                {
                    return true;
                }
                return false;
            }

            private static bool AreTagsValid(List<string> tags)
            {
                if(tags.Count>0 && tags.Count<4)
                {
                    return true;
                }
                return false;
            }
        }

        public class VerifiedBody : IQuestionBody
        {
            public string Body { get; private set; }

            internal VerifiedBody(string body)
            {
                Body = body;
            }
        }
    }
}
