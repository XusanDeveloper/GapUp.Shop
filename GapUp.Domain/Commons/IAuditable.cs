﻿using GapUp.Domain.Entites.Enums;

namespace GapUp.Domain.Entites.Commons
{
    internal interface IAuditable
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
        DateTime DeletedAt { get; set; }
        Guid UpdatedBy { get; set; }
        ItemState State { get; set; }

        void Create();
        void Update();
        void Delete();
    }
}
