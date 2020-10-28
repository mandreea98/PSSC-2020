using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt.Common;
using static Question.Domain.CreateQuestionWorkflow.QuestionBody;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class VerifyQuestionService
    {
        public Result<VerifiedBody> VerifyBody(UnverifiedBody body)
        {
            return new VerifiedBody(body.Body);
        }
    }
}
