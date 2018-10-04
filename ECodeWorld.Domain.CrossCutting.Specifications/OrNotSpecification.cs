﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.CrossCutting.Specifications.Core
{
    public class OrNotSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> left;
        ISpecification<T> right;

        public OrNotSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) || right.IsSatisfiedBy(candidate) != true;
    }
}
