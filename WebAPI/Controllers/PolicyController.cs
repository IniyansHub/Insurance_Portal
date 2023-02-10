using Insurance_Portal.Application.Interfaces;
using Insurance_Portal.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insurance_Portal.Controllers;

[Route("policy")]
public class PolicyController : Controller
{

  private readonly IPolicyService _policyService;

  public PolicyController(IPolicyService policyService)
  {
    _policyService = policyService;
  }

  [HttpGet]
  public async Task<ActionResult> GetAllPolicies()
  {
    var a = HttpContext.User;
    var response = await _policyService.GetAllPolicy();
    return Ok(response);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult> GetPolicy(int id)
  {
    var response = await _policyService.GetPolicyById(id);
    return Ok(response);
  }

  [Authorize(Roles = "Admin")]
  [HttpPost("create")]
  public async Task<ActionResult> CreatePolicy(Policy policy)
  {
    var response = await _policyService.AddPolicy(policy);
    return Ok(response);
  }

  [Authorize(Roles = "Admin")]
  [HttpDelete("delete/{policyId}")]
  public async Task<ActionResult> DeletePolicy(int policyId)
  {
    var response = await _policyService.DeletePolicy(policyId);
    return Ok(response);
  }

  [Authorize(Roles = "Admin")]
  [HttpPut("update/{id}")]
  public async Task<ActionResult> UpdatePolicy(Policy updatedPolicy, int id)
  {
    var response = await _policyService.UpdatePolicy(updatedPolicy, id);
    return Ok(response);
  }


}