using System.ComponentModel.DataAnnotations.Schema;

namespace UberSystem.Domain.Entities;

public partial class Driver
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? CabId { get; set; }

    public DateTime? Dob { get; set; }

    public double? LocationLatitude { get; set; }

    public double? LocationLongitude { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public long? UserId { get; set; }

    public virtual Cab? Cab { get; set; }

    public virtual ICollection<Cab> Cabs { get; } = new List<Cab>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Trip> Trips { get; } = new List<Trip>();

    public virtual User? User { get; set; }
}
