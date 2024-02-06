using System;
using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
namespace LearningStarter.Controllers;


[ApiController]
[Route("api/Ratings")]
public class RatingsController : ControllerBase
{
    private readonly DataContext _dataContext;

    public RatingsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = new Response();

        var data = _dataContext
        .Set<Ratings>()
        .Select(ratings => new RatingsGetDto
        {
            Id = ratings.Id,
            Name = ratings.Name,
            Score = ratings.Score,
            Comment = ratings.Comment,
            Date = ratings.Date,
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

        .Set<Ratings>()
        .Select(ratings => new RatingsGetDto
        {
            Id = ratings.Id,
            Name = ratings.Name,
            Score = ratings.Score,
            Comment = ratings.Comment,
            Date = ratings.Date ,

        })
        .FirstOrDefault(Ratings => Ratings.Id == Id);
        response.Data = data;
        return Ok(response);


    }

    [HttpPost]
    public IActionResult Create([FromBody] RatingsCreateDto createDto)
    {
        var response = new Response();

        if(string.IsNullOrEmpty(createDto.Name))
        {
            response.AddError(nameof(createDto.Name), "Name must not be empty");

        }

        if (createDto.Score < 1 || createDto.Score > 5)
        {
            response.AddError(nameof(createDto.Score), "Score must be between 1 and 5 ");

        }
        if (string.IsNullOrEmpty(createDto.Comment))
        {
            response.AddError(nameof(createDto.Comment), "Comment must not be empty");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }


        var RatingsToCreate = new Ratings
        {
            Name = createDto.Name,
            Score = createDto.Score,
            Comment = createDto.Comment,
            Date = createDto.Date,
        };

        _dataContext.Set<Ratings>().Add(RatingsToCreate);
        _dataContext.SaveChanges();

        var RatingsToReturn = new RatingsGetDto
        {
            Id = RatingsToCreate.Id,
            Name = RatingsToCreate.Name,
            Score = RatingsToCreate.Score,
            Comment = RatingsToCreate.Comment,
            Date = RatingsToCreate.Date,
        };

        response.Data = RatingsToReturn;

        return Created("", response);

    }

    [HttpPut("{Id}")]
    public IActionResult Update([FromBody] RatingsUpdateDto updateDto, int Id)
    {
        var response = new Response();

        var RatingsToUpdate = _dataContext.Set<Ratings>()
            .FirstOrDefault(Ratings => Ratings.Id == Id);


        if (RatingsToUpdate == null) {
            response.AddError("Id", "Rating not found");
        }
        if (string.IsNullOrEmpty(updateDto.Name))
        {
            response.AddError(nameof(updateDto.Name), "Name must not be empty");

        }

        if (updateDto.Score < 1 || updateDto.Score > 5)
        {
            response.AddError(nameof(updateDto.Score), "Score must be between 1 and 5 ");

        }
        if (string.IsNullOrEmpty(updateDto.Comment))
        {
            response.AddError(nameof(updateDto.Comment), "Comment must not be empty");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }

        RatingsToUpdate.Name = updateDto.Name;
        RatingsToUpdate.Score = updateDto.Score;
        RatingsToUpdate.Comment = updateDto.Comment;
        RatingsToUpdate.Date = updateDto.Date;

        _dataContext.SaveChanges();

        var RatingsToReturn = new RatingsGetDto
        {
            Id = RatingsToUpdate.Id,
            Name = RatingsToUpdate.Name,
            Score = RatingsToUpdate.Score,
            Comment = RatingsToUpdate.Comment,
            Date = RatingsToUpdate.Date,

        };

        response.Data = RatingsToReturn;
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        var response = new Response();

        var RatingsToDelete = _dataContext.Set<Ratings>()
            .FirstOrDefault(Ratings => Ratings.Id == Id);
        if(RatingsToDelete == null)
        {
            response.AddError("Id", "Rating not found");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }
        _dataContext.Set<Ratings>().Remove(RatingsToDelete);
        _dataContext.SaveChanges();

        response.Data = true;
        return Ok(response);

    }
}