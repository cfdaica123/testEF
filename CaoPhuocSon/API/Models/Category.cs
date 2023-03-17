using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static API.Models.AppDBContext;

namespace API.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
}