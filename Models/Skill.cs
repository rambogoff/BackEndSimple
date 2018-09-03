using System;
using react.Models;

namespace react.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}