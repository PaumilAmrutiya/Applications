using System;

namespace Repository.FamilyDayCare.Interfaces
{
    /// <summary>
    /// Modification history properties
    /// </summary>
    public interface IModificationProperties
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
