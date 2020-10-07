using System.ComponentModel.DataAnnotations;
using System;

namespace DapperTest.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }


    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public int Age { get; set; }

        [Required]
        public string HairColor { get; set; }
    }
}
