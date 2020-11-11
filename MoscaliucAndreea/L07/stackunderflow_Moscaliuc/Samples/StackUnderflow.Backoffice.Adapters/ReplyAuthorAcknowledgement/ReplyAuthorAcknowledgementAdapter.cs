using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Questions.ReplyAuthorAcknowledgement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.ReplyAuthorAcknowledgement.ReplyAuthorAcknowledgementResult;

namespace StackUnderflow.Adapters.ReplyAuthorAcknowledgement
{
    public partial class ReplyAuthorAcknowledgementAdapter : Adapter<ReplyAuthorAcknowledgementCmd, IReplyAuthorAcknowledgementResult, QuestionsReadContext>
    {
        public override Task PostConditions(ReplyAuthorAcknowledgementCmd cmd, IReplyAuthorAcknowledgementResult result, QuestionsReadContext state)
        {
            throw new NotImplementedException();
        }

        public async override Task<IReplyAuthorAcknowledgementResult> Work(ReplyAuthorAcknowledgementCmd cmd, QuestionsReadContext state)
        {
            var result = from validate in cmd.TryValidate()
                         select validate;

            return await result.Match(
                Succ: valid => (IReplyAuthorAcknowledgementResult)(new AuthorAcknowledgementSent(cmd.QuestionId, cmd.UserId)),
                Fail: ex => (IReplyAuthorAcknowledgementResult)(new AuthorAcknowledgementNotSent(ex.Message))
                );
        }
    }
}
