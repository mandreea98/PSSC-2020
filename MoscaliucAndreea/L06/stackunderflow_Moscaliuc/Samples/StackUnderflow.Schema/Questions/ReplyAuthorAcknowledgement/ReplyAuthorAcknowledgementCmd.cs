using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.ReplyAuthorAcknowledgement
{
    public class ReplyAuthorAcknowledgementCmd
    {
        public ReplyAuthorAcknowledgementCmd(int questionId, int userId)
        {
            QuestionId = questionId;
            UserId = userId;
        }

        public int QuestionId { get; }
        public int UserId { get; }
    }
}
