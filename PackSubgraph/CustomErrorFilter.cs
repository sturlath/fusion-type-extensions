// -----------------------------------------------------------------------
// <copyright file="CustomErrorFilter.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace PackSubgraph;

using Microsoft.Extensions.Logging;

/// <summary>
/// Used to log errors that occur during query execution and to change a UnauthorizedAccessException message to more user friendly one.
/// </summary>
/// <remarks>
/// 
/// </remarks>
/// <param name="logger"></param>
public class CustomErrorFilter(ILogger<CustomErrorFilter> logger) : IErrorFilter
{
    private readonly ILogger<CustomErrorFilter> logger = logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public IError OnError(IError error)
    {
        logger.LogError(error.Exception, "An error occurred during query execution: {Message}", error.Message);

        // Check if the error is an UnauthorizedAccessException
        if (error.Exception is UnauthorizedAccessException)
        {
            // Change the error message to something more specific and user-friendly
            return error.WithMessage("You are not authorized to access this resource.");
        }

        // Return the original error if it's not an UnauthorizedAccessException
        return error;
    }
}
