using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassengerApp.Model
{
    [Table("Passengers")]
    public class Passenger : CrudBase
    {
        [Key]
        public Guid UniquePassengerId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        public GenderEnum Gender { get; set; }
        public string DocumentNo { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
    }
}