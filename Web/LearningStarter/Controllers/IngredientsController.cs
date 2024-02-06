using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
namespace LearningStarter.Controllers;


[ApiController]
[Route("api/Ingredients")]
public class IngredientsController : ControllerBase
{
    private readonly DataContext _dataContext;

    public IngredientsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = new Response();

        var data = _dataContext
        .Set<Ingredients>()
        .Select(ingredients => new IngredientsGetDto
        {
            Id = ingredients.Id,
            Name = ingredients.Name,
            Description = ingredients.Description,

        })
        .ToList();
        response.Data = data;
        return Ok(response);
    }



    [HttpGet("{Id}")]
    public IActionResult GetById(int Id)
    {
        var response = new Response();

        var data = _dataContext

        .Set<Ingredients>()
        .Select(ingredients => new IngredientsGetDto
        {
            Id = ingredients.Id,
            Name = ingredients.Name,
            Description= ingredients.Description,

        })
        .FirstOrDefault(Ingredients => Ingredients.Id == Id);
        response.Data = data;
        return Ok(response);


    }

    [HttpPost]
    public IActionResult Create([FromBody] IngredientsCreateDto createDto)
    {
        var response = new Response();

        if (string.IsNullOrEmpty(createDto.Name))
        {
            response.AddError(nameof(createDto.Name), "Name must not be empty");

        }
        if (string.IsNullOrEmpty(createDto.Description))
        {
            response.AddError(nameof(createDto.Description), "Description");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }


        var IngredientsToCreate = new Ingredients
        {
            Name = createDto.Name,
            Description = createDto.Description,
        };

        _dataContext.Set<Ingredients>().Add(IngredientsToCreate);
        _dataContext.SaveChanges();

        var IngredientsToReturn = new IngredientsGetDto
        {
            Id = IngredientsToCreate.Id,
            Name = IngredientsToCreate.Name,
            Description = IngredientsToCreate.Description,
        };

        response.Data = IngredientsToReturn;

        return Created("", response);

    }

    [HttpPut("{Id}")]
    public IActionResult Update([FromBody] IngredientsUpdateDto updateDto, int Id)
    {
        var response = new Response();

        var IngredientsToUpdate = _dataContext.Set<Ingredients>()
            .FirstOrDefault(Ingredients => Ingredients.Id == Id);


        if (IngredientsToUpdate == null)
        {
            response.AddError("Id", "Ingredient not found");
        }
        if (string.IsNullOrEmpty(updateDto.Name))
        {
            response.AddError(nameof(updateDto.Name), "Name must not be empty");

        }
        if (string.IsNullOrEmpty(updateDto.Description))
        {
            response.AddError(nameof(updateDto.Description), "Description");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }

        IngredientsToUpdate.Name = updateDto.Name;
        IngredientsToUpdate.Description = updateDto.Description;

        _dataContext.SaveChanges();

        var IngredientsToReturn = new IngredientsGetDto
        {
            Id = IngredientsToUpdate.Id,
            Name = IngredientsToUpdate.Name,
            Description = IngredientsToUpdate.Description,

        };

        response.Data = IngredientsToReturn;
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        var response = new Response();

        var IngredientsToDelete = _dataContext.Set<Ingredients>()
            .FirstOrDefault(Ingredients => Ingredients.Id == Id);
        if (IngredientsToDelete == null)
        {
            response.AddError("Id", "Ingredient not found");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }
        _dataContext.Set<Ingredients>().Remove(IngredientsToDelete);
        _dataContext.SaveChanges();

        response.Data = true;
        return Ok(response);

    }
}