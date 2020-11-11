﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp
{
    public class SendQuestionOwnerAcknowledgementCmd
    {
        public SendQuestionOwnerAcknowledgementCmd(int questionId, Guid userId)
        {
            QuestionId = questionId;
            UserId = userId;
        }

        public int QuestionId { get; }
        public Guid UserId { get; }
    }
}
