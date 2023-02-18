using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.CustomerModule.Request
{
    public class LoginCustomerRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginCustomerRequestValidator : AbstractValidator<LoginCustomerRequest>
        {
            public LoginCustomerRequestValidator()
            {
                RuleFor(x => x.Password).NotEmpty().NotNull();
                RuleFor(x => x.Email).NotEmpty().NotNull();
            }
        }
    }
}
