using System;
using System.ComponentModel.DataAnnotations;

namespace OMVParser.APIClient.WorkBaseData.Domain.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        protected BaseEntity() => Id = new Guid();

    }
}
