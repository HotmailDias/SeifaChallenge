using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEIFAChallenge.DB;
using SEIFAChallenge.DBModels;
using SEIFAChallenge.Processors;
using SEIFAChallenge.Request;
using SEIFAChallenge.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEIFAChallenge.Controllers
{
    [Route("api/[controller]")]
    public class SeifaController : ControllerBase
    {
        private ISeifaResultProcessor _seifaProcessor;

        private readonly ILogger<SeifaController> _logger;
        public SeifaController(ISeifaResultProcessor seifaProcessor,  ILogger<SeifaController> logger)
        {
            _logger = logger;
            _seifaProcessor = seifaProcessor;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("Year2011vs2016")]
        public async Task<ActionResult<List<SeifaScoreResponse>>> SeifaDisadvantageScores(SeifaScoreRequest seifaScoreRequest)
        {
            try
            {
                var result = await _seifaProcessor.BuildSeifaDisadvantageScores(seifaScoreRequest);
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message, seifaScoreRequest, ex);
                return StatusCode(500);
            } 
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("Year2011")]
        public async Task<ActionResult<List<SEIFA_2011>>> Seifa2011(SeifaScoreRequest seifaScoreRequest)
        {
            try
            {
                var result = await _seifaProcessor.BuildSeifa2011Result(seifaScoreRequest);
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message, seifaScoreRequest, ex);
                return StatusCode(500);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("Year2016")]
        public async Task<ActionResult<List<vw_SEIFA2016>>> Seifa2016(SeifaScoreRequest seifaScoreRequest)
        {
            try
            {
                var result =  await _seifaProcessor.BuildSeifa2016Result(seifaScoreRequest);
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message, seifaScoreRequest, ex);
                return StatusCode(500);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("PivotTable")]
        public async Task<ActionResult<List<vw_PivotByClientId>>> PivotTableByClientId(PivotTableRequest pivotTableRequest)
        {
            try
            {
                var result = await _seifaProcessor.BuildPivotTableResult(pivotTableRequest);
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex.Message, pivotTableRequest, ex);
                return StatusCode(500);
            }
        }
    }
}
