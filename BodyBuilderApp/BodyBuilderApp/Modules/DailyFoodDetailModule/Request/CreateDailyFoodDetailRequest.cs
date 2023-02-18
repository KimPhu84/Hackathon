using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.DailyFoodDetailModule.Request
{
    public class CreateDailyFoodDetailRequest
    {
        public string DailyFoodDetailId { get; set; }
        public string DailyFoodId { get; set; }
        public string FoodName { get; set; }
        public string TimeToEat { get; set; }
        public string Recommend { get; set; }

    }
    public class CreateDailyFoodDetailRequestValidator : AbstractValidator<CreateDailyFoodDetailRequest>
    {
        public CreateDailyFoodDetailRequestValidator()
        {
            RuleFor(x => x.DailyFoodDetailId).NotEmpty().NotNull();
            RuleFor(x => x.DailyFoodId).NotEmpty().NotNull();
            RuleFor(x => x.FoodName).NotEmpty().NotNull();
            RuleFor(x => x.TimeToEat).NotEmpty().NotNull();
            RuleFor(x => x.Recommend).NotEmpty().NotNull();
        }
    }
}
