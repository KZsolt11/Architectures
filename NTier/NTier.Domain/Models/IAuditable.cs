﻿namespace NTier.Domain.Models;

public interface IAuditable
{
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}
