using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Randa.Assessment.Domain.Contracts;

namespace Randa.Assessment.Domain.Entities
{
    public class Calendar: BaseEntity
    {
        public Calendar(int userId, IValidatorFactory validatorFactory) 
            : base(userId, validatorFactory)
        {
        }
    }
}
