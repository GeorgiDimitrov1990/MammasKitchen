namespace MammasKitchen.Web.Areas.Administration.Controllers
{
    using MammasKitchen.Common;
    using MammasKitchen.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
