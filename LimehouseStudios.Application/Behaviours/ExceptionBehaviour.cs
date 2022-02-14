using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LimehouseStudios.Application.Behaviours
{
    public class ExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ExceptionBehaviour<TRequest, TResponse>> logger;

        public ExceptionBehaviour(ILogger<ExceptionBehaviour<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                var response = await next();

                return response;
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, exception.Message);

                throw;
            }
        }
    }
}
