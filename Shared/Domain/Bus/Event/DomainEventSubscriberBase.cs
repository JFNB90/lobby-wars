﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.Bus.Event
{
    public interface DomainEventSubscriberBase
    {
        Task On(DomainEvent @event);
    }
}
