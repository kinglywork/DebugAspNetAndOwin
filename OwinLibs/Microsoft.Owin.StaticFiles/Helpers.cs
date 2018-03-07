﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Owin.StaticFiles
{
    internal static class Helpers
    {
        internal static bool IsGetOrHeadMethod(string method)
        {
            return IsGetMethod(method) || IsHeadMethod(method);
        }

        internal static bool IsGetMethod(string method)
        {
            return string.Equals("GET", method, StringComparison.OrdinalIgnoreCase);
        }

        internal static bool IsHeadMethod(string method)
        {
            return string.Equals("HEAD", method, StringComparison.OrdinalIgnoreCase);
        }

        internal static bool PathEndsInSlash(PathString path)
        {
            return path.Value.EndsWith("/", StringComparison.Ordinal);
        }

        internal static bool TryMatchPath(IOwinContext context, PathString matchUrl, bool forDirectory, out PathString subpath)
        {
            var path = context.Request.Path;

            if (forDirectory && !PathEndsInSlash(path))
            {
                path += new PathString("/");
            }

            if (path.StartsWithSegments(matchUrl, out subpath))
            {
                return true;
            }
            return false;
        }

        internal static bool TryParseHttpDate(string dateString, out DateTime parsedDate)
        {
            return DateTime.TryParseExact(dateString, Constants.HttpDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
        }
    }
}
