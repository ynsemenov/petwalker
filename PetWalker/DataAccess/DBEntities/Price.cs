using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWalker.DataAccess.DBEntities
{
    [Table("price", Schema = "public")]
    public class Price
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("size_id")]
        public int SizeId { get; set; }

        [Column("is_agressive")]
        public bool IsAgressive { get; set; }

        [Column("amount")]
        public double Amount { get; set; }
    }
}
