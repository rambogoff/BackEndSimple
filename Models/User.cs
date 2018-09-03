using System;
using react.Models;
using System.Collections.Generic;

namespace react.Models
{
    public class User
    {
        public User()
        {
            Experiencies = new List<Experience>();
            Educations = new List<Education>();
            Languages = new List<Languages>();
            Skills = new List<Skill>();
            Honors = new List<Honor>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Title { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }


        public ICollection<Education> Educations { get; set; }

        public ICollection<Experience> Experiencies { get; set; }

        public ICollection<Languages> Languages { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<Honor> Honors { get; set; }

        
    }
}