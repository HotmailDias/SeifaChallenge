namespace SEIFAChallenge.DBModels
{
    public class vw_SEIFA2016
    {
        public string? State { get; set; }
        public int LGA_Code { get; set; }

        public string LGA_Name { get; set; }

        public string Index_of_Relative_Socio_economic_Disadvantage_Score { get; set; }

        public string Index_of_Relative_Socio_economic_Disadvantage_decile { get; set; }

        public string Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Score { get; set; }

        public string Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Decile { get; set; }

        public string Index_of_Economic_Resources_Score { get; set; }

        public string Index_of_Economic_Resources_Decile { get; set; }

        public string Index_of_Education_and_Occupation_Score { get; set; }

        public string Index_of_Education_and_Occupation_Decile { get; set; }

        public double Usual_Resident_Population { get; set; }
    }
}
