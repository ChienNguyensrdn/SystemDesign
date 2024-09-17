using System;
using System.Collections.Generic;

namespace UberSystem.Domain.Entities;

public partial class Rating
{
    public long Id { get; set; }

    public long? CustomerId { get; set; }

    public long? DriverId { get; set; }

    public long? TripId { get; set; }

    public int? Rating1 { get; set; }

    public string? Feedback { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Trip? Trip { get; set; }
}
