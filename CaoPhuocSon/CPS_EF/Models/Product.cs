using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CPS_EF.Models.AppDBContext;

namespace CPS_EF.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public Boolean Continue { get; set; }
    }
}