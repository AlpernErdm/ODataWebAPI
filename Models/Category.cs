﻿namespace ODataWebAPI.Models
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
           
        }

        public Guid Id { get; set; }
        public string Name { get; set; }=default!;
    }
}
