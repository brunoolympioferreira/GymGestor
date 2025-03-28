﻿using GymGestor.Application.Models.ViewModels;
using GymGestor.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GymGestor.API.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is GymGestorException)
            HandleGymGestorException(context);
        else
            ThrowUnknownError(context);
    }

    private void HandleGymGestorException(ExceptionContext context)
    {
        if (context.Exception is ValidationErrorsException)
            HandleValidationErrorsException(context);
        else if (context.Exception is NotFoundErrorException)
            HandleNotFoundErrorsException(context);
    }

    private void HandleNotFoundErrorsException(ExceptionContext context)
    {
        NotFoundErrorException? notFoundErrorException = context.Exception as NotFoundErrorException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        context.Result = new ObjectResult(new ErrorViewModel(notFoundErrorException.Message));
    }

    private void HandleValidationErrorsException(ExceptionContext context)
    {
        ValidationErrorsException? validationErrorException = context.Exception as ValidationErrorsException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        if (!string.IsNullOrEmpty(validationErrorException?.Message))
        {
            context.Result = new ObjectResult(validationErrorException.Message);
        }
        else
        {
            context.Result = new ObjectResult(new ErrorViewModel(validationErrorException.ErrorMessages));
        }
    }

    private static void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorViewModel(context.Exception.Message));
    }
}
