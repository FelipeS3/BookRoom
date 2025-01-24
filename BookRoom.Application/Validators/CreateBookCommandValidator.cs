//using BookRoom.Application.Commands.CreateBook;
//using FluentValidation;

//namespace BookRoom.Application.Validators;

//public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
//{
//    public CreateBookCommandValidator()
//    {
//        RuleFor(b => b.Title)
//            .MaximumLength(200)
//            .WithMessage("The title cannot be longer than 200 characters.");

//        RuleFor(b => b.Author)
//            .MaximumLength(100)
//            .WithMessage("The author cannot be longer than 100 characters.");

//        RuleFor(b => b.ISBN)
//            .MaximumLength(13)
//            .WithMessage("The ISBN cannot be longer than 13 characters.");

//        RuleFor(b => b.AddedQuantity)
//            .NotEmpty()
//            .WithMessage("The quantity added cannot be empty.")
//            .GreaterThan(0)
//            .WithMessage("The quantity added must be greater than zero.");
//    }
//}