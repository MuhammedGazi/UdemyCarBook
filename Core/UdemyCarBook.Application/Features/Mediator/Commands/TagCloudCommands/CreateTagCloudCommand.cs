using MediatR;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;

public class CreateTagCloudCommand:IRequest
{
    public string Title { get; set; }
    public int BlogID { get; set; }
}
