﻿
namespace Services.Dtos
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string? CustomerFullName { get; set; }

        public string? Telephone { get; set; }

        public string? EmailAddress { get; set; }

        public DateOnly CustomerBirthday { get; set; }
    }
}
