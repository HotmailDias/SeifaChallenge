using Microsoft.Extensions.Logging;
using SEIFAChallenge.DB;
using SEIFAChallenge.DBModels;
using SEIFAChallenge.Request;
using SEIFAChallenge.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEIFAChallenge.Processors
{
    public class SeifaResultProcessor:ISeifaResultProcessor
    {
        private IDbRetreiver _dbRetreiver;
        private readonly ILogger<SeifaResultProcessor> _logger;
        public SeifaResultProcessor(IDbRetreiver dbRetreiver, ILogger<SeifaResultProcessor> logger)
        {
            _logger = logger;
            _dbRetreiver = dbRetreiver;
        }


        public async Task<List<SeifaScoreResponse>> BuildSeifaDisadvantageScores(SeifaScoreRequest seifaScoreRequest)
        {
            try
            {
                var vw_result = await _dbRetreiver.Get2011vs2016Data(seifaScoreRequest);
                var result = BuildResponse(vw_result);
                return result;
            }
            catch (System.Exception ex)
            {
                
                _logger.LogError(ex.Message, seifaScoreRequest, ex);
                throw;
            }
        }

        public async Task<List<SEIFA_2011>> BuildSeifa2011Result(SeifaScoreRequest seifaScoreRequest)
        {
            try
            {
                var vw_result = await _dbRetreiver.Get2011Data(seifaScoreRequest);
                 return vw_result;
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message, seifaScoreRequest, ex);
                throw;
            }
        }

        public async Task<List<vw_SEIFA2016>> BuildSeifa2016Result(SeifaScoreRequest seifaScoreRequest)
        {
            try
            {
                var vw_result = await _dbRetreiver.Get2016Data(seifaScoreRequest);
                return vw_result;
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message, seifaScoreRequest, ex);
                throw;
            }
        }


        public async Task<List<vw_PivotByClientId>> BuildPivotTableResult(PivotTableRequest pivotTableRequest)
        {
            try
            {
                var pvTable_result = await _dbRetreiver.GetPivotTableData(pivotTableRequest);
                return pvTable_result;
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message, pivotTableRequest, ex);
                throw;
            }
        }

        private List<SeifaScoreResponse> BuildResponse(List<vw_SocioEconomicDisadvantages> vw_SocioEconomicDisadvantages)
        {
            var respList = new List<SeifaScoreResponse>();
            foreach (var item in vw_SocioEconomicDisadvantages)
            {

                int firstResult = item.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_2011.HasValue?
                            (int)item.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_2011:0;

                int.TryParse(item.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Score_2016, out int secondResult);
                             

                respList.Add(
                    new SeifaScoreResponse()
                    {
                        State=item.State,
                        LGA_Code=item.LGA_Code,
                        Place2011=item.Place2011,
                        Place2016=item.Place2016,
                        Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_2011 = item.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_2011,
                        Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Score_2016=item.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Score_2016,
                        Index_of_Relative_Socio_economic_Disadvantage_2011=item.Index_of_Relative_Socio_economic_Disadvantage_2011,
                        Index_of_Relative_Socio_economic_Disadvantage_Score_2016=item.Index_of_Relative_Socio_economic_Disadvantage_Score_2016,
                        Place20111vs2016Difference= (secondResult - firstResult).ToString()
                    });

            }

            return respList;
            
        }
    }

    public interface ISeifaResultProcessor
    {
        Task<List<SeifaScoreResponse>> BuildSeifaDisadvantageScores(SeifaScoreRequest seifaScoreRequest);
        Task<List<SEIFA_2011>> BuildSeifa2011Result(SeifaScoreRequest seifaScoreRequest);
        Task<List<vw_SEIFA2016>> BuildSeifa2016Result(SeifaScoreRequest seifaScoreRequest);
        Task<List<vw_PivotByClientId>> BuildPivotTableResult(PivotTableRequest pivotTableRequest);

    }
}
