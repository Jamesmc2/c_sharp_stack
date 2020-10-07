using System.ComponentModel.DataAnnotations;

namespace DojoSurveyVal.Models
{
    public class Student
    {
        [Required]
        [MinLength(2)]
        public string Name{get; set;}

        [Required]
        public string Location{get; set;}

        [Required]
        public string FavoriteLanguage{get; set;}

        [MinLength(20)]
        public string Comment{get; set;}

        
    }
}