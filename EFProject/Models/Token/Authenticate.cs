using FluentValidation;
using Infrastructure.Identity.Models.Authentication;
using MediatR;

namespace EFProject.Models.Token
{
    public class Authenticate
    {
        //Command
        public class AuthenticateCommand : TokenRequest, IRequest<CommandResponse>
        {

        }

        public class CommandResponse
        {
           public TokenResponse Resource { get; set; }
        }

        //Validator
        public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
        {
            public AuthenticateCommandValidator()
            {
                RuleFor(x => x.Username)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty();

                RuleFor(x => x.Password)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty();                
            }
        }       

    }
}
