﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NuclearIncident.Src.Common.DbSet
{
    [Table("brokenarrow")]
    public class BrokenArrow
    {

        [Key]
        [Column("brokenarrowid")]
        public Guid BrokenArrowsId { get; set; }

        // location
        [Column("locationid")]
        public Guid? LocationId { get; set; }
        public Location? Location { get; set; }

        // vehicule
        [Column("vehiculeid")]
        public Guid? VehiculeId { get; set; }
        public Vehicule? Vehicule { get; set; }

        // weapon
        [Column("weaponid")]
        public Guid? WeaponId { get; set; }
        public Weapon? Weapon { get; set; }

        [Column("disasterdate")]
        public DateTime DisasterDate { get; set; }

        [Column("shortdescription")]
        public string? ShortDescription { get; set; }

        [Column("bubbledescription")]
        public string? BubbleDescription { get; set; }

        [Column("fulldescription")]
        public string? FullDescription { get; set; }

        [Column("seal")]
        public string? Seal { get; set; }

    }
}