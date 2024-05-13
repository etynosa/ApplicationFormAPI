using ApplicationFormAPI.Common;
using ApplicationFormAPI.Common.Constants;
using ApplicationFormAPI.Dtos;
using ApplicationFormAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApplicationFormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmittedApplicationController : ControllerBase
    {
        private readonly ISubmittedApplicationService _submittedApplicationService;
        private readonly IMapper _mapper;

        public SubmittedApplicationController(ISubmittedApplicationService submittedApplicationService, IMapper mapper)
        {
            _submittedApplicationService = submittedApplicationService;
            _mapper = mapper;
        }

        [HttpPost("submit-application")]
        public async Task<ActionResult<APIResponse>> SubmitApplication([FromBody] SubmittedApplicationDto submittedApplicationDto)
        {
            var submittedApplication = await _submittedApplicationService.CreateSubmittedApplicationAsync(submittedApplicationDto);
            if (submittedApplication == false)
            {
                return APIResponse.GetFailureMessage(HttpStatusCode.BadRequest, null, MessageConstants.OperationFailed);
            }

            return APIResponse.GetSuccessMessage(HttpStatusCode.OK, null, MessageConstants.OperationSuccess);
            
        }

        [HttpGet("get-submitted-applications")]
        public async Task<ActionResult<APIResponse>> GetSubmittedApplications()
        {
            var submittedApplications = await _submittedApplicationService.GetSubmittedApplicationsAsync();
            if (!submittedApplications.Any())
            {
                return APIResponse.GetFailureMessage(HttpStatusCode.NotFound, null, MessageConstants.DataNotFound);
            }

            return APIResponse.GetSuccessMessage(HttpStatusCode.OK, submittedApplications, MessageConstants.OperationSuccess);
        }

        [HttpGet("get-submitted-application/{id}")]
        public async Task<ActionResult<APIResponse>> GetSubmittedApplication(string id)
        {
            var submittedApplication = await _submittedApplicationService.GetSubmittedApplicationByIdAsync(id);
            if (submittedApplication == null)
            {
                return APIResponse.GetFailureMessage(HttpStatusCode.NotFound, null, MessageConstants.DataNotFound);
            }

            return APIResponse.GetSuccessMessage(HttpStatusCode.OK, submittedApplication, MessageConstants.OperationSuccess);
        }
    }
}
