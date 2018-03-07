// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;

namespace Microsoft.Owin.Security.DataHandler.Encoder
{
    public class Base64TextEncoder : ITextEncoder
    {
        public string Encode(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        public byte[] Decode(string text)
        {
            return Convert.FromBase64String(text);
        }
    }
}
