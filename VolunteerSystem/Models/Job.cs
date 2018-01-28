﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace VolunteerSystem.Models
{
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}