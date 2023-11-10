using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerShop.Models.ViewModels
{
    public class ShoppingCartVM
    {
       public IEnumerable<ShoppingCart> ShoppingCarts { get; set; } 

        public OrderHeader OrderHeader { get; set; }    

        public double Price { get; set; }   


    }
}
