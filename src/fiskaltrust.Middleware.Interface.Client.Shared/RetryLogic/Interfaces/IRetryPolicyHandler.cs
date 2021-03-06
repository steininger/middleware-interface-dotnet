﻿using System;
using System.Threading.Tasks;

namespace fiskaltrust.Middleware.Interface.Client.Shared.RetryLogic.Interfaces
{
    public interface IRetryPolicyHandler<T>
    {
        Task<K> RetryFuncAsync<K>(Func<T, Task<K>> action);
    }
}