﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Dramankadeh.Core.EventBus;

public class PublishEvent
{
    public string EntityName { get; protected set; }


    public string EventContent { get; protected set; }


    public string EventTypeString { get; protected set; }


    public string UserContext { get; set; }


    public Guid DomainEventId { get; protected set; }


    [NotMapped] public Type EventType => Type.GetType(EventTypeString);
}