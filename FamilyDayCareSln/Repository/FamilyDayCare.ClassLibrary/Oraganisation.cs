using Repository.FamilyDayCare.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.FamilyDayCare.ClassLibrary
{
    public class Oraganisation : ICommonProperties, IModificationProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EducatorName { get; set; }
        public int RegistrationNumber { get; set; }
        public int WwcNumber { get; set; }
        public string Address { get; set; }
        public int SuburbId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("SuburbId")]
        public Suburb Suburb { get; set; }

        public List<User> Users { get; set; }
        public List<Child> Children { get; set; }


    }
}
