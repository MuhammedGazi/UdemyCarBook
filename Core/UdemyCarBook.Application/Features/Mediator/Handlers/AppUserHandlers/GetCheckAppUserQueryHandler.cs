using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandlers;

public class GetCheckAppUserQueryHandler(IRepositor<AppUser> _appUserRepository,IRepositor<AppRole> _appRoleRepository) : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
{
    public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
    {
        var values = new GetCheckAppUserQueryResult();
        var user = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password==request.Password);
        if (user == null)
        {
            values.IsExist = false;
        }
        else
        {
            values.IsExist = true;
            values.Username = user.UserName;
            values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
            values.Id= user.AppUserId;
        }
        return values;
    }
}
