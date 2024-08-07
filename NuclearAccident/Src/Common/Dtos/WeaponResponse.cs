﻿using NuclearIncident.Src.Common.Dtos.BrokenArrow;

namespace NuclearIncident.Src.Common.Dtos
{
    public class WeaponResponse
    {
        public Guid WeaponId { get; set; }

        public string? Name { get; set; }

        public string? Builder { get; set; }

        public string? Description { get; set; }

        public List<BrokenArrowShortResponse>? BrokenArrowss { get; set; }
    }
}
