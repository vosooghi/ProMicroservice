﻿using Ground.Core.Contracts.ApplicationServices.Commands;
using Ground.Core.Contracts.ApplicationServices.Common;
using Ground.Core.Domain.Exceptions;
using Ground.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.Translations.Abstractions;

namespace Ground.Core.ApplicationServices.Commands
{
   /// <summary>
   /// this class receives Validated command.
   /// Level 2
   /// </summary>
    public class CommandDispatcherDomainExceptionHandlerDecorator : CommandDispatcherDecorator
    {
        #region Fields
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CommandDispatcherDomainExceptionHandlerDecorator> _logger;
        #endregion

        #region Constructors
        //public CommandDispatcherDomainExceptionHandlerDecorator(IServiceProvider serviceProvider,
        //                                                        ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger)
        //{
        //    _serviceProvider = serviceProvider;
        //    _logger = logger;
        //}
        public CommandDispatcherDomainExceptionHandlerDecorator(CommandDispatcher commandDispatcher, IServiceProvider serviceProvider, ILogger<CommandDispatcherDomainExceptionHandlerDecorator> logger) : base(commandDispatcher)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public override int Order => 2;
        #endregion

        #region Send Commands
        /// <summary>
        /// handel domain state exception when proccessing commands
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public override async Task<CommandResult> Send<TCommand>(TCommand command)
        {
            try
            {
                //call the main dispatcher
                var result = _commandDispatcher.Send(command);
                return await result;
            }
            catch (DomainStateException ex)
            {
                _logger.LogError(GroundEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                return DomainExceptionHandlingWithoutReturnValue<TCommand>(ex);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is DomainStateException domainStateException)
                {
                    _logger.LogError(GroundEventId.DomainValidationException, domainStateException, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                    return DomainExceptionHandlingWithoutReturnValue<TCommand>(domainStateException);
                }
                throw ex;
            }

        }

        public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
        {
            try
            {
                var result = await _commandDispatcher.Send<TCommand, TData>(command);
                return result;

            }
            catch (DomainStateException ex)
            {
                _logger.LogError(GroundEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                return DomainExceptionHandlingWithReturnValue<TCommand, TData>(ex);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is DomainStateException domainStateException)
                {
                    _logger.LogError(GroundEventId.DomainValidationException, ex, "Processing of {CommandType} With value {Command} failed at {StartDateTime} because there are domain exceptions.", command.GetType(), command, DateTime.Now);
                    return DomainExceptionHandlingWithReturnValue<TCommand, TData>(domainStateException);
                }
                throw ex;
            }
        }
        #endregion

        #region Privaite Methods
        private CommandResult DomainExceptionHandlingWithoutReturnValue<TCommand>(DomainStateException ex)
        {
            var commandResult = new CommandResult
            {
                Status = ApplicationServiceStatus.InvalidDomainState
            };
            //add domain messages and return result
            commandResult.AddMessage(GetExceptionText(ex));

            return commandResult;
        }

        private CommandResult<TData> DomainExceptionHandlingWithReturnValue<TCommand, TData>(DomainStateException ex)
        {
            var commandResult = new CommandResult<TData>()
            {
                Status = ApplicationServiceStatus.InvalidDomainState
            };

            commandResult.AddMessage(GetExceptionText(ex));

            return commandResult;
        }

        private string GetExceptionText(DomainStateException domainStateException)
        {
            var translator = _serviceProvider.GetService<ITranslator>();
            if (translator == null)
                return domainStateException.ToString();

            var result = (domainStateException?.Parameters.Any() == true) ?
                 translator[domainStateException.Message, domainStateException.Parameters] :
                   translator[domainStateException?.Message];

            _logger.LogInformation(GroundEventId.DomainValidationException, "Domain Exception message is {DomainExceptionMessage}", result);

            return result;
        }
        #endregion
    }

}
