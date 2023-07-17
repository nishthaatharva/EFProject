using FluentValidation;

namespace Application.CQRS.Commands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() {

            RuleFor(command => command.Request)
                 .NotNull()
                 .WithMessage("User object cannot be null.");

            RuleFor(command => command.Request.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required.")
                .MaximumLength(50)
                .WithMessage("First Name cannot exceed 50 characters.");

            RuleFor(command => command.Request.LastName)
                .NotEmpty()
                .WithMessage("LastName is required.")
                .MaximumLength(50)
                .WithMessage("Last Name cannot exceed 50 characters.");

            RuleFor(command => command.Request.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(command => command.Request.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MaximumLength(6)
                .WithMessage("Password must be atleast 6 characters long.");

            RuleFor(command => command.Request.ContactNo)
                .NotEmpty()
                .WithMessage("Contact Number is requires.");

            RuleFor(command => command.Request.City)
                .NotEmpty()
                .WithMessage("City is required.")
                .MaximumLength(50)
                .WithMessage("City cannot exceed 50 characters.");

            RuleFor(command => command.Request.Gender)
                .NotEmpty()
                .WithMessage("Gender is required.")
                .MaximumLength(10)
                .WithMessage("Gender cannot exceed 10 characters.");

        }
    }
}
