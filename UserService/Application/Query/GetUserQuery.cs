using MediatR;
using UserService.Domain.Interfaces;

namespace UserService.API.Application.Query
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserManager _manager;

        public GetUserQueryHandler(IUserManager manager)
        {
            _manager = manager;
        }
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _manager.GetUser(request.Id);
        }
    }
}
