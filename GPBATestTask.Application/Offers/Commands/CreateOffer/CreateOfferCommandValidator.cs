using FluentValidation;

namespace GPBATestTask.Application.Offers.Commands.CreateOffer;

public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
{
    public CreateOfferCommandValidator()
    {
        // Тут бизнес правила валидации создания оффера
    }
}