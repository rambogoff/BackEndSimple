using System;
using react.Models;

namespace react.Models
{

    public class Activities
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual Education Education { get; set; }
    }
}