using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using WebShop.Core;
using WebShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChairsController : ControllerBase
    {
        private readonly IChairService _ChairService;

        public ChairsController(IChairService chairservice)
        {
            _ChairService = chairservice;
        }

        // GET: api/chairs
        [HttpGet]
        public ActionResult<IEnumerable<Chair>> Get(
            [FromQuery] int page,
            [FromQuery] int items,
            [FromQuery] string designers,
            [FromQuery] string tags,
            [FromQuery] string colors,
            [FromQuery] string makers)
        {
            List<Chair> chairs;
            var colorsList = new List<Color>();
            if (colors != null)
            {
                var colorsSplit = colors.Split(',').ToList();
                colorsSplit.ForEach(color => colorsList.Add(new Color() {Name = color}));
            }

            var tagsList = new List<Tag>();
            if (tags != null)
            {
                var tagsSplit = tags.Split(',').ToList();
                tagsSplit.ForEach(tag => tagsList.Add(new Tag() {Name = tag}));
            }

            var designersList = new List<Designer>();
            if (designers != null)
            {
                var designersSplit = designers.Split(',').ToList();
                designersSplit.ForEach(designer =>
                {
                    if (designer == "") return;
                    
                    designer = designer.Replace("%20", " ");
                    Console.WriteLine("designer is: " + designer);
                    var firstname = designer.Split(' ')[0];
                    var lastname = designer.Split(' ')[1];
                    designersList.Add(new Designer() {FirstName = firstname, LastName = lastname});
                });
            }

            var makersList = new List<Maker>();
            if (makers != null)
            {
                var makersSplit = makers.Split(',').ToList();
                makersSplit.ForEach(maker => makersList.Add(new Maker() {Name = maker}));
            }

            var filter = new Filter()
            {
                Colors = colorsList,
                Tags = tagsList,
                Designers = designersList,
                Makers = makersList
            };

            if (page < 1 || items < 1)
            {
                chairs = _ChairService.GetAllChairs();
            }
            else
            {
                try
                {
                    chairs = _ChairService.GetChairsPaged(page, items);
                }
                catch (ArgumentException)
                {
                    return BadRequest("The page number is to high");
                }

                
            }
            if (colorsList.Any()
                || tagsList.Any()
                || designersList.Any()
                || makersList.Any())
            {
                chairs = _ChairService.FilterChairs(chairs, filter);
            }

            return Ok(chairs);
        }

        // GET api/chairs/5
        [HttpGet("{id}")]
        public ActionResult<Chair> Get(int id)
        {
            Chair chair = null;
            try
            {
                chair = _ChairService.GetChairById(id);
            }
            catch (ArgumentException)
            {
                BadRequest("There is no chair with this id");
            }

            return Ok(chair);
        }

        // POST api/chairs
        [HttpPost]
        public ActionResult Post([FromBody] Chair chair)
        {
            try
            {
                _ChairService.AddChair(chair);
            }
            catch (InvalidDataException)
            {
                return BadRequest("A chair needs a name and a positive price");
            }

            return Ok();
        }

        // PUT api/chairs/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Chair chair)
        {
            chair.Id = id;

            try
            {
                _ChairService.UpdateChair(chair);
            }
            catch (ArgumentException)
            {
                BadRequest("There is no chair with this id");
            }


            return Ok();
        }

        // DELETE api/chairs/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _ChairService.DeleteChair(id);
            }
            catch (ArgumentException)
            {
                BadRequest("There is no chair with this id");
            }

            return Ok();
        }
    }
}