using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.TrainerModule.Request
{
    public class UpdateTrainerRequest
    {
        public string TrainerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }
    }
    public class UpdateTrainerRequestValidator : AbstractValidator<UpdateTrainerRequest>
    {
        public UpdateTrainerRequestValidator()
        {
            RuleFor(x => x.TrainerId).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
            RuleFor(x => x.Phone).NotEmpty().NotNull();
            RuleFor(x => x.Role).NotEmpty().NotNull();
            RuleFor(x => x.Status).NotEmpty().NotNull();
        }
    }
}
