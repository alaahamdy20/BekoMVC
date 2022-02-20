using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class ProductColor
    {
        public int ProductId { get; set; }
        public string Color { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }

        public virtual Product Product { get; set; }
    }
}
