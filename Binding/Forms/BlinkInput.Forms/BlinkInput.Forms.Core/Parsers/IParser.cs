using System;
namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// Base class for all parsers.
    /// Parser is an object that performs recognition of image
    /// and updates its result with data extracted from the image.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Gets the base result of the parsers.
        /// </summary>
        /// <value>The base result.</value>
        IParserResult BaseResult { get; }

        /// <summary>
        /// Defines/returns whether the parser configured with this parser settings object will be required or optional..
        /// </summary>
        /// <value>Required or not</value>
        bool Required { get; set; }
    }

    /// <summary>
    /// Parser result state. This enum contains possible states in which
    /// Parser's result can be.
    /// </summary>
    public enum ParserResultState 
    {
        /// <summary>
        /// Parser result is empty.
        /// </summary>
        Empty,
        /// <summary>
        /// Parser result contains some values, but is incomplete or it 
        /// contains all values, but some are uncertain
        /// </summary>
        Uncertain,
        /// <summary>
        /// Parser result contains all required values.
        /// </summary>
        Valid
    }

    /// <summary>
    /// Base class for all parser's result objects.
    /// Parser result contains data extracted from the image.
    /// </summary>
    public interface IParserResult
    {
        /// <summary>
        /// Gets the state of the result.
        /// </summary>
        /// <value>The state of the result.</value>
        ParserResultState ResultState { get; }
    }
}
