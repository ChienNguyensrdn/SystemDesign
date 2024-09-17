using System;
using System.Collections.Generic;

namespace UberSystem.Domain.Entities;

public partial class Trip
{
    public long Id { get; set; }

    public long? CustomerId { get; set; }

    public long? DriverId { get; set; }

    public long? PaymentId { get; set; }

    public string? Status { get; set; }

    public double? SourceLatitude { get; set; }

    public double? SourceLongitude { get; set; }

    public double? DestinationLatitude { get; set; }

    public double? DestinationLongitude { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();
}
