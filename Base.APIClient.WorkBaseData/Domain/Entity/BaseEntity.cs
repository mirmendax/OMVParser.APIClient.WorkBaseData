using System;

namespace Base.APIClient.WorkBaseData.Domain.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        protected BaseEntity() => Id = new Guid();

    }
}
