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
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OraganisationId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("OraganisationId")]
        public Oraganisation Oraganisation { get; set; }
    }
}
