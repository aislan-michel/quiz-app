using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Notification;

namespace Quiz.App.Controllers;

public abstract class BaseController : Controller
{
    protected readonly INotificator Notificator;

    protected BaseController(INotificator notificator)
    {
        Notificator = notificator;
    }
}