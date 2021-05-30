using System.ComponentModel.DataAnnotations;

namespace SEIFAChallenge.Request
{
    public class PivotTableRequest
    {
        [Required]
        public string ClientId { get; set; }
    }
}
