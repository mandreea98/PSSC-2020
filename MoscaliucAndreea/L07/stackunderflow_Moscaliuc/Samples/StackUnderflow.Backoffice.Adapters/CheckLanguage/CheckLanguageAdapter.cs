using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Questions.CheckLanguageOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.CheckLanguageOp.CheckLanguageResult;
using static StackUnderflow.Domain.Schema.Questions.CreateReplyCmd.CreateReplyResult;

namespace StackUnderflow.Adapters.CheckLanguage
{
    public partial class CheckLanguareAdapter : Adapter<CheckLanguageCmd, ICheckLanguageResult, QuestionsReadContext>
    {
        public override Task PostConditions(CheckLanguageCmd cmd, ICheckLanguageResult result, QuestionsReadContext state)
        {
            throw new NotImplementedException();
        }

        public override async Task<ICheckLanguageResult> Work(CheckLanguageCmd cmd, QuestionsReadContext state)
        {
            var result = from validate in cmd.TryValidate()
                         select validate;

            return await result.Match(
                Succ: valid => (ICheckLanguageResult)new ValidReply(cmd.Body),
                Fail: ex => (ICheckLanguageResult)(new InvalidReply(ex.Message))
                );
        }
    }
}
