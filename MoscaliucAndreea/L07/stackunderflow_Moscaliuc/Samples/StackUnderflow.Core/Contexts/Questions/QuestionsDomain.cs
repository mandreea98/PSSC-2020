using Access.Primitives.IO;
using StackUnderflow.Domain.Schema.Questions.CreateReplyCmd;
using System;
using System.Collections.Generic;
using System.Text;
using static StackUnderflow.Domain.Schema.Questions.CreateReplyCmd.CreateReplyResult;
using static PortExt;
using StackUnderflow.Domain.Schema.Questions.CheckLanguageOp;
using static StackUnderflow.Domain.Schema.Questions.CheckLanguageOp.CheckLanguageResult;
using static StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp.SendQuestionOwnerAcknowledgementResult;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp;
using static StackUnderflow.Domain.Schema.Questions.ReplyAuthorAcknowledgement.ReplyAuthorAcknowledgementResult;
using StackUnderflow.Domain.Schema.Questions.ReplyAuthorAcknowledgement;
using LanguageExt;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class QuestionsDomain
    {
        public static Port<ICreateReplyResult> CreateReply(int questionId, Guid authorUserId, Guid questionOwnerId, string answerBody) =>
            NewPort<CreateReplyCmd, ICreateReplyResult>(new CreateReplyCmd(questionId, authorUserId, questionOwnerId, answerBody));

        public static Port<ICheckLanguageResult> CheckLanguage(string body) =>
            NewPort<CheckLanguageCmd, ICheckLanguageResult>(new CheckLanguageCmd(body));

        public static Port<ISendQuestionOwnerAcknowledgementResult> SendQuestionOwnerAcknowledgement(int questionId, Guid userId) =>
            NewPort<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult>(new SendQuestionOwnerAcknowledgementCmd(questionId, userId));

        public static Port<IReplyAuthorAcknowledgementResult> ReplyAuthorAcknowledgement(int questionId, Guid userId, Option<ReplyCreated> reply) =>
            NewPort<ReplyAuthorAcknowledgementCmd, IReplyAuthorAcknowledgementResult>(new ReplyAuthorAcknowledgementCmd(questionId, userId, reply));
    }
}
