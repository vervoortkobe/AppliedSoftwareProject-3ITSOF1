 a﻿using AP.MyGameStore.Application.CQRS.People;
using AP.MyGameStore.Application.Exceptions;
using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.MyGameStore.WebAPI.Controllers
{
    public class PeopleController : APIv1Controller
    {
        private readonly IPeopleService peopleService;
        private readonly IMediator mediator;

        public PeopleController(IPeopleService peopleService, IMediator mediator)
        {
            this.peopleService = peopleService;
            this.mediator = mediator;
        }

        [HttpGet]   //api/people?lastname=Janssens
        public async Task<IActionResult> GetAllPeople([FromQuery] string lastName, [FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            //return Ok(await peopleService.GetAll(pageNr, pageSize));
            return Ok(await mediator.Send(new GetAllPeopleQuery() { PageNr = pageNr, PageSize = pageSize }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {

            var person = await mediator.Send(new GetByIdQuery() { Id = id });//   peopleService.GetById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDetailDTO person)
        {
            //try
            //{
                return Created("", await mediator.Send(new AddCommand() { Person = person }));
                //return Created("", peopleService.Add(person));
            //}
            //catch (RelationNotFoundException ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }


        [Route("{id}")]  //api/people/id
        [HttpDelete]
        public IActionResult DeletePerson(int id, [FromHeader(Name = "X-AccessKey")] string AccessKey)
        {
            if (AccessKey != "123456789") return Unauthorized();

            try
            {
                peopleService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Person updatedPerson)
        {
            if (id != updatedPerson.Id) return BadRequest();

            try
            {
                return Ok(peopleService.Update(updatedPerson));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (RelationNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
