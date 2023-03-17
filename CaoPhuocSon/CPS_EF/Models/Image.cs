using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CPS_EF.Models.AppDBContext;

namespace CPS_EF.Models
{
    public class Image : BaseEntity
    {
        public string FileName { get; set; }
    }
}