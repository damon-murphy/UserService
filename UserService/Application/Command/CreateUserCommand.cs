using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Interfaces;

namespace UserService.Application.Command
{
    public class CreateUserCommand : UserDto, IRequest<UserDto>
    {
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserManager _manager;

        public CreateUserCommandHandler(IUserManager manager)
        {
            _manager = manager;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _manager.CreateUser(request);
        }
    }
}
