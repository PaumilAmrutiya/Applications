using Repository.FamilyDayCare.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.FamilyDayCare.ClassLibrary
{
    public class Suburb : ICommonProperties
    {
        public int Id { get; set; }
        public int PostCode { get; set; }
        public int StateId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        public List<Oraganisation> Oraganisations { get; set; }
        public List<Child> Children { get; set; }
    }
}
