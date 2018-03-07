﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Net.Http.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("System.Net.Http.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Async Callback threw an exception..
        /// </summary>
        internal static string AsyncResult_CallbackThrewException {
            get {
                return ResourceManager.GetString("AsyncResult_CallbackThrewException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The IAsyncResult implementation &apos;{0}&apos; tried to complete a single operation multiple times. This could be caused by an incorrect application IAsyncResult implementation or other extensibility code, such as an IAsyncResult that returns incorrect CompletedSynchronously values or invokes the AsyncCallback multiple times..
        /// </summary>
        internal static string AsyncResult_MultipleCompletes {
            get {
                return ResourceManager.GetString("AsyncResult_MultipleCompletes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End cannot be called twice on an AsyncResult..
        /// </summary>
        internal static string AsyncResult_MultipleEnds {
            get {
                return ResourceManager.GetString("AsyncResult_MultipleEnds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An incorrect IAsyncResult was provided to an &apos;End&apos; method. The IAsyncResult object passed to &apos;End&apos; must be the one returned from the matching &apos;Begin&apos; or passed to the callback provided to &apos;Begin&apos;..
        /// </summary>
        internal static string AsyncResult_ResultMismatch {
            get {
                return ResourceManager.GetString("AsyncResult_ResultMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Found zero byte ranges. There must be at least one byte range provided..
        /// </summary>
        internal static string ByteRangeStreamContentNoRanges {
            get {
                return ResourceManager.GetString("ByteRangeStreamContentNoRanges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The range unit &apos;{0}&apos; is not valid. The range must have a unit of &apos;{1}&apos;..
        /// </summary>
        internal static string ByteRangeStreamContentNotBytesRange {
            get {
                return ResourceManager.GetString("ByteRangeStreamContentNotBytesRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream over which &apos;{0}&apos; provides a range view must have a length greater than or equal to 1..
        /// </summary>
        internal static string ByteRangeStreamEmpty {
            get {
                return ResourceManager.GetString("ByteRangeStreamEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;From&apos; value of the range must be less than or equal to {0}..
        /// </summary>
        internal static string ByteRangeStreamInvalidFrom {
            get {
                return ResourceManager.GetString("ByteRangeStreamInvalidFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to None of the requested ranges ({0}) overlap with the current extent of the selected resource..
        /// </summary>
        internal static string ByteRangeStreamNoneOverlap {
            get {
                return ResourceManager.GetString("ByteRangeStreamNoneOverlap", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The requested range ({0}) does not overlap with the current extent of the selected resource..
        /// </summary>
        internal static string ByteRangeStreamNoOverlap {
            get {
                return ResourceManager.GetString("ByteRangeStreamNoOverlap", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream over which &apos;{0}&apos; provides a range view must be seekable..
        /// </summary>
        internal static string ByteRangeStreamNotSeekable {
            get {
                return ResourceManager.GetString("ByteRangeStreamNotSeekable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is a read-only stream..
        /// </summary>
        internal static string ByteRangeStreamReadOnly {
            get {
                return ResourceManager.GetString("ByteRangeStreamReadOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A null &apos;{0}&apos; is not valid..
        /// </summary>
        internal static string CannotHaveNullInList {
            get {
                return ResourceManager.GetString("CannotHaveNullInList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; of &apos;{1}&apos; cannot be used as a supported media type because it is a media range..
        /// </summary>
        internal static string CannotUseMediaRangeForSupportedMediaType {
            get {
                return ResourceManager.GetString("CannotUseMediaRangeForSupportedMediaType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; type cannot accept a null value for the value type &apos;{1}&apos;..
        /// </summary>
        internal static string CannotUseNullValueType {
            get {
                return ResourceManager.GetString("CannotUseNullValueType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified value is not a valid cookie name..
        /// </summary>
        internal static string CookieInvalidName {
            get {
                return ResourceManager.GetString("CookieInvalidName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cookie cannot be null..
        /// </summary>
        internal static string CookieNull {
            get {
                return ResourceManager.GetString("CookieNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; list is invalid because it contains one or more null items..
        /// </summary>
        internal static string DelegatingHandlerArrayContainsNullItem {
            get {
                return ResourceManager.GetString("DelegatingHandlerArrayContainsNullItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; list is invalid because the property &apos;{1}&apos; of &apos;{2}&apos; is not null..
        /// </summary>
        internal static string DelegatingHandlerArrayHasNonNullInnerHandler {
            get {
                return ResourceManager.GetString("DelegatingHandlerArrayHasNonNullInnerHandler", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error reading HTML form URL-encoded data stream..
        /// </summary>
        internal static string ErrorReadingFormUrlEncodedStream {
            get {
                return ResourceManager.GetString("ErrorReadingFormUrlEncodedStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mismatched types at node &apos;{0}&apos;..
        /// </summary>
        internal static string FormUrlEncodedMismatchingTypes {
            get {
                return ResourceManager.GetString("FormUrlEncodedMismatchingTypes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error parsing HTML form URL-encoded data, byte {0}..
        /// </summary>
        internal static string FormUrlEncodedParseError {
            get {
                return ResourceManager.GetString("FormUrlEncodedParseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid HTTP status code: &apos;{0}&apos;. The status code must be between {1} and {2}..
        /// </summary>
        internal static string HttpInvalidStatusCode {
            get {
                return ResourceManager.GetString("HttpInvalidStatusCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid HTTP version: &apos;{0}&apos;. The version must start with the characters &apos;{1}&apos;..
        /// </summary>
        internal static string HttpInvalidVersion {
            get {
                return ResourceManager.GetString("HttpInvalidVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; of the &apos;{1}&apos; has already been read..
        /// </summary>
        internal static string HttpMessageContentAlreadyRead {
            get {
                return ResourceManager.GetString("HttpMessageContentAlreadyRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; must be seekable in order to create an &apos;{1}&apos; instance containing an entity body.  .
        /// </summary>
        internal static string HttpMessageContentStreamMustBeSeekable {
            get {
                return ResourceManager.GetString("HttpMessageContentStreamMustBeSeekable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error reading HTTP message..
        /// </summary>
        internal static string HttpMessageErrorReading {
            get {
                return ResourceManager.GetString("HttpMessageErrorReading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid &apos;{0}&apos; instance provided. It does not have a content type header with a value of &apos;{1}&apos;..
        /// </summary>
        internal static string HttpMessageInvalidMediaType {
            get {
                return ResourceManager.GetString("HttpMessageInvalidMediaType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to HTTP Request URI cannot be an empty string..
        /// </summary>
        internal static string HttpMessageParserEmptyUri {
            get {
                return ResourceManager.GetString("HttpMessageParserEmptyUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error parsing HTTP message header byte {0} of message {1}..
        /// </summary>
        internal static string HttpMessageParserError {
            get {
                return ResourceManager.GetString("HttpMessageParserError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An invalid number of &apos;{0}&apos; header fields were present in the HTTP Request. It must contain exactly one &apos;{0}&apos; header field but found {1}..
        /// </summary>
        internal static string HttpMessageParserInvalidHostCount {
            get {
                return ResourceManager.GetString("HttpMessageParserInvalidHostCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid URI scheme: &apos;{0}&apos;. The URI scheme must be a valid &apos;{1}&apos; scheme..
        /// </summary>
        internal static string HttpMessageParserInvalidUriScheme {
            get {
                return ResourceManager.GetString("HttpMessageParserInvalidUriScheme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid array at node &apos;{0}&apos;..
        /// </summary>
        internal static string InvalidArrayInsert {
            get {
                return ResourceManager.GetString("InvalidArrayInsert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Traditional style array without &apos;[]&apos; is not supported with nested object at location {0}..
        /// </summary>
        internal static string JQuery13CompatModeNotSupportNestedJson {
            get {
                return ResourceManager.GetString("JQuery13CompatModeNotSupportNestedJson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; method returned null. It must return a JSON serializer instance..
        /// </summary>
        internal static string JsonSerializerFactoryReturnedNull {
            get {
                return ResourceManager.GetString("JsonSerializerFactoryReturnedNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; method threw an exception when attempting to create a JSON serializer..
        /// </summary>
        internal static string JsonSerializerFactoryThrew {
            get {
                return ResourceManager.GetString("JsonSerializerFactoryThrew", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The maximum read depth ({0}) has been exceeded because the form url-encoded data being read has more levels of nesting than is allowed..
        /// </summary>
        internal static string MaxDepthExceeded {
            get {
                return ResourceManager.GetString("MaxDepthExceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The number of keys in a NameValueCollection has exceeded the limit of &apos;{0}&apos;. You can adjust it by modifying the MaxHttpCollectionKeys property on the &apos;{1}&apos; class..
        /// </summary>
        internal static string MaxHttpCollectionKeyLimitReached {
            get {
                return ResourceManager.GetString("MaxHttpCollectionKeyLimitReached", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error parsing BSON data; unable to read content as a {0}..
        /// </summary>
        internal static string MediaTypeFormatter_BsonParseError_MissingData {
            get {
                return ResourceManager.GetString("MediaTypeFormatter_BsonParseError_MissingData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error parsing BSON data; unexpected dictionary content: {0} entries, first key &apos;{1}&apos;..
        /// </summary>
        internal static string MediaTypeFormatter_BsonParseError_UnexpectedData {
            get {
                return ResourceManager.GetString("MediaTypeFormatter_BsonParseError_UnexpectedData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; method returned null. It must return a JSON reader instance..
        /// </summary>
        internal static string MediaTypeFormatter_JsonReaderFactoryReturnedNull {
            get {
                return ResourceManager.GetString("MediaTypeFormatter_JsonReaderFactoryReturnedNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; method returned null. It must return a JSON writer instance..
        /// </summary>
        internal static string MediaTypeFormatter_JsonWriterFactoryReturnedNull {
            get {
                return ResourceManager.GetString("MediaTypeFormatter_JsonWriterFactoryReturnedNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The media type formatter of type &apos;{0}&apos; does not support reading because it does not implement the ReadFromStreamAsync method..
        /// </summary>
        internal static string MediaTypeFormatterCannotRead {
            get {
                return ResourceManager.GetString("MediaTypeFormatterCannotRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The media type formatter of type &apos;{0}&apos; does not support reading because it does not implement the ReadFromStream method..
        /// </summary>
        internal static string MediaTypeFormatterCannotReadSync {
            get {
                return ResourceManager.GetString("MediaTypeFormatterCannotReadSync", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The media type formatter of type &apos;{0}&apos; does not support writing because it does not implement the WriteToStreamAsync method..
        /// </summary>
        internal static string MediaTypeFormatterCannotWrite {
            get {
                return ResourceManager.GetString("MediaTypeFormatterCannotWrite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The media type formatter of type &apos;{0}&apos; does not support writing because it does not implement the WriteToStream method..
        /// </summary>
        internal static string MediaTypeFormatterCannotWriteSync {
            get {
                return ResourceManager.GetString("MediaTypeFormatterCannotWriteSync", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No encoding found for media type formatter &apos;{0}&apos;. There must be at least one supported encoding registered in order for the media type formatter to read or write content..
        /// </summary>
        internal static string MediaTypeFormatterNoEncoding {
            get {
                return ResourceManager.GetString("MediaTypeFormatterNoEncoding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MIME multipart boundary cannot end with an empty space..
        /// </summary>
        internal static string MimeMultipartParserBadBoundary {
            get {
                return ResourceManager.GetString("MimeMultipartParserBadBoundary", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Did not find required &apos;{0}&apos; header field in MIME multipart body part..
        /// </summary>
        internal static string MultipartFormDataStreamProviderNoContentDisposition {
            get {
                return ResourceManager.GetString("MultipartFormDataStreamProviderNoContentDisposition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not determine a valid local file name for the multipart body part..
        /// </summary>
        internal static string MultipartStreamProviderInvalidLocalFileName {
            get {
                return ResourceManager.GetString("MultipartStreamProviderInvalidLocalFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nested bracket is not valid for &apos;{0}&apos; data at position {1}..
        /// </summary>
        internal static string NestedBracketNotValid {
            get {
                return ResourceManager.GetString("NestedBracketNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A non-null request URI must be provided to determine if a &apos;{0}&apos; matches a given request or response message..
        /// </summary>
        internal static string NonNullUriRequiredForMediaTypeMapping {
            get {
                return ResourceManager.GetString("NonNullUriRequiredForMediaTypeMapping", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No MediaTypeFormatter is available to read an object of type &apos;{0}&apos; from content with media type &apos;{1}&apos;..
        /// </summary>
        internal static string NoReadSerializerAvailable {
            get {
                return ResourceManager.GetString("NoReadSerializerAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An object of type &apos;{0}&apos; cannot be used with a type parameter of &apos;{1}&apos;..
        /// </summary>
        internal static string ObjectAndTypeDisagree {
            get {
                return ResourceManager.GetString("ObjectAndTypeDisagree", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The configured formatter &apos;{0}&apos; cannot write an object of type &apos;{1}&apos;..
        /// </summary>
        internal static string ObjectContent_FormatterCannotWriteType {
            get {
                return ResourceManager.GetString("ObjectContent_FormatterCannotWriteType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Query string name cannot be null..
        /// </summary>
        internal static string QueryStringNameShouldNotNull {
            get {
                return ResourceManager.GetString("QueryStringNameShouldNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected end of HTTP message stream. HTTP message is not complete..
        /// </summary>
        internal static string ReadAsHttpMessageUnexpectedTermination {
            get {
                return ResourceManager.GetString("ReadAsHttpMessageUnexpectedTermination", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid &apos;{0}&apos; instance provided. It does not have a &apos;{1}&apos; content-type header with a &apos;{2}&apos; parameter..
        /// </summary>
        internal static string ReadAsMimeMultipartArgumentNoBoundary {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartArgumentNoBoundary", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid &apos;{0}&apos; instance provided. It does not have a content-type header value. &apos;{0}&apos; instances must have a content-type header starting with &apos;{1}&apos;..
        /// </summary>
        internal static string ReadAsMimeMultipartArgumentNoContentType {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartArgumentNoContentType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid &apos;{0}&apos; instance provided. It does not have a content type header starting with &apos;{1}&apos;..
        /// </summary>
        internal static string ReadAsMimeMultipartArgumentNoMultipart {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartArgumentNoMultipart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error reading MIME multipart body part..
        /// </summary>
        internal static string ReadAsMimeMultipartErrorReading {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartErrorReading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error writing MIME multipart body part to output stream..
        /// </summary>
        internal static string ReadAsMimeMultipartErrorWriting {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartErrorWriting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error parsing MIME multipart body part header byte {0} of data segment {1}..
        /// </summary>
        internal static string ReadAsMimeMultipartHeaderParseError {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartHeaderParseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error parsing MIME multipart message byte {0} of data segment {1}..
        /// </summary>
        internal static string ReadAsMimeMultipartParseError {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartParseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream provider of type &apos;{0}&apos; threw an exception..
        /// </summary>
        internal static string ReadAsMimeMultipartStreamProviderException {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartStreamProviderException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream provider of type &apos;{0}&apos; returned null. It must return a writable &apos;{1}&apos; instance..
        /// </summary>
        internal static string ReadAsMimeMultipartStreamProviderNull {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartStreamProviderNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream provider of type &apos;{0}&apos; returned a read-only stream. It must return a writable &apos;{1}&apos; instance..
        /// </summary>
        internal static string ReadAsMimeMultipartStreamProviderReadOnly {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartStreamProviderReadOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected end of MIME multipart stream. MIME multipart message is not complete..
        /// </summary>
        internal static string ReadAsMimeMultipartUnexpectedTermination {
            get {
                return ResourceManager.GetString("ReadAsMimeMultipartUnexpectedTermination", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; method in &apos;{1}&apos; returned null. It must return a RemoteStreamResult instance containing a writable stream and a valid URL..
        /// </summary>
        internal static string RemoteStreamInfoCannotBeNull {
            get {
                return ResourceManager.GetString("RemoteStreamInfoCannotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; serializer cannot serialize the type &apos;{1}&apos;..
        /// </summary>
        internal static string SerializerCannotSerializeType {
            get {
                return ResourceManager.GetString("SerializerCannotSerializeType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is an unmatched opened bracket for the &apos;{0}&apos; at position {1}..
        /// </summary>
        internal static string UnMatchedBracketNotValid {
            get {
                return ResourceManager.GetString("UnMatchedBracketNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Indentation is not supported by &apos;{0}&apos;..
        /// </summary>
        internal static string UnsupportedIndent {
            get {
                return ResourceManager.GetString("UnsupportedIndent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The object of type &apos;{0}&apos; returned by {1} must be an instance of either XmlObjectSerializer or XmlSerializer..
        /// </summary>
        internal static string XmlMediaTypeFormatter_InvalidSerializerType {
            get {
                return ResourceManager.GetString("XmlMediaTypeFormatter_InvalidSerializerType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The object returned by {0} must not be a null value..
        /// </summary>
        internal static string XmlMediaTypeFormatter_NullReturnedSerializer {
            get {
                return ResourceManager.GetString("XmlMediaTypeFormatter_NullReturnedSerializer", resourceCulture);
            }
        }
    }
}
