using FluentValidation;
using StudentLessonApp.Application.Features.Commands.Student.RegisterStudent;


namespace StudentLessonApp.Application.Validators.Student
{
    public class RegisterStudentValidator : AbstractValidator<RegisterStudentCommandRequest>
    {
        public RegisterStudentValidator()
        {
            RuleFor(validate => validate.FullName)
               .NotEmpty()
               .WithMessage("Please do not leave the name field blank.")
               .MinimumLength(2)
               .WithMessage("The minimum length for a name is 2 characters.")
               .MaximumLength(50)
               .WithMessage("The maksimum length for a name is 50 characters.")
               .Matches(@"^[\p{L}0-9\s]+$")
               .WithMessage("Company name can only contain letters, numbers, and spaces.");

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

            RuleFor(validate => validate.PasswordConfirm)
              .NotNull()
              .WithMessage("Please do not leave the password field blank.")
              .NotEmpty()
              .WithMessage("Please do not leave the password field blank.")
              .Equal(validate => validate.Password)
              .WithMessage("Password and confirm password must match.");



            RuleFor(validate => validate.Email)
                .NotNull()
                .WithMessage("Please do not leave the Email field blank.")
                .NotEmpty()
                .WithMessage("Please do not leave the Email field blank.")
                .MinimumLength(6)
                .WithMessage("The minimum length for a Email is 6 characters.")
                .MaximumLength(50)
                .WithMessage("The maximum length for a Email is 50 characters.")
                .EmailAddress()
                .WithMessage("Invalid email format.");
              

            RuleFor(validate => validate.Phone)
                .NotNull()
                .WithMessage("Please do not leave the phone field blank.")
                .NotEmpty()
                .WithMessage("Please do not leave the phone field blank.")
                .Matches(@"^\+?[1-9]\d{10,11}$")
                .WithMessage("Invalid phone number format. (901234567890)");

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
