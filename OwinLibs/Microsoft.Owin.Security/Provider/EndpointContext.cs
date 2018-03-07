﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.Owin.Security.Provider
{
    public abstract class EndpointContext : BaseContext
    {
        protected EndpointContext(IOwinContext context)
            : base(context)
        {
        }

        public bool IsRequestCompleted { get; private set; }

        public void RequestCompleted()
        {
            IsRequestCompleted = true;
        }
    }
}
