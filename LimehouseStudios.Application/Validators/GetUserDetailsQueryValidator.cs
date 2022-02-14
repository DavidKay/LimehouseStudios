using FluentValidation;
using LimehouseStudios.Application.Contracts;

namespace LimehouseStudios.Application.Validators
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            this.RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
