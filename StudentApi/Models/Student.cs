using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApi.Models
{
    public class Student
    {
        public Student()
        {
                Guid = Guid.NewGuid();
                RecordCreationDate = DateTime.Now;
        }
        [Key]
        public Guid Guid{ get; set; }

        public string Name{ get; set; }

        [EmailAddress]
        public string EmailID { get; set; }

        public DateTime JoiningDate{ get; set; }

        public DateTime RecordCreationDate { get; set; }

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
