using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace work_01_With_SP.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
