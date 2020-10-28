using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.CreateQuestionWorkflow.QuestionBody;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class VoteQuestionService
    {
        public Task SendPermissionToVote(VerifiedBody body)
        {
            return Task.CompletedTask;
        }
    }
}
