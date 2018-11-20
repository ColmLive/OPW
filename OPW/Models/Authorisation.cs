using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OPW.Models
{
    public enum ApprovalStatus
    {
        [Display(Name = "Awaiting Approval")] waiting,
        [Display(Name = "Approved")] Approved,
    }
    public enum User_Company
    {
        [Display(Name = "DEASP")] DEASP,
        [Display(Name = "OPW")] OPW
    }
    public enum User_Section
    {
        [Display(Name = "M&E Works")] MandE_Works,
        [Display(Name = "Minor Works")] Elective_Works,
        [Display(Name = "Capital Works")] Capital_works,
        [Display(Name = "Storage")] Storage,
        [Display(Name = "FMU-Team")] Accommodation,
        [Display(Name = "FMU-Finance")] Finance,
        [Display(Name = "Admin")] Admin
    }
    public enum User_Section_Code
    { E30_ZS_34, k00_ZS_34, J10_ZS_34, L00_ZH_34, FMU1, FMU2, Admin }


    public class Authorisation
    {
        //private ApprovalStatus Approval = ApprovalStatus.waiting;
        /*private readonly int user_ID;
        private readonly string user_Name;
        private readonly string user_Password;
        */
        private const double AutoAppLimit = 1000;
        internal string LoginErrorMessage;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_ID { get; set; }

        [Column("User")]
        [DisplayName("User Name ")]
        [Required(ErrorMessage = "This field is required.")]
        public string User_Name { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(80, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Column("Password ")]
        public string User_Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column("Org")]
        public User_Company Company { get; set; }

        [Required]
        [Column("DEPT")]
        public User_Section Usersect { get; set; }
        // Code generated from user selection. Emums co-ordinated above.
        [Required]
        [Column("DEPT-Code")]
        public User_Section_Code Usersectcode { get; set; }

        // Up to €1000 is Auto approved.
        [Required]
        [Column("Approval limit")]
        // [Range(0, 1000000)]
        public double User_Approval_Limit { get; set; }

        // Navigation fields
        public ICollection<Work> Building_works { get; set; }

        public Nullable<int> WorkId { get; set; }

        //public ApprovalStatus GetApproval { get; set; }


        // Constructor
        public Authorisation(string User_Name, string User_Password, User_Company Company, User_Section Usersect)
        {
            this.User_Name = User_Name;
            this.User_Password = User_Password;
            this.Company = Company;
            this.Usersect = Usersect;
            try
            {
                if (Usersect == User_Section.MandE_Works)
                {
                    Usersectcode = User_Section_Code.E30_ZS_34;
                    User_Approval_Limit = 0;
                }
                else if (Usersect == User_Section.Elective_Works)
                {
                    Usersectcode = User_Section_Code.k00_ZS_34;
                    User_Approval_Limit = 0;
                }
                else if (Usersect == User_Section.Capital_works)
                {
                    Usersectcode = User_Section_Code.J10_ZS_34;
                    User_Approval_Limit = 0;
                }
                else if (Usersect == User_Section.Storage)

                {
                    Usersectcode = User_Section_Code.L00_ZH_34;
                    User_Approval_Limit = 0;
                }
                else if (Usersect == User_Section.Admin)
                {
                    Usersectcode = User_Section_Code.Admin;
                    User_Approval_Limit = 999999999;
                }
                else if (Usersect == User_Section.Accommodation)
                {
                    Usersectcode = User_Section_Code.FMU1;
                    User_Approval_Limit = 40000;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }

        }

        public Authorisation()
        {
        }

     }

}