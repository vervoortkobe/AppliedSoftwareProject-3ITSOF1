using AP.MyGameStore.Application.CQRS.People;
using AP.MyGameStore.Application.CQRS.Stores;
using AP.MyGameStore.Application.Exceptions;
using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static AP.MyGameStore.Application.Interfaces.IStoresRepository;

namespace AP.MyGameStore.WebAPI.Controllers
{
    public class StoresController : APIv1Controller
    {
        private readonly IStoresService storesService;
        private readonly IMediator mediator;

        public StoresController(IStoresService storesService, IMediator mediator)
        {
            this.storesService = storesService;
            this.mediator = mediator;
        }

        [HttpGet]   //api/people?lastname=Janssens
        public async Task<IActionResult> GetAllStores([FromQuery] string name, [FromQuery] SortBy orderBy = SortBy.ByNameAscending, [FromQuery] int page = 1, [FromQuery] int pageLength = 10)
        {
            //return Ok(storesService.GetAll(page, pageLength, orderBy, name));
            return Ok(await mediator.Send(new GetAllStoresQuery() { PageNr = page, PageSize = pageLength, SortBy = orderBy }));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStore(int id)
        {
            var store = await storesService.GetById(id);
            if (store == null)
                return NotFound();

            return Ok(store);
        }


        [HttpPost]
        public IActionResult CreateStore([FromBody] Store store)
        {
            try
            {
                return Created("", storesService.Add(store));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("{id}")]  //api/people/id
        [HttpDelete]
        public IActionResult DeleteStore(int id, [FromHeader(Name = "X-AccessKey")] string AccessKey)
        {
            //if (AccessKey != "123456789") return Unauthorized();

            try
            {
                storesService.Delete(id);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStore(int id, [FromBody] Store updatedStore)
        {
            if (id != updatedStore.Id) return BadRequest();

            try
            {
                return Ok(storesService.Update(updatedStore));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        [Route("{storeId}/employees")]
        public IActionResult GetEmployees(int storeId)
        {
            return Ok(storesService.GetEmployees(storeId));
        }

        [HttpDelete]
        [Route("{storeId}/employees")]
        public IActionResult DeleteEmployees(int storeId)
        {
            storesService.DeleteEmployees(storeId);
            return NoContent();
        }


    }
}
