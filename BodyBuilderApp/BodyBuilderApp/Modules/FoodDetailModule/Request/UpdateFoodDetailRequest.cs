using FluentValidation;
using System;

namespace BodyBuilderApp.Modules.FoodDetailModule.Request
{
    public class UpdateFoodDetailRequest
    {
        public string FoodName { get; set; }
        public float Calories { get; set; }
        public string Image { get; set; }
    }
    public class UpdateFoodDetailRequestValidator : AbstractValidator<UpdateFoodDetailRequest>
    {
        public UpdateFoodDetailRequestValidator()
        {
            RuleFor(x => x.FoodName).NotEmpty().NotNull();
            RuleFor(x => x.Calories).NotEmpty().NotNull();
            RuleFor(x => x.Image).NotEmpty().NotNull();
        }
    }
}
