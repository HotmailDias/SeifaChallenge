using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SEIFAChallenge.Common;
using SEIFAChallenge.DBModels;
using SEIFAChallenge.Request;

namespace SEIFAChallenge.DB
{
    public class DBbRetreiver:IDbRetreiver
    {
        private readonly SeifaContext _seifaContext;

        public DBbRetreiver(SeifaContext seifaContext)
        {
            _seifaContext = seifaContext;
        }

        public async Task<List<vw_SocioEconomicDisadvantages>> Get2011vs2016Data(SeifaScoreRequest request)
        {
            try
            {
                var stateValue = request.State.GetState();
                var resultset = _seifaContext.vw_SocioEconomicDisadvantages.Where(x=>x.State==stateValue);
                var result = await resultset.ToListAsync();
                return result;
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }

        public async Task<List<SEIFA_2011>> Get2011Data(SeifaScoreRequest request)
        {
            try
            {
                var stateValue = request.State.GetState();
                var resultset = _seifaContext.Seifa_2011.Where(x => x.State == stateValue);
                var result = await resultset.ToListAsync();
                return result;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<List<vw_SEIFA2016>> Get2016Data(SeifaScoreRequest request)
        {
            try
            {
                var stateValue = request.State.GetState();
                var resultset = _seifaContext.vw_SEIFA2016.Where(x => x.State == stateValue);
                var result = await resultset.ToListAsync();
                return result;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<List<vw_PivotByClientId>> GetPivotTableData(PivotTableRequest request)
        {
            try
            {
                var resultset = _seifaContext.vw_PivotByClientId.Where(x => x.ClientId == request.ClientId);
                var result = await resultset.ToListAsync();
                return result;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }

    public interface IDbRetreiver
    {
        Task<List<vw_SocioEconomicDisadvantages>> Get2011vs2016Data(SeifaScoreRequest request);
        Task<List<SEIFA_2011>> Get2011Data(SeifaScoreRequest request);
        Task<List<vw_SEIFA2016>> Get2016Data(SeifaScoreRequest request);
        Task<List<vw_PivotByClientId>> GetPivotTableData(PivotTableRequest request);
    }
}
