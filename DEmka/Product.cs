namespace DEmka
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(100)]
        public string ProductArticleNumber { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        private string _productPhoto;
        [Required]
        public string ProductPhoto
        {
            get
            {
                return "Resources/" + _productPhoto;
            }
            set
            {
                _productPhoto = value;
            }
        }

        [Required]
        public string ProductManufacturer { get; set; }

        public decimal ProductCost { get; set; }

        public byte? ProductDiscountAmount { get; set; }

        public byte? ProductDiscountMax { get; set; }

        public string ProductSupplier { get; set; }

        public string ProductMeasure { get; set; }

        public int ProductQuantityInStock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
