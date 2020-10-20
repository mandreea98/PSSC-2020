using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    public struct CreateQuestionCmd
    {
        public CreateQuestionCmd(string title, string category, string body, string tags)
        {
            Title = title;
            Category = category;
            Body = body;
            Tags = tags;
            Category = category;
            Body = body;
            Tags = tags;
            Title = title;
        }

        [MaxLength(500)]
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Category { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Body { get; private set; }
        public string Tags { get; set; }
    }
}
