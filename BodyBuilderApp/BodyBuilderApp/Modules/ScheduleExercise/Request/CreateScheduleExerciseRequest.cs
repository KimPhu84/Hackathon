using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.ScheduleExerciseModule.Request
{
    public class CreateScheduleExerciseRequest
    {
        public string UserId { get; set; }
        public string ScheduleId { get; set; }
        public string ExerciseId { get; set; }
    }
    public class CreateScheduleExerciseRequestValidator : AbstractValidator<CreateScheduleExerciseRequest>
    {
        public CreateScheduleExerciseRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.ScheduleId).NotEmpty().NotNull();
            RuleFor(x => x.ExerciseId).NotEmpty().NotNull();
        }
    }
}
