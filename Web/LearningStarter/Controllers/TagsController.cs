using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStater.Entities;
using Microsoft.AspNetCore.Mvc;
namespace LearningStarter.Controllers;


[ApiController]
[Route("api/Tags")]
public class TagsController : ControllerBase
{
    private readonly DataContext _dataContext;

    public TagsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = new Response();

        var data = _dataContext
        .Set<Tags>()
        .Select(Tags => new TagsGetDto
        {
            Id = Tags.Id,
            Name = Tags.Name,
            Description = Tags.Description,

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

        .Set<Tags>()
        .Select(Tags => new TagsGetDto
        {
            Id = Tags.Id,
            Name = Tags.Name,
            Description = Tags.Description,

        })
        .FirstOrDefault(Tags => Tags.Id == Id);
        response.Data = data;
        return Ok(response);


    }

    [HttpPost]
    public IActionResult Create([FromBody] TagsCreateDto createDto)
    {
        var response = new Response();

        if (string.IsNullOrEmpty(createDto.Name))
        {
            response.AddError(nameof(createDto.Name), "URL must not be empty");

        }

        if (response.HasErrors)
        {
            return BadRequest(response);

        }


        var TagsToCreate = new Tags
        {
            Name = createDto.Name,
            Description = createDto.Description,
        };

        _dataContext.Set<Tags>().Add(TagsToCreate);
        _dataContext.SaveChanges();

        var TagsToReturn = new TagsGetDto
        {
            Id = TagsToCreate.Id,
            Name = TagsToCreate.Name,
            Description = TagsToCreate.Description
        };

        response.Data = TagsToReturn;

        return Created("", response);

    }

    [HttpPut("{Id}")]
    public IActionResult Update([FromBody] TagsUpdateDto updateDto, int Id)
    {
        var response = new Response();

        var TagsToUpdate = _dataContext.Set<Tags>()
            .FirstOrDefault(Tags => Tags.Id == Id);


        if (TagsToUpdate == null)
        {
            response.AddError("Id", "Tag not found");
        }

        if (response.HasErrors)
        {
            return BadRequest(response);

        }

        TagsToUpdate.Name = updateDto.Name;

        _dataContext.SaveChanges();

        var TagsToReturn = new TagsGetDto
        {
            Id = TagsToUpdate.Id,
            Name = TagsToUpdate.Name,
            Description = TagsToUpdate.Description

        };

        response.Data = TagsToReturn;
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        var response = new Response();

        var TagsToDelete = _dataContext.Set<Tags>()
            .FirstOrDefault(Tags => Tags.Id == Id);
        if (TagsToDelete == null)
        {
            response.AddError("Id", "Tag not found");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }
        _dataContext.Set<Tags>().Remove(TagsToDelete);
        _dataContext.SaveChanges();

        response.Data = true;
        return Ok(response);

    }
}