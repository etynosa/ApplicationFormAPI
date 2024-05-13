using ApplicationFormAPI.Common;
using ApplicationFormAPI.Common.Constants;
using ApplicationFormAPI.Dtos;
using ApplicationFormAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationFormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationFormService _applicationFormService;

        public ApplicationFormController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }

        [HttpGet("get-all-applications")]
        public async Task<ActionResult<APIResponse>> GetApplicationForm()
        {
            var applicationForm = await _applicationFormService.GetAllApplicationFormsAsync();
            if (applicationForm == null)
            {
                return (new APIResponse { StatusCode = System.Net.HttpStatusCode.NoContent, Message = MessageConstants.DataNotFound });
            }
            return (new APIResponse { StatusCode = System.Net.HttpStatusCode.OK, Data = applicationForm, Message = MessageConstants.FetchDataSuccess });
        }

        [HttpGet("get-application-form/{id}")]
        public async Task<ActionResult<APIResponse>> GetApplicationForm(string id)
        {
            var applicationForm = await _applicationFormService.GetApplicationFormAsync(id);
            if (applicationForm == null)
            {
                return (new APIResponse { StatusCode = System.Net.HttpStatusCode.NoContent, Message = MessageConstants.DataNotFound});
            }
            return (new APIResponse { StatusCode = System.Net.HttpStatusCode.OK, Data = applicationForm, Message = MessageConstants.FetchDataSuccess });
        }

        [HttpPost("create-application-form")]

        public async Task<ActionResult<APIResponse>> CreateApplicationForm([FromBody] ApplicationFormDto applicationFormDto)
        {
            var applicationForm = await _applicationFormService.CreateApplicationFormAsync(applicationFormDto);
            if (applicationForm == false)
            {
                return (new APIResponse { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = MessageConstants.OperationFailed });
            }
            return (new APIResponse { StatusCode = System.Net.HttpStatusCode.Created, Data = applicationForm, Message = MessageConstants.DataCreated });
        }

        [HttpPut("update-application-form/{id}")]
        public async Task<ActionResult<APIResponse>> UpdateApplicationForm(string id, [FromBody] ApplicationFormDto applicationFormDto)
        {
            var applicationForm = await _applicationFormService.UpdateApplicationFormAsync(id, applicationFormDto);
            if (applicationForm.Item1 == false)
            {
                return (new APIResponse { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = MessageConstants.OperationFailed });
            }
            return (new APIResponse { StatusCode = System.Net.HttpStatusCode.OK, Data = applicationForm, Message = MessageConstants.DataUpdated });
        }

        [HttpDelete("delete-application-form/{id}")]
        public async Task<ActionResult<APIResponse>> DeleteApplicationForm(string id)
        {
            var applicationForm = await _applicationFormService.DeleteApplicationFormAsync(id);
            if (applicationForm.Item1 == false)
            {
                return (new APIResponse { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = MessageConstants.OperationFailed });
            }
            return (new APIResponse { StatusCode = System.Net.HttpStatusCode.OK, Data = applicationForm, Message = MessageConstants.DataDeleted });
        }
    }
}
