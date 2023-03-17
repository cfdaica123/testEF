using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    [Keyless]
    public class Product_Image : AppDBContext.BaseEntity
    {
        [NotMapped]
        public new int Id { get; set; } // khong ke thua Id trong BaseEntity

        [ForeignKey(nameof(Product.Id))]
        public int IdProduct { get; set; }

        [ForeignKey(nameof(Image.Id))]
        public int IdImage { get; set; }
    }
}