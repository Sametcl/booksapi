using AutoMapper.Configuration.Conventions;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]

    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);
        }


        [HttpGet("{id}")]
        public IActionResult GetOneBook(int id)
        {
            var books = _manager.BookService.GetOneBookById(id, false);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }


        [HttpPost]
        public IActionResult CreateOneBook(Book model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                _manager.BookService.CreateOneBook(model);
                return StatusCode(201, model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneBook(int id)
        {
            try
            {
                _manager.BookService.DeleteOneBook(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            try
            {
                if (bookDto == null)
                {
                    return BadRequest();
                }

                _manager.BookService.UpdateOneBook(id, bookDto, true);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateOneBook(int id, JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                var entity = _manager.BookService.GetOneBookById(id, true);

                if (entity == null)
                {
                    return NotFound();
                }
                bookPatch.ApplyTo(entity);
                _manager.BookService.UpdateOneBook(id,
                    new BookDtoForUpdate(entity.Id, entity.Title, entity.Price),
                    true);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}

