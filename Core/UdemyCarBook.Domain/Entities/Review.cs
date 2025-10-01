﻿namespace UdemyCarBook.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RatıngValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
