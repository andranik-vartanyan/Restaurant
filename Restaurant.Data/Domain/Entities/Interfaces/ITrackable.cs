using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data.Domain.Entities.Interfaces
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
