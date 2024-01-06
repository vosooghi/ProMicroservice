﻿using FluentValidation;
using Ground.Core.Contracts.ApplicationServices.Commands;
using Ground.Core.Contracts.ApplicationServices.Common;
using Ground.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ground.Core.ApplicationServices.Commands
{
    /// <summary>
    /// This is a dispatcher. Level 1
    /// at first, it validates the command.
    /// </summary>
    public class CommandDispatcherValidationDecorator : CommandDispatcherDecorator
    {
        #region Fields
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CommandDispatcherValidationDecorator> _logger;
        #endregion

        #region Constructors
        public CommandDispatcherValidationDecorator(IServiceProvider serviceProvider,
                                                    ILogger<CommandDispatcherValidationDecorator> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public override int Order => 1;
        #endregion

        #region Send Commands
        public override async Task<CommandResult> Send<TCommand>(TCommand command)
        {
            _logger.LogDebug(GroundEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  start at :{StartDateTime}", command.GetType(), command, DateTime.Now);
            var validationResult = Validate<TCommand, CommandResult>(command);

            if (validationResult != null)
            {
                _logger.LogInformation(GroundEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  failed. Validation errors are: {ValidationErrors}", command.GetType(), command, validationResult.Messages);
                return validationResult;
            }
            _logger.LogDebug(GroundEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  finished at :{EndDateTime}", command.GetType(), command, DateTime.Now);
            return await _commandDispatcher.Send(command);
        }

        public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
        {
            _logger.LogDebug(GroundEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  start at :{StartDateTime}", command.GetType(), command, DateTime.Now);

            var validationResult = Validate<TCommand, CommandResult<TData>>(command);

            //if validation result is not null (has validation errors), return validation result and doesn't proccess the command
            if (validationResult != null)
            {
                _logger.LogInformation(GroundEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  failed. Validation errors are: {ValidationErrors}", command.GetType(), command, validationResult.Messages);
                return validationResult;
            }
            _logger.LogDebug(GroundEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  finished at :{EndDateTime}", command.GetType(), command, DateTime.Now);
            
            //if the command passed validations
            return await _commandDispatcher.Send<TCommand, TData>(command);
        }
        #endregion

        #region Privaite Methods
        /// <summary>
        /// Validate the command ragarding all validators registered in application for the command.
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TValidationResult"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        private TValidationResult Validate<TCommand, TValidationResult>(TCommand command) where TValidationResult : ApplicationServiceResult, new()
        {
            var validator = _serviceProvider.GetService<IValidator<TCommand>>();
            TValidationResult res = null;

            if (validator != null)
            {
                var validationResult = validator.Validate(command);
                if (!validationResult.IsValid)
                {
                    res = new()
                    {
                        Status = ApplicationServiceStatus.ValidationError
                    };
                    foreach (var item in validationResult.Errors)
                    {
                        res.AddMessage(item.ErrorMessage);
                    }
                }
            }
            else
            {
                _logger.LogInformation(GroundEventId.CommandValidation, "There is not any validator for {CommandType}", command.GetType());
            }
            return res;
        }
        #endregion
    }
}
