using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWalker.DataAccess.DBEntities
{
    [Table("pet", Schema = "public")]
    public class Pet
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("pet_name")]
        public string Name { get; set; }

        [Column("customer_id")]
        public long CustomerId { get; set; }

        [Column("size_id")]
        public int SizeId { get; set; }

        [Column("is_agressive")]
        public bool IsAgressive { get; set; }
    }
}
