using System;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.FamilyDayCare.Interfaces;


namespace Repository.FamilyDayCare.ClassLibrary
{
    public class ChildFrequency : ICommonProperties, IModificationProperties
    {
        public int Id { get; set; }
        public decimal Monday { get; set; }
        public decimal Tuesday { get; set; }
        public decimal Wednesday { get; set; }
        public decimal Thursday { get; set; }
        public decimal Friday { get; set; }
        public decimal Saturday { get; set; }
        public decimal Sunday { get; set; }
        public int ChildId { get; set; }
        public int FrequencyTypeId { get; set; }


        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ChildId")]
        public Child Child { get; set; }
        [ForeignKey("FrequencyTypeId")]
        public FrequencyType FrequencyType { get; set; }
    }
}
