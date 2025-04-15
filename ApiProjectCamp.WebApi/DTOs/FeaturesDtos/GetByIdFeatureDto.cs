﻿namespace ApiProjectCamp.WebApi.DTOs.FeaturesDtos
{
    public class GetByIdFeatureDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
