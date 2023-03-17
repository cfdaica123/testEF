using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static API.Models.AppDBContext;

namespace API.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        [ForeignKey(nameof(Category.Id))]
        public int IdCategory { get; set; }
        public Boolean Continue { get; set; }
    }
}