using System.ComponentModel.DataAnnotations;

namespace GamerGateway.Data
{
    public enum State { AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Customer Name")]
        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }

        }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(0, 6, ErrorMessage = "The Zip Code must contain 5 characters")]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public string ZipCode { get; set; }


    }
}
