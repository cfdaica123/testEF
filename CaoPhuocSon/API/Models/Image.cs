using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static API.Models.AppDBContext;

namespace API.Models
{
    public class Image : BaseEntity
    {
        public string FileName { get; set; }
    }
}