using System;
using System.Collections.Generic;
using System.Dynamic;
using FluentValidation.Results;
using Newtonsoft.Json;
using Randa.Assessment.Domain.Contracts;

namespace Randa.Assessment.Domain.Entities
{
    /// <summary>
    /// This abstract class is intended to be the base for all the core
    /// (preserved) domain elements.
    /// </summary>
    public abstract class BaseEntity : IDeletable, IEntity
    {
        public string GlobalId { get; protected set; }

        public int CreatedByUserId { get; protected set; }
        public int UpdatedByUserId { get; protected set; }

        public DateTime DateCreated { get; protected set; }
        public DateTime DateUpdated { get; protected set; }

        public bool IsDeleted { get; protected set; }
        public dynamic Properties { get; set; }

        public string PropertiesJson
        {
            get
            {
                var result = Properties == null ? null : JsonConvert.SerializeObject(Properties);
                return result == "{}" ? null : result;
            }
        }

        public BaseEntity(int userId, string globalId, dynamic properties = null)
        {
            if (string.IsNullOrWhiteSpace(globalId)) { throw new ArgumentNullException(nameof(globalId)); }

            DateCreated = DateUpdated = DateTime.UtcNow;
            CreatedByUserId = UpdatedByUserId = userId;

            GlobalId = globalId;
            Properties = properties ?? new ExpandoObject();
            IsDeleted = false;
        }

        public BaseEntity(int userId) : this(userId, Guid.NewGuid().ToString()) { }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }

        public abstract bool IsValid(out IList<ValidationFailure> errors);
    }
}
