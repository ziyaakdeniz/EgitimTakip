﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class Training:BaseModel
    {
        public DateTime Date { get; set; }

        public string? FilePath { get; set; }   

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

        public virtual ICollection<TrainingsSubjectsMap> TrainingsSubjectsMap { get; set; }= new List<TrainingsSubjectsMap>();
    }
}
