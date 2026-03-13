using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts;

/// <summary>
/// Events are immutable records.
/// </summary>
public record OrderCreatedEvent
(
    Guid OrderId,
    string ProductName,
    int Quantity,
    DateTime CreatedAt

);
