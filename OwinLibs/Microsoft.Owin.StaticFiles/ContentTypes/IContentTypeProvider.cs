// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.Owin.StaticFiles.ContentTypes
{
    /// <summary>
    /// Used to look up MIME types given a file path
    /// </summary>
    public interface IContentTypeProvider
    {
        /// <summary>
        /// Given a file path, determine the MIME type
        /// </summary>
        /// <param name="subpath">A file path</param>
        /// <param name="contentType">The resulting MIME type</param>
        /// <returns>True if MIME type could be determined</returns>
        bool TryGetContentType(string subpath, out string contentType);
    }
}
