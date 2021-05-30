using System.ComponentModel.DataAnnotations;

namespace SEIFAChallenge.DBModels
{
    public class SEIFA_2011
    {
        [Key]
        public int Id { get; set; }
        public int? LGA_Code { get; set; }
        public string State { get; set; }

        public string LGA_Name { get; set; }

        public int Index_of_Relative_Socio_economic_Disadvantage { get; set; }

        public int Index_of_Relative_Socio_economic_Advantage_and_Disadvantage { get; set; }
    }
}