﻿using BookRoom.Core.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace BookRoom.Application.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand,Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);

        book.Update(request.Title,request.Author,request.ISBN,request.YearPublication);

        if (book == null)
            throw new Exception("Book not found!");

        await _unitOfWork.BookRepository.UpdateBookAsync(book);

        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}