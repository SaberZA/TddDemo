using System;

namespace TddDemo.Logic.Models
{
    public class TimeCard
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}