using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RedditImplementation
{
    public class RedditPost
    {
        [Key]
        public string Id { get; set; }
        public string SelfText { get; set; }

        public string SelfTextHTML { get; set; }

        public string Subreddit { get; set; }

        public string Title { get; set; }

        public int UpVotes { get; set; }

        public double UpvoteRatio { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }

        public int DownVotes { get; set; }

        public DateTime Edited { get; set; }

        public string Fullname { get; set; }

        public string Permalink { get; set; }

    }

    public class Utilities
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public DateTime GeneratedTime { get; set; }
        public DateTime Expires { get; set; }
    }
}


