﻿namespace PlatformService.Dtos
{
    public class PlatformReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string Cost { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
