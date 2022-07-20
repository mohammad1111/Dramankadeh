﻿using System.ComponentModel;

namespace Darmankadeh.Core.Domain;

public abstract class DomainException : Exception
{
    protected DomainException()
    {
    }

    protected DomainException([Localizable(true)] string message) : base(message)
    {
    }

    protected DomainException([Localizable(true)] string message, Exception innerException) : base(message,
        innerException)
    {
    }
}