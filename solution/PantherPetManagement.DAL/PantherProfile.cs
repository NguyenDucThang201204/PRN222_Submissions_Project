namespace PantherPetManagement.DAL;

public partial class PantherProfile
{
    public int PantherProfileId { get; set; }

    public int PantherTypeId { get; set; }

    public string PantherName { get; set; } = null!;

    public double Weight { get; set; }

    public string Characteristics { get; set; } = null!;

    public string Warning { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual PantherType? PantherType { get; set; } = null!;
}
