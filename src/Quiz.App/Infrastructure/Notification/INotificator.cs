using System.Collections.Generic;

namespace Quiz.App.Infrastructure.Notification;

public interface INotificator
{
    void Add(string key, string message);
    
    Dictionary<string, string> Get();

    bool HaveNotifications();
}