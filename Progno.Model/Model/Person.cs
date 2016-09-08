using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class Person
    {
        private string name;
        private string fullName;
        public long Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Display(Name = "Other Name")]
        public string OtherName { get; set; }

        public string ImageFileUrl { get; set; }
        public string SignatureFileUrl { get; set; }
        public Sex Sex { get; set; }

        [Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]

        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

       
        public State State { get; set; }

        //[Display(Name = "Title")]
        //public string Title { get; set; }
        public string Title { get; set; }

        public string Initial { get; set; }
        public string HomeTown { get; set; }

        [Display(Name = "Permanent Address")]
        public string HomeAddress { get; set; }

        public Nationality Nationality { get; set; }
        public DateTime DateRegistered { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get { return LastName + " " + FirstName + " " + OtherName; }
            set { fullName = value; }
        }

        [Display(Name = "Name")]
        public string Name
        {
            get { return LastName + " " + FirstName; }
            set { name = value; }
            //set { name = value; }
        }

        public Role Role { get; set; }
        public LocalGovernment LocalGovernment { get; set; }
        public Religion Religion { get; set; }


    }

}
