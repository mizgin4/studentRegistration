using Microsoft.AspNetCore.Mvc;
using StudentSystem.Models.RequestModels;
using StudentSystem.Models.ResponseModels;
using StudentSystem.Services;

namespace StudentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Registration : ControllerBase
    {

        [HttpPost(Name = "studentregistration")]
        public Response Post(Request request)
        {
            var _studentService = new StudentService();

            if (!ModelState.IsValid)
                return new Response();

            var retVal = _studentService.Validate(request);

            return retVal;
        }
    }
}
