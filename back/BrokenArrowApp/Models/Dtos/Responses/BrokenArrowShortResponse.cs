﻿namespace BrokenArrowApp.Models.Dtos.Responses
{
    public class BrokenArrowShortResponse
    {

        public Guid BrokenArrowId { get; set; }

        public DateTime DisasterDate { get; set; }

        public string? BubbleDescription { get; set; }

    }
}