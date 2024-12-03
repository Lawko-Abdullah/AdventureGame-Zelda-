using AdventureGame.Models;
using FluentValidation;

namespace AdventureGame.Services
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(player => player.Name).NotEmpty().WithMessage("Namn kan inte vara tomt.");
            RuleFor(player => player.Health).GreaterThan(0).WithMessage("Hälsa måste vara större än 0.");
        }
    }
}
