using System.Collections.Generic;
using Repository.FamilyDayCare.Interfaces;

namespace Repository.FamilyDayCare.ClassLibrary
{
    public class FrequencyType : ICommonProperties
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public List<ChildFrequency> ChildFrequencies { get; set; }
    }
}
