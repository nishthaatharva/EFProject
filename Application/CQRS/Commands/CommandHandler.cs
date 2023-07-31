using Application.Abstract;
using Application.Exceptions;
using Application.Models.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Commands
{
    public class CommandHandler : IRequestHandler<AuthenticateCommand, CommandResponse>
    {
        private readonly ITokenService _tokenService;
        //   private readonly IMapper _mapper;
        //private readonly HttpContext _httpContext;

        public CommandHandler(ITokenService tokenService,
                              IHttpContextAccessor httpContextAccessor)
        {
            this._tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            //   this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            //this._httpContext = (httpContextAccessor != null) ? httpContextAccessor.HttpContext : throw new ArgumentNullException(nameof(httpContextAccessor));

        }

        public async Task<CommandResponse> Handle(AuthenticateCommand command, CancellationToken cancellationToken)
        {
            CommandResponse response = new CommandResponse();

            string ipAddress = "";// _httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            TokenResponse tokenResponse = await _tokenService.Authentication(command, ipAddress);
            if (tokenResponse == null)
            {
                throw new InvalidCredentialsException();
            }

            response.Resource = tokenResponse;
            return response;
        }
    }
}
