using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PuskesosRazor.Pages.Administrator.Dashboards
{
  [Authorize(Roles = "Administrator")]
  public class AnalyticsModel : PageModel
  {
    public void OnGet() { }
  }
  public class CRMModel : PageModel
  {
    public void OnGet() { }
  }
  public class EcommerceModel : PageModel
  {
    public void OnGet() { }
  }
}
