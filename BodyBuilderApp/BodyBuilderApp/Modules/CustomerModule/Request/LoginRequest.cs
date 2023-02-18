using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.CustomerModule.Request
{
    public class CreateCustomerRequest
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string TargetId { get; set; }
        public string BodyStatusId { get; set; }
        public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
        {
            public CreateCustomerRequestValidator()
            {
                RuleFor(x => x.UserId).NotEmpty().NotNull();
                RuleFor(x => x.Name).NotEmpty().NotNull();
                RuleFor(x => x.Password).NotEmpty().NotNull();
                RuleFor(x => x.Email).NotEmpty().NotNull();
                RuleFor(x => x.Phone).NotEmpty().NotNull();
                RuleFor(x => x.Gender).NotEmpty().NotNull();
                RuleFor(x => x.Address).NotEmpty().NotNull();
                RuleFor(x => x.Role).NotEmpty().NotNull();
                RuleFor(x => x.TargetId).NotEmpty().NotNull();
                RuleFor(x => x.BodyStatusId).NotEmpty().NotNull();
            }
        }
    }
}
