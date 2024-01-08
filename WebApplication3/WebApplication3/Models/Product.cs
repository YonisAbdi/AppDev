using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] [Range(1,1000)] public double Price { get; set; }

        [Required] public int CategoryId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(CategoryId))] public Category Category { get; set; }
    }
}
