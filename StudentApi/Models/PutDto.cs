using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class PutDto
    {
        public PutDto()
        {
            LastEditedDate = DateTime.Now;
        }

        public string Name { get; set; }

        [EmailAddress]
        public string EmailID { get; set; }

        public DateTime JoiningDate { get; set; }

        public DateTime LastEditedDate { get; set; }

        //[NotMapped]
        //public DateOnly DateofBirth { get; set; }

        [StringLength(10)]
        public string MobileNo { get; set; }

        public string PasswordHash { get; set; }
        //[NotMapped]
        //public string[]? Subjects { get; set; }




    }
}
