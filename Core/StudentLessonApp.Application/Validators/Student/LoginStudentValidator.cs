using FluentValidation;
using StudentLessonApp.Application.Features.Commands.Student.LoginStudent;


namespace StudentLessonApp.Application.Validators.Student
{
    public class LoginStudentValidator : AbstractValidator<LoginStudentCommandRequest>
    {
        public LoginStudentValidator()
        {
            RuleFor(validate => validate.Username)
               .NotNull()
               .WithMessage("Please do not leave the username field blank.")
               .NotEmpty()
               .WithMessage("Please do not leave the username field blank.")
               .MinimumLength(6)
               .WithMessage("The minimum length for a username is 6 characters.")
               .MaximumLength(20)
               .WithMessage("The maximum length for a username is 20 characters.")
               .Matches(@"^[\p{L}0-9\s]+$")
               .WithMessage("Company name can only contain letters, numbers, and spaces.");

            RuleFor(validate => validate.Password)
             .MinimumLength(8)
             .WithMessage("The minimum length for a password is 8 characters.")
             .MaximumLength(20)
             .WithMessage("The maximum length for a password is 20 characters.")
             .Matches("[A-Z]")
             .WithMessage("Password must contain at least one uppercase letter.")
             .Matches("[a-z]")
             .WithMessage("Password must contain at least one lowercase letter.")
             .Matches("[0-9]")
             .WithMessage("Password must contain at least one digit.")
             .Matches("[!@#$%^&*(),.?\":{}|<>]")
             .WithMessage("The password must contain special characters.")
             .Must(BeDifferentFromFirstAndLastCharacter)
             .WithMessage("Password is too weak.");
        }
        private bool BeDifferentFromFirstAndLastCharacter(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 2)
                return true;

            char firstChar = password[0];
            char lastChar = password[password.Length - 1];

            return char.ToLower(firstChar) != char.ToLower(lastChar);
        }
    }
}
