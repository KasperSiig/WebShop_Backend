using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.ApplicationService;
using WebShop.Core.Entity;

namespace WebShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IFilterService _filterService;

        public FiltersController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet("tags")]
        public ActionResult<List<Tag>> GetTags()
        {
            return Ok(_filterService.GetTags());
        }

        [HttpGet]
        public ActionResult Get()
        {
            var filters = new
            {
                Tags = _filterService.GetTags(),
                Designers = _filterService.GetDesigners(),
                Colors = _filterService.GetColors(),
                Makers = _filterService.GetMakers()
            };
            return Ok(filters);
        }
    }
}