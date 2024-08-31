using ChatGPTClone.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace ChatGPTClone.Application.Features.ChatSessions.Commands.Create;
public class ChatSessionCreateCommandValidator:AbstractValidator<ChatSessionCreateCommand>
{
    public ChatSessionCreateCommandValidator(IStringLocalizer<CommonLocalization> localizer
    )
    {
        RuleFor(x => x.Model)
            .NotNull()
            .WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, "Model"])
            .NotEmpty()
            .WithMessage(x=> localizer[CommonLocalizationKeys.ValidationIsRequired,nameof(x.Model)])
            .IsInEnum()
            .WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.Model)]);

        RuleFor(x => x.Content)
            .NotNull()
            .WithMessage(x => localizer[CommonLocalizationKeys.ValidationIsRequired, nameof(x.Content)])
            .MaximumLength(4000)
            .WithMessage(x => localizer[CommonLocalizationKeys.ValidationMustBeBetween, nameof(x.Content),5,4000]);
    }

}




