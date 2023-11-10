using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerShop.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва бренду")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Модель")]
        public string Model { get; set; }

        [Display(Name = "Код товару")]
        public string CodeName { get; set; }


        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Ціна")]
        [Required]
        public double  Price { get; set; }

        [Display(Name="Ціна зі знижкою!")]
        public double PriceForDiscount { get; set; }

        [Display(Name = "Врахувати знижку?")]
        public bool IsDiscount { get; set; }    


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }

    }
}
