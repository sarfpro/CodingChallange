using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallengeService.Models
{
    public class Episode
    {
        public string image { get; set; }
        public string slug { get; set; }
        public string title { get; set; }       
    }

    public class Response

    {
        public List<Episode> response { get; set; }
    }
}