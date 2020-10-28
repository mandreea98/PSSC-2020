using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionTag : Exception
    {
        public InvalidQuestionTag()
        {
        }

        public InvalidQuestionTag(List<string> tags) : base($"No. of tags:\"{tags.Count}\". \nOne tag needed, but not more than 3.")
        {
        }
    }
}
