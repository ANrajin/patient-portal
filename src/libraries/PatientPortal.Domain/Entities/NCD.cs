﻿namespace PatientPortal.Domain.Entities
{
    public sealed class NCD : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
