using System.Collections.Generic;
using Repository.FamilyDayCare.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.FamilyDayCare.ClassLibrary
{
    /// <summary>
    /// User class is used to store user information
    /// </summary>
    public class User : ICommonProperties
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public bool IsActive { get; set; }

        public List<Oraganisation> Oraganisations { get; set; }

    }
}
