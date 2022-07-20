﻿namespace Dramankadeh.Core.EventBus;

public interface IEnterpriseServiceBus
{
    Task Publish(object message);

    Task Send(object message);
}