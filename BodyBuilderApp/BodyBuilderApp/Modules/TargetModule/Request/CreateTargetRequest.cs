using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.TargetModule.Request
{
    public class CreateTargetRequest
    {
        public string TargetId { get; set; }
        public string TargetName { get; set; }
    }
    public class CreateTargetRequestValidator : AbstractValidator<CreateTargetRequest>
    {
        public CreateTargetRequestValidator()
        {
            RuleFor(x => x.TargetId).NotEmpty().NotNull();
            RuleFor(x => x.TargetName).NotEmpty().NotNull();
        }
    }
}
