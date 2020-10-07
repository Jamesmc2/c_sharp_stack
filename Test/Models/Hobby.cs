using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Test.Models

{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public List<Intrest> Intrested { get; set; }

    }
}