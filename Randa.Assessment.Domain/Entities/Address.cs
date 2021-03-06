﻿using System.Collections.Generic;
using FluentValidation.Results;
using Randa.Assessment.Domain.Validators;

namespace Randa.Assessment.Domain.Entities
{
    public class Address: BaseEntity
    {
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string PostalCode { get; set; }

        public Address(int userId) 
            : base(userId)
        {
        }

        public override bool IsValid(out IList<ValidationFailure> errors)
        {
            var result = new AddressValidator().Validate(this);
            errors = result.Errors;
            return result.IsValid;
        }
    }
}
