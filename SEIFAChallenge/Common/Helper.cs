namespace SEIFAChallenge.Common
{
    public static class Helper
    {

        public static string GetState(this int stateId)
        {
            var result = (States)stateId;
            var stateStringValue = result.ToString().Replace("_", " ");
            return stateStringValue;

        }
    }
}
