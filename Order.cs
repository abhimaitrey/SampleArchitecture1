using System;

namespace Capita.Comm
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Total { get; set; }

        public string NoOfItems { get; set; }
    }
}