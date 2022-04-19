﻿using System;

namespace Viaduct.Models
{
    public class Report
    {
        public string Id { get; set; }
        public int State { get; set; }
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        public decimal CardIncome { get; set; }
    }
}