using com.course.blog.adminui.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace com.course.blog.adminui.Controllers
{
    [AdminAuthorization]
    public class BaseController : Controller
    {
    }
}
