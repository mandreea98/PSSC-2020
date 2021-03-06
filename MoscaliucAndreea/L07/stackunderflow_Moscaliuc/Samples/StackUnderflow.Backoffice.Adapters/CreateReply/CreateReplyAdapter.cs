﻿using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using LanguageExt.ClassInstances.Pred;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Questions.CreateReplyCmd;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.CreateReplyCmd.CreateReplyResult;

namespace StackUnderflow.Adapters.CreateReply
{
    public partial class CreateReplyAdapter : Adapter<CreateReplyCmd, ICreateReplyResult, QuestionsReadContext>
    {
        public override Task PostConditions(CreateReplyCmd cmd, ICreateReplyResult result, QuestionsReadContext state)
        {
            throw new NotImplementedException();
        }

        public async override Task<ICreateReplyResult> Work(CreateReplyCmd cmd, QuestionsReadContext state)
        {
            var result = from validate in cmd.TryValidate()
                         select validate;

            return await result.Match(
                Succ: valid => (ICreateReplyResult)(new ReplyCreated(1, cmd.QuestionId, cmd.AuthorUserId, cmd.Body)),
                Fail: ex => (ICreateReplyResult)(new InvalidRequest(ex.Message))
                );
        }
    }
}
