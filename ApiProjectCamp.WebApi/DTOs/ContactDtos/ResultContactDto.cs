﻿namespace ApiProjectCamp.WebApi.DTOs.ContactDtos
{
    public class ResultContactDto
    {
        public int Id { get; set; }
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
    }
}
