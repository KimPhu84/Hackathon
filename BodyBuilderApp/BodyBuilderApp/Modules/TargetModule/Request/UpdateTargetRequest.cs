using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.TargetModule.Request
{
    public class UpdateTargetRequest
    {
        public string TargetId { get; set; }
        public string TargetName { get; set; }
    }
    public class UpdateTargetRequestValidator : AbstractValidator<UpdateTargetRequest>
    {
        public UpdateTargetRequestValidator()
        {
            RuleFor(x => x.TargetId).NotEmpty().NotNull();
            RuleFor(x => x.TargetName).NotEmpty().NotNull();
        }
    }
}
