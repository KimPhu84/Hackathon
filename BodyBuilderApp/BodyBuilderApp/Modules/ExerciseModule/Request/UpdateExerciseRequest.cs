using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.ExerciseModule.Request
{
    public class UpdateExerciseRequest
    {
        public string ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int Set { get; set; }
        public string BodyPart { get; set; }
        public string Step { get; set; }
        public int Rep { get; set; }
        public float CaloBurn { get; set; }
    }
    public class UpdateExerciseRequestValidator : AbstractValidator<UpdateExerciseRequest>
    {
        public UpdateExerciseRequestValidator()
        {
            RuleFor(x => x.ExerciseId).NotEmpty().NotNull();
            RuleFor(x => x.ExerciseName).NotEmpty().NotNull();
            RuleFor(x => x.Set).NotEmpty().NotNull();
            RuleFor(x => x.BodyPart).NotEmpty().NotNull();
            RuleFor(x => x.Step).NotEmpty().NotNull();
            RuleFor(x => x.Rep).NotEmpty().NotNull();
            RuleFor(x => x.CaloBurn).NotEmpty().NotNull();
        }
    }
}
