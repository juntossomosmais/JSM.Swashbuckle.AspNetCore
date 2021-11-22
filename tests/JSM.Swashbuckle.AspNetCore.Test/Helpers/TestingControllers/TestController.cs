using Microsoft.AspNetCore.Mvc;

namespace JSM.Swashbuckle.AspNetCore.Test.Helpers.TestingControllers
{
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-swagger-configuration", Name = "GetTest Swagger Configuration")]
        public IActionResult GetTest()
        {
            return Ok();
        }
    }
}
