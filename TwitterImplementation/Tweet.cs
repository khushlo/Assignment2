using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TwitterImplementation
{
    public class Tweet
    {
        [Key]
        public long Id { get; set; }
        public string TweetUrl { get; set; }
        [MinLength(10000)]
        public string FullText { get; set; }
        public string Language { get; set; }
        public int MediaCount { get; set; }
        public int RetweetCount{ get; set; }
        public int? ReplyCount { get; set; }
        public string CreatedByUsername { get; set; }
        public string CreatedByName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
