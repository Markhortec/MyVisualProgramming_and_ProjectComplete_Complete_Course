using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProps
{
    public class Product
    {
        private int id;
        private string name;
        private string image;
        private float price;
        private string description;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public float Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
    }
}
