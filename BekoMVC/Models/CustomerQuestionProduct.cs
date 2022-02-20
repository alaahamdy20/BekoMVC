using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class CustomerQuestionProduct
    {
        public int SerialNo { get; set; }
        public string CustomerName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public virtual Customer CustomerNameNavigation { get; set; }
        public virtual Product SerialNoNavigation { get; set; }
    }
}
