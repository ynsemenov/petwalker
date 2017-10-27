using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWalker.DataAccess.DBEntities
{
    [Table("customer",Schema ="public")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("customer_name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }
    }
}
