using Microsoft.AspNetCore.Mvc;
using tpa_backend.DTOModels;
using tpa_backend.Services;

namespace tpa_backend.Controllers
{
    public class SelectInfoController : Controller
    {
        ISelectInfoService _selectInfoController;
        public SelectInfoController(ISelectInfoService selectInfoService)
        {
            _selectInfoController=selectInfoService;
        }

        [HttpGet]
        [Route("cities")]
        public IActionResult GetCities()
        {
            try
            {
                return Ok(_selectInfoController.GetCities());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("difficulties")]
        public IActionResult GetDifficulties()
        {
            try
            {
                return Ok(_selectInfoController.GetDifficulties());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("movingTypes")]
        public IActionResult GetMovingTypes()
        {
            try
            {
                return Ok(_selectInfoController.GetMovingTypes());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("interests")]
        public IActionResult GetInterests()
        {
            try
            {
                return Ok(_selectInfoController.GetInterests());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("mereLandmarks")]
        public IActionResult GetMereLandmarks(MereLandmarkViewModel model)
        {
            try
            {
                _selectInfoController.GetMereLandmarks(model);
                return StatusCode(200);
                //return Ok(_selectInfoController.GetMereLandmarks( model));
            }
            catch(Exception e)
            {

                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
    }
}
