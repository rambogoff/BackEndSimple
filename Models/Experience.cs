using System;
using System.ComponentModel.DataAnnotations.Schema;
using react.Models;

namespace react.Models
{
    public class Experience
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }

        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}