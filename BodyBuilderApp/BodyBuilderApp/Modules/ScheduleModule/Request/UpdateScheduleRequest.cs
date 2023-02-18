using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.ScheduleModule.Request
{
    public class UpdateScheduleRequest
    {
        public string ScheduleId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Status { get; set; }
        public string TrainerId { get; set; }
    }
    public class UpdateScheduleRequestValidator : AbstractValidator<UpdateScheduleRequest>
    {
        public UpdateScheduleRequestValidator()
        {
            RuleFor(x => x.ScheduleId).NotEmpty().NotNull();
            RuleFor(x => x.StartDate).NotEmpty().NotNull();
            RuleFor(x => x.EndDate).NotEmpty().NotNull();
            RuleFor(x => x.Status).NotEmpty().NotNull();
            RuleFor(x => x.TrainerId).NotEmpty().NotNull();
        }
    }
}
