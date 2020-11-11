using EarlyPay.Primitives.ValidationAttributes;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.CreateReplyCmd
{
    public class CreateReplyCmd
    {

        public CreateReplyCmd(int questionId, Guid authorUserId, Guid questionOwnerId, string body)
        {
            QuestionId = questionId;
            AuthorUserId = authorUserId;
            QuestionOwnerId = questionOwnerId;
            Body = body;
        }
        [Required]
        public int QuestionId { get; }
        [Required]
        public Guid AuthorUserId { get; }
        [Required]
        public Guid QuestionOwnerId { get; }
        [MinLength(10)]
        [MaxLength(500)]
        [Required]
        public string Body { get; set; }

        //public static Result<CreateReplyCmd> Create(int questionId, string body)
        //{
        //    if (questionId > 0 && body.Length >= 10 && body.Length <= 500)
        //        return new CreateReplyCmd(questionId, body);
        //    else
        //        return new Result<CreateReplyCmd>(new ArgumentException("Argument is invalid"));
        //}

    }
}
