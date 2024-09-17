using System;
using System.Collections.Generic;

namespace UberSystem.Domain.Entities;

public partial class Payment
{
    public long Id { get; set; }

    public long? TripId { get; set; }

    public string? Method { get; set; }

    public double? Amount { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public virtual Trip? Trip { get; set; }

    public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
}
