using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFramework.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        [Column("TenSanPham", TypeName ="ntext")]
        public string Name { get; set; }
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        public int CateId { get; set; }

        //Forenkey
        //Referen navigation
        [ForeignKey("CateId")]
        public virtual Category Category { get; set; } //FK -> PrimaryKey


        public int? CateId2{ get; set; }
        [ForeignKey("CateId2")]
        [InverseProperty("Products")]
        public virtual Category Category2 { get; set; } //FK -> PrimaryKey



        public void  PrintInfo() => Console.WriteLine($"{ProductId} - {Name} - {Price}");
    }
}

/*
 * Table("tableName")
 * [Key] -> primary Key(PK)
 * [Required]-> not null
 * [StringLength(50)] striung - nvarchar
 * [Colum("Tensanoham", TypeName = "ntext")]
 * [ForenKey("CateId")]
 * Reference Navigation -> ForrenKey 1-> n
 * Collecy Navigation -> (Khong tao ra Forenkey)
 */