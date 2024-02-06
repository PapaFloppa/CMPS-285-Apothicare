using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
namespace LearningStarter.Controllers;


[ApiController]
[Route("api/Steps")]
public class StepsController : ControllerBase
{
    private readonly DataContext _dataContext;

    public StepsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = new Response();

        var data = _dataContext
        .Set<Steps>()
        .Select(Steps => new StepsGetDto
        {
            Id = Steps.Id,
            StepNumber = Steps.StepNumber,
            Instructions = Steps.Instructions,

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

        .Set<Steps>()
        .Select(Steps => new StepsGetDto
        {
            Id = Steps.Id,
            StepNumber = Steps.StepNumber,
            Instructions = Steps.Instructions,

        })
        .FirstOrDefault(Steps => Steps.Id == Id);
        response.Data = data;
        return Ok(response);


    }

    [HttpPost]
    public IActionResult Create([FromBody] StepsCreateDto createDto)
    {
        var response = new Response();


        if (response.HasErrors)
        {
            return BadRequest(response);

        }


        var StepsToCreate = new Steps
        {
            StepNumber = createDto.StepNumber,
            Instructions = createDto.Instructions,
        };

        _dataContext.Set<Steps>().Add(StepsToCreate);
        _dataContext.SaveChanges();

        var StepsToReturn = new StepsGetDto
        {
            Id = StepsToCreate.Id,
            StepNumber = StepsToCreate.StepNumber,
            Instructions = StepsToCreate.Instructions
        };

        response.Data = StepsToReturn;

        return Created("", response);

    }

    [HttpPut("{Id}")]
    public IActionResult Update([FromBody] StepsUpdateDto updateDto, int Id)
    {
        var response = new Response();

        var StepsToUpdate = _dataContext.Set<Steps>()
            .FirstOrDefault(Steps => Steps.Id == Id);


        if (StepsToUpdate == null)
        {
            response.AddError("Id", "Tag not found");
        }

        if (response.HasErrors)
        {
            return BadRequest(response);

        }

        StepsToUpdate.StepNumber = updateDto.StepNumber;

        _dataContext.SaveChanges();

        var StepsToReturn = new StepsGetDto
        {
            Id = StepsToUpdate.Id,
            StepNumber = StepsToUpdate.StepNumber,
            Instructions = StepsToUpdate.Instructions

        };

        response.Data = StepsToReturn;
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        var response = new Response();

        var StepsToDelete = _dataContext.Set<Steps>()
            .FirstOrDefault(Steps => Steps.Id == Id);
        if (StepsToDelete == null)
        {
            response.AddError("Id", "Tag not found");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }
        _dataContext.Set<Steps>().Remove(StepsToDelete);
        _dataContext.SaveChanges();

        response.Data = true;
        return Ok(response);

    }
}