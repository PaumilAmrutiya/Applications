using Repository.FamilyDayCare.Interfaces;
using System.Collections.Generic;

namespace Repository.FamilyDayCare.ClassLibrary
{
    public class State : ICommonProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }

        public List<Suburb> Suburbs { get; set; }
    }
}
