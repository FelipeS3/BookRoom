using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using BookRoom.Application.ViewModels;
using BookRoom.Core.Entities;
using BookRoom.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookRoom.Application.Queries.GetAllBooks;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllBooksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var allBooks = await _unitOfWork.BookRepository.GetAllBooks();

        return allBooks.Select(book => new BookViewModel(
                book.Id, 
                book.Title, 
                book.Author, 
                book.YearPublication))
                .ToList();

    }
}