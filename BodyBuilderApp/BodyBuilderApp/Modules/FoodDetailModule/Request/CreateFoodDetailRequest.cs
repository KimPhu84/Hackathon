using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.FoodDetailModule.Request
{
    public class CreateFoodDetailRequest
    {
        public string FoodName { get; set; }
        public float Calories { get; set; }
        public string Image { get; set; }
    }
    public class CreateFoodDetailRequestValidator : AbstractValidator<CreateFoodDetailRequest>
    {
        public CreateFoodDetailRequestValidator()
        {
            RuleFor(x => x.FoodName).NotEmpty().NotNull();
            RuleFor(x => x.Calories).NotEmpty().NotNull();
            RuleFor(x => x.Image).NotEmpty().NotNull();
        }
    }
}
