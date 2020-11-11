using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using static StackUnderflow.Domain.Schema.Questions.CreateReplyCmd.CreateReplyResult;

namespace StackUnderflow.Domain.Schema.Questions.ReplyAuthorAcknowledgement
{
    public class ReplyAuthorAcknowledgementCmd
    {
        public ReplyAuthorAcknowledgementCmd(int questionId, Guid userId, Option<ReplyCreated> reply)
        {
            QuestionId = questionId;
            UserId = userId;
            Reply = Reply;
        }

        public int QuestionId { get; }
        public Guid UserId { get; }
        public ReplyCreated Reply{ get; }

    }
}
