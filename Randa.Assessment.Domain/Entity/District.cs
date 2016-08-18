﻿using Randa.Assessment.Domain.Contracts.Entities;

namespace Randa.Assessment.Domain.Entity
{
    public class District: BaseEntity
    {
        public int DistrictId { get; set; }
        public int StateId { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }

        public District(int userId, IValidatorFactory validatorFactory) 
            : base(userId, validatorFactory)
        {
        }
    }
}