using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    public class SystemController : Controller
    {
        private readonly ISystemService _systemService;
        private readonly IUserService _userService;

        public SystemController(ISystemService systemService, IUserService userService)
        {
            _systemService = systemService;
            _userService = userService;
        }

        [HttpGet("VerifyFirstUse")]
        public async Task<ActionResult> VerifyFirstUse()
        {
            bool registeredUserExists = await _userService.RegisteredUserExistsAsync();

            return Ok(new
            {
                firstUse = !registeredUserExists,
            });
        }

        [HttpGet("GetItemsQuantity")]
        public async Task<ActionResult> GetItemsQuantity()
        {
            ItemsQuantityDTO itemsQuantityDTO = await _systemService.GetItemsQuantityAsync();

            return Ok(itemsQuantityDTO);
        }
    }
}
