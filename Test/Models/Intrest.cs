using System.ComponentModel.DataAnnotations;
using System;
namespace Test.Models

{
    public class Intrest
    {
        [Key]
        public int IntrestId { get; set; }
        public int UserId{get;set;}
        public int HobbyId{get;set;}
        public User User{get;set;}
        public Hobby Hobby{get;set;}

    }
}