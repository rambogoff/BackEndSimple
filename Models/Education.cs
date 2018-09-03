
using System;

using react.Models;

using System.Collections.Generic;

namespace react.Models
{
    public class Education
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StartingYear { get; set; }

        public int EndYear { get; set; }

        public string Degree { get; set; }

        public string Activities { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}