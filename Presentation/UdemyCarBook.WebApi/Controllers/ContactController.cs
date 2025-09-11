using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace UdemyCarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController(
    GetContactByIdQueryHandler _getContactByIdQueryHandler,
    GetContactQueryHandler _getContactQueryHandler,
    CreateContactCommandHandler _createContactCommandHandler,
    UpdateContactCommandHandler _updateContactCommandHandler,
    RemoveContactCommandHandler _removeContactCommandHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        var values = await _getContactQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact(int id)
    {
        var value=await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactCommand command)
    {
        await _createContactCommandHandler.Handle(command);
        return Ok("iletişim bilgisi kaydedildi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveContact(int id)
    {
        await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
        return Ok("iletişim bilgisi silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
    {
        await _updateContactCommandHandler.Handle(command);
        return Ok("iletişim bilgisi güncellendi");
    }
}
