using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Question.Domain.CreateQuestionWorkflow.CreateQuestionResult;

namespace Question.Domain.CreateQuestionWorkflow
{
    class TotalVotes
    {
        public QuestionCreated Votes(QuestionCreated question, Vote vote)
        {
            var totalVotes = question.TotalVotes;
            totalVotes.Append(vote);
            return new QuestionCreated(question.QuestionId, question.Body, totalVotes.Sum(v => Convert.ToInt32(v)), totalVotes);
        }
    }
}
