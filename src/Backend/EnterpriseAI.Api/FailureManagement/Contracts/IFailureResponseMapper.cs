using EnterpriseAI.Application.FailureManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAI.Api.FailureManagement.Contracts
{
    public interface IFailureResponseMapper
    {
        ProblemDetails Map(
         HttpContext context,
         FailureDecision failure);
    }

   }
