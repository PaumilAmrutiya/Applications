using Repository.FamilyDayCare.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.FamilyDayCare.ClassLibrary
{
    /// <summary>
    /// This class is used to store child's details
    /// </summary>
    public class Child : ICommonProperties, IModificationProperties
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Parent1FirstName { get; set; }
        public string Parent1LastName { get; set; }
        public string Parent2FirstName { get; set; }
        public string Parent2LastName { get; set; }
        public string Address { get; set; }
        public int SuburbId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int FamilyId { get; set; }
        public int OraganisationId { get; set; }


        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("OraganisationId")]
        public Oraganisation Oraganisation { get; set; }
        [ForeignKey("SuburbId")]
        public Suburb Suburb { get; set; }
    }
}
