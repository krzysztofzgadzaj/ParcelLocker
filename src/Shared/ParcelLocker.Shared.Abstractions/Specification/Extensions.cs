﻿namespace ParcelLocker.Shared.Abstractions.Specification;

public static class Extensions
{
    public static OrSpecification<T> Or <T>(this Specification<T> left, Specification<T> right)
    {
        return new OrSpecification<T>(left, right);
    }
}