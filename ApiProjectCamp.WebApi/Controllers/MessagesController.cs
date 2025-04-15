using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.DTOs.MessageDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var messages = _context.Messages.ToList();
            if (messages == null || !messages.Any())
            {
                return NotFound("No messages found.");
            }
            return Ok(_mapper.Map<List<ResultMessageDto>>(messages));
        }

        [HttpGet("GetById")]
        public IActionResult GetMessage(int id)
        {
            var message = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(message));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok(message);
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.Messages.Find(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return Ok("Deleted");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = _context.Messages.Find(updateMessageDto.Id);
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Updated");
        }
    }
}
