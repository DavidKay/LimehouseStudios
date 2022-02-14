using LimehouseStudios.Application.Contracts;
using LimehouseStudios.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LimehouseStudios.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> Index()
        {
            var getAllUsersQuery = new GetAllUsersSummaryQuery();

            var response = await this.mediator.Send(getAllUsersQuery);

            if (response.IsSuccess && response.HasValue)
            {
                var viewModel = new SummaryViewModel(response.Value);
                return View(viewModel);
            }
            else
            {
                return Error();
            }
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> Details([FromQuery] int userId)
        {
            var getUserDetailsQuery = new GetUserDetailsQuery(userId);

            var response = await this.mediator.Send(getUserDetailsQuery);

            if (response.IsSuccess && response.HasValue)
            {
                var viewModel = new UserDetailsViewModel(response.Value);
                return View(viewModel);
            }
            else
            {
                return Error();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
