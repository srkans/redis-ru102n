﻿namespace RedisCache.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int Total { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
