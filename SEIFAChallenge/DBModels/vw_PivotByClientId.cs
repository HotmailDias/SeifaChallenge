using System;

namespace SEIFAChallenge.DBModels
{
    public class vw_PivotByClientId
    {
        public string ClientId { get; set; }

        public string WebId { get; set; }

        public string GeoName { get; set; }

        public string Year { get; set; }

        public string Number { get; set; }

        public Int64?  ChangeYear1Year2 { get; set; }

    }
}
