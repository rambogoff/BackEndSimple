using System;
using react.Models;

namespace react.Models
{
    public class Honor
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}