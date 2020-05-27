using System;
using Microblink.Forms.Core.Parsers;
using Microblink;

namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// A collection of field by field elementas objects.
    /// </summary>
    public interface IFieldByFieldCollection
    {
        /// <summary>
        /// Gets the array of Field by field elements objects that will be used for recognition.
        /// </summary>
        /// <value>Field by field elements.</value>
        IFieldByFieldElement[] FieldByFieldElements { get; }
    }

    /// <summary>
    /// Field by field elements collection factory. Use this to create an instance of IFieldByFieldCollectionFactory.
    /// </summary>
    public interface IFieldByFieldCollectionFactory
    {
        /// <summary>
        /// Creates the fild by field collection from array of field by field elements objects.
        /// </summary>
        /// <returns>The recognizer collection.</returns>
        /// <param name="fieldByFieldElements">Elements that should be used in scanning.</param>
        IFieldByFieldCollection CreateFieldByFieldCollection(params IFieldByFieldElement[] fieldByFieldElements);
    }
}
