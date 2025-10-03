using MediatR;
using UdemyCarBook.Application.Enums;
using UdemyCarBook.Application.Features.Mediator.Commands.AppUserCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers;

public class CreateAppUserCommandHandler(IRepositor<AppUser> _repository) : IRequestHandler<CreateAppUserCommand>
{
    public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new AppUser
        {
            Password=request.Password,
            UserName=request.Username,
            AppRoleId=(int)RolesType.Member,
            Email=request.Email,
            Name=request.Name,
            Surname=request.Surname
        });
    }
}
