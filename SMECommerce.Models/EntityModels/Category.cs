using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SMECommerce.Models.EntityModels
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Items { get; set; }
        public string Code { get; set; }
    }
}
