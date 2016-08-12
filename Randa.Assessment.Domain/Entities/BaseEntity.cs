using System;
using System.Collections.Generic;
using System.Dynamic;
using FluentValidation.Results;
using Newtonsoft.Json;
using Randa.Assessment.Domain.Contracts;
using Randa.Assessment.Domain.Contracts.Entities;

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

        private readonly IValidatorFactory _validatorFactory;

        public string PropertiesJson
        {
            get
            {
                var result = Properties == null ? null : JsonConvert.SerializeObject(Properties);
                return result == "{}" ? null : result;
            }
        }

        protected BaseEntity(int userId, string globalId, IValidatorFactory validatorFactory, dynamic properties = null)
        {
            if (string.IsNullOrWhiteSpace(globalId)) { throw new ArgumentNullException(nameof(globalId)); }

            DateCreated = DateUpdated = DateTime.UtcNow;
            CreatedByUserId = UpdatedByUserId = userId;

            GlobalId = globalId;
            Properties = properties ?? new ExpandoObject();
            IsDeleted = false;

            _validatorFactory = validatorFactory;
        }

        protected BaseEntity(int userId, IValidatorFactory validatorFactory)
            : this(userId, Guid.NewGuid().ToString(), validatorFactory)
        {
            
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }

        public bool IsValid(out IList<ValidationFailure> errors)
        {
            var result = _validatorFactory.GetValidator(GetType()).Validate(this);
            errors = result.Errors;
            return result.IsValid;
        }
    }
}
