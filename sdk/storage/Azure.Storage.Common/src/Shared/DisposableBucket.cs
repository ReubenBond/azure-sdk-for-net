// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage
{
    /// <summary>
    /// Houses <see cref="IDisposable"/> references across a function that may
    /// create new disposables over time in various scopes, making the
    /// <c>using</c> pattern difficult to manage. For example, the following
    /// snippet makes it hard to declare the new resource in a using statement
    /// and still have access to the resource later in the method.
    /// <code>
    /// using (var bucket = new DisposableBucket())
    /// {
    ///     ...
    ///     MyDisposableType resource = null;
    ///     if (expression)
    ///     {
    ///         var resource = GetMyDisposableResource();
    ///         bucket.Add(resource)
    ///     }
    ///     ...
    ///     // use resource if available
    ///     // this use is outside the scope the IDisposable was found in
    ///     resource?.MyFunc();
    /// }
    /// </code>
    /// </summary>
    internal struct DisposableBucket : IDisposable
    {
        private object _value;

        public void Add(IDisposable disposable)
        {
            if (_value is null)
            {
                // Zero existing elements
                _value = disposable;
            }
            else if (_value is IDisposable existing)
            {
                // One existing element
                _value = new List<IDisposable>() { existing, disposable };
            }
            else
            {
                // Multiple existing elements
                ((List<IDisposable>)_value).Add(disposable);
            }
        }

        public void Dispose()
        {
            if (_value is null)
            {
                return;
            }
            else if (_value is IDisposable existing)
            {
                existing.Dispose();
            }
            else
            {
                var disposables = (List<IDisposable>)_value;
                foreach (IDisposable disposable in disposables)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}
