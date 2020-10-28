using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    public struct CreateQuestionCmd
    {
        public CreateQuestionCmd(string title, string category, string body, List<string> tags)
        {
            Title = title;
            Category = category;
            Body = body;
            Tags = tags.AsEnumerable();
        }

        [Required]
        [MaxLength(500)]
        public string Title { get; private set; }
        public string Category { get; set; }
        [Required]
        public string Body { get; private set; }
        public IEnumerable<string> Tags { get; set; }

        public override string ToString()
        {
            return Title+"\n"+Category+"\n"+Body+"\n"+Tags+"\n";
        }
    }
}
