﻿using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class Attendee
    {

        public int AttendeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone_Number { get; set; }

        public ICollection<Event> Events { get; set; }

    }
}
