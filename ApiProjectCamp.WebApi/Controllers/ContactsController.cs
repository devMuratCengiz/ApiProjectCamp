﻿using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.DTOs.ContactDtos;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.MapLocation = createContactDto.MapLocation;
            contact.Address = createContactDto.Address;
            contact.Phone = createContactDto.Phone;
            contact.Email = createContactDto.Email;
            contact.OpeningHours = createContactDto.OpeningHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Added");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Deleted");
        }
        [HttpGet("GetById")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.Phone = updateContactDto.Phone;
            contact.OpeningHours = updateContactDto.OpeningHours;
            contact.Id = updateContactDto.Id;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Updated");
        }
    }
}
