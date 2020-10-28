using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionException : Exception
    {
        public InvalidQuestionException()
        {
        }

        public InvalidQuestionException(string body) : base($"The body \"{body}\" has more than 1000 characters.")
        {
        }
    }
}
