using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMvc.Models
{
    public class FoodItem
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public string FoodType { get; set; }

        public int FoodPrice { get; set; }
        public string IsAvailable { get; set; }
        public string HomeDelivery { get; set; }

    }
}
