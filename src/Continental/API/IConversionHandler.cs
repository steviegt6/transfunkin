using System;
using System.Collections.Generic;

namespace Continental.API
{
    /// <summary>
    ///     Handles the conversion of JSONs between two types. These should contain mostly-isolated logic.
    /// </summary>
    /// <typeparam name="TFrom">The type to convert from.</typeparam>
    /// <typeparam name="TTo">The type to convert to.</typeparam>
    public interface IConversionHandler<TFrom, TTo> : IConversionHandler
        where TFrom : IConvertableJson where TTo : IConvertableJson
    {
        /// <summary>
        ///     The type to convert from.
        /// </summary>
        new Type FromType => typeof(TFrom);

        /// <summary>
        ///     The type to convert to.
        /// </summary>
        new Type ToType => typeof(TTo);

        /// <summary>
        ///     The instance of the object to convert from.
        /// </summary>
        new TFrom FromObject { get; }

        /// <summary>
        ///     The instance of the object to convert to.
        /// </summary>
        new TTo ToObject { get; }

        /// <summary>
        ///     Whether this handler should be used.
        /// </summary>
        /// <param name="from">The type to convert from.</param>
        /// <param name="to">The type to convert to.</param>
        /// <returns>Whether this conversion handler should be used.</returns>
        /// <remarks>
        ///     While you will often use <see cref="IConversionHandler{TFrom,TTo}"/>, you can use <see cref="IConversionHandler"/> to provide custom, untyped logic here.
        /// </remarks>
        bool ShouldUseHandler(TFrom from, TTo to);

        IConvertableJson IConversionHandler.FromObject => FromObject;

        IConvertableJson IConversionHandler.ToObject => ToObject;

        // Handle this ourselves. Users should implement IConversionHandler for custom logic here.
        bool IConversionHandler.ShouldUseHandler(in IConvertableJson from, in IConvertableJson to) =>
            ShouldUseHandler((TFrom) from, (TTo) to);
    }

    /// <summary>
    ///     Handles the conversion of JSONs between two types. These should contain mostly-isolated logic.
    /// </summary>
    public interface IConversionHandler
    {
        /// <summary>
        ///     The type to convert from.
        /// </summary>
        Type FromType { get; }

        /// <summary>
        ///     The type to convert to.
        /// </summary>
        Type ToType { get; }

        /// <summary>
        ///     The instance of the object to convert from.
        /// </summary>
        IConvertableJson FromObject { get; }

        /// <summary>
        ///     The instance of the object to convert to.
        /// </summary>
        IConvertableJson ToObject { get; }

        /// <summary>
        ///     Whether this handler should be used.
        /// </summary>
        /// <param name="from">The type to convert from.</param>
        /// <param name="to">The type to convert to.</param>
        /// <returns>Whether this conversion handler should be used.</returns>
        /// <remarks>
        ///     While you will often use <see cref="IConversionHandler{TFrom,TTo}"/>, you can use <see cref="IConversionHandler"/> to provide custom, untyped logic here.
        /// </remarks>
        bool ShouldUseHandler(in IConvertableJson from, in IConvertableJson to);

        /// <summary>
        ///     Handles converting the given collection of convertable parameters.
        /// </summary>
        /// <param name="input">The parameters to convert</param>
        /// <returns>The converted parameters.</returns>
        List<IConvertableParameter> Convert(List<IConvertableParameter> input);
    }
}