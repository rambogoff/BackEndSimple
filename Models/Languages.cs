

using System;
using react.Models;

namespace react.Models
{
    public class Languages
    {
        public int Id { get; set; }
        public string Language { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}