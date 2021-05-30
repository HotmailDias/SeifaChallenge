using System;
using System.ComponentModel.DataAnnotations;

namespace SEIFAChallenge.Request
{
    public class SeifaScoreRequest
    {
        [Range(0,5,ErrorMessage ="0->VIC, 1->QLD, 2-> NSW, 3->SA, 4->WA, 5->TAS, 6->NT, 7 -> ACT")]
        public int State { get; set; }
    }
}
