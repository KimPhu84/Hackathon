using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.BodyStatusModule.Request
{
    public class UpdateBodyStatusRequest
    {
        public string BodyStatusId { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }
    }
    public class UpdateBodyStatusRequestValidator : AbstractValidator<UpdateBodyStatusRequest>
    {
        public UpdateBodyStatusRequestValidator()
        {
            RuleFor(x => x.BodyStatusId).NotEmpty().NotNull();
            RuleFor(x => x.Weight).NotEmpty().NotNull();
            RuleFor(x => x.Height).NotEmpty().NotNull();
            RuleFor(x => x.Date).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
        }
    }
}
