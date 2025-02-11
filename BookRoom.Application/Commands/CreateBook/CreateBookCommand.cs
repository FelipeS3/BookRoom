﻿using MediatR;

namespace BookRoom.Application.Commands.CreateBook;

public class CreateBookCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
    public int AddedQuantity { get; set; }
}