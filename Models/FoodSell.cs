using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMvc.Models
{
    public class FoodSell
    {
        [Key]
        public int SellId { get; set; }
        public int FoodItemId { get; set; }
        public string WhoOrdered { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
