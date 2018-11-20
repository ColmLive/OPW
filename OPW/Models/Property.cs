using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OPW.Models
{
    public enum Property_Team
    {
        [Display(Name = "Team North")] Team_North,
        [Display(Name = "Team South")] Team_south
    }
    public enum Property_Type
    {
        [Display(Name = "DEASP Office")] DEASP,
        [Display(Name = "Branch Office")] Branch_Office,
        [Display(Name = "HSE Location")] HSE_Location
    }

    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Property_ID { get; set; }

        //[ConcurrencyCheck, MaxLength(5, ErrorMessage = "Property code must be 5 Char long."), MinLength(5)]
        [Required]
        public string OPW_Building_code { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public Property_Type Type { get; set; }

        [Required]
        public string Cost_Centre { get; set; }

        [Required]
        public Property_Team Team { get; set; }

        // Navigation Properties
        public ICollection<Work> Building_Works { get; set; }

        public Nullable<int> WorkId { get; set; }

        // Constructor
        public Property(string OPW_Building_code, string Address, string County, Property_Type Type, string Cost_Centre, Property_Team Team)
        {
            this.OPW_Building_code = OPW_Building_code;
            this.Address = Address;
            this.County = County;
            this.Type = Type;
            this.Cost_Centre = Cost_Centre;
            this.Team = Team;
        }

        public Property()
        {
        }
    }
}