﻿namespace BookRoom.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        
    }
    public int Id { get; set; }
}