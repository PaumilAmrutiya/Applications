using Repository.FamilyDayCare.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Repository.FamilyDayCare.ClassLibrary
{
    /// <summary>
    /// Oraganisation class is used to store details of oraganisation
    /// </summary>
    public class Oraganisation : ICommonProperties, IModificationProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EducatorName { get; set; }
        public int RegistrationNumber { get; set; }
        public int WwcNumber { get; set; }
        public string Address { get; set; }
        public int SuburbId { get; set; }
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime StartOfWeekDate { get; set; }
       
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("SuburbId")]
        public Suburb Suburb { get; set; }
        
        public List<Child> Children { get; set; }

    }
}
