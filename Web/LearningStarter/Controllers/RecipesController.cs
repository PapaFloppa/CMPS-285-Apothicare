using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using LearningStater.Entities;
using Microsoft.AspNetCore.Mvc;
namespace LearningStarter.Controllers;


[ApiController]
[Route("/api/Recipes")]

public class RecipesController : ControllerBase
{

    private readonly DataContext _dataContext;

    public RecipesController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]

    public IActionResult GetAll()
    {
        var response = new Response();

        var data = _dataContext
        .Set<Recipes>()
        .Select(Recipes => new RecipesGetDto
        {
            Id = Recipes.Id,
            Name = Recipes.Name,
            BodyText = Recipes.BodyText,
            ImageUrl = Recipes.ImageUrl,

            Ingredients = Recipes.Ingredients.Select(x => new RecipeIngredientsGetDto
            {
                Id = x.Ingredients.Id,
                Name = x.Ingredients.Name,
                Description = x.Ingredients.Description,
                IngredientAmount = x.IngredientAmount,
                IngredientMeasurement = x.IngredientMeasurement,

            }).ToList()

        }).ToList();
        response.Data = data;
        return Ok(response);
    }

    [HttpGet("{Id}")]
    public IActionResult GetById(int Id)
    {
        var response = new Response();
        var data = _dataContext

        .Set<Recipes>()
        .Select(recipes => new RecipesGetDto
        {
            Id = recipes.Id,
            Name = recipes.Name,
            BodyText = recipes.BodyText,
            ImageUrl = recipes.ImageUrl,

            Ingredients = recipes.Ingredients.Select(x => new RecipeIngredientsGetDto
            {
                Id = x.Ingredients.Id,
                Name = x.Ingredients.Name,
                Description = x.Ingredients.Description,
                IngredientAmount = x.IngredientAmount,
                IngredientMeasurement = x.IngredientMeasurement,


            }).ToList()

        })
        .FirstOrDefault(recipes => recipes.Id == Id);
        response.Data = data;
        return Ok(response);

    }

    [HttpPost("{RecipeId}/Ingredients/{IngredientId}")]
    public IActionResult AddIngredientsToRecipe(int RecipeId, int IngredientId, [FromQuery] double IngredientAmount, string IngredientMeasurement)
    {
        var response = new Response();

        var recipes = _dataContext.Set<Recipes>()
            .FirstOrDefault(x => x.Id == RecipeId);

        var Ingredients = _dataContext.Set<Ingredients>()
            .FirstOrDefault(x => x.Id == IngredientId);

        var RecipeIngredients = new RecipeIngredients
        {
            Recipes = recipes,
            Ingredients = Ingredients,

        };
        _dataContext.Set<RecipeIngredients>().Add(RecipeIngredients);
        _dataContext.SaveChanges();

        response.Data = new RecipesGetDto
        {
            Id = recipes.Id,
            Name = recipes.Name,
            ImageUrl = recipes.ImageUrl,
            BodyText = recipes.BodyText,

            Ingredients = recipes.Ingredients.Select(x => new RecipeIngredientsGetDto
            {
                Id = x.Ingredients.Id,
                Name = x.Ingredients.Name,
                Description = x.Ingredients.Description,
                IngredientAmount = x.IngredientAmount,
                IngredientMeasurement = x.IngredientMeasurement,


            }).ToList()

        };

        return Ok(response);
    }
        [HttpPost]
    public IActionResult Create([FromBody] RecipesCreateDto createDto)
    { 
        var response = new Response();

        if (string.IsNullOrEmpty(createDto.Name))
        {
            response.AddError(nameof(createDto.Name), "Name must not be empty");

        }


        if (string.IsNullOrEmpty(createDto.BodyText))
        {
            response.AddError(nameof(createDto.BodyText), "You must have a body text");

        }

        if (response.HasErrors)
        {
            return BadRequest(response);

        }

        var RecipesToCreate = new Recipes
        {
            Name = createDto.Name,
            ImageUrl = createDto.ImageUrl,
            BodyText = createDto.BodyText,
        };

        _dataContext.Set<Recipes>().Add(RecipesToCreate);
        _dataContext.SaveChanges();

        var RecipesToReturn = new RecipesGetDto
        {
            Name = RecipesToCreate.Name,
            ImageUrl = createDto.ImageUrl,
            BodyText = RecipesToCreate.BodyText,
           
        };

        response.Data = RecipesToReturn;

        return Created("", response);
    }

    [HttpPut("{Id}")]

    public IActionResult Update([FromBody] RecipesUpdateDto updateDto, int Id)
    {
        var response = new Response();

        var RecipesToUpdate = _dataContext.Set<Recipes>()
            .FirstOrDefault(Recipes => Recipes.Id == Id);

        if (RecipesToUpdate == null)
        {
            response.AddError("Id", "Recipe not found");
        }
        if (string.IsNullOrEmpty(updateDto.Name))
        {
            response.AddError(nameof(updateDto.Name), "Name must not be empty");

        }


        if (string.IsNullOrEmpty(updateDto.BodyText))
        {
            response.AddError(nameof(updateDto.BodyText), "You must have a body text");

        }

        if (response.HasErrors)
        {
            return BadRequest(response);
        }
            RecipesToUpdate.Name = updateDto.Name;
            RecipesToUpdate.ImageUrl = updateDto.ImageUrl;
            RecipesToUpdate.Name = updateDto.Name;
            RecipesToUpdate.BodyText = updateDto.BodyText;

        _dataContext.SaveChanges();

        var RecipesToReturn = new RecipesGetDto
        {
            Id = RecipesToUpdate.Id,
            Name = RecipesToUpdate.Name,
            ImageUrl = RecipesToUpdate.ImageUrl,
            BodyText = RecipesToUpdate.BodyText,
            
        };
        response.Data = RecipesToReturn;
        return Ok(response);
    }
    [HttpDelete("{Id}")]

    public IActionResult Delete(int Id)
    {
        var response = new Response();
        var RecipesToDelete = _dataContext.Set<Recipes>()
            .FirstOrDefault(Recipes => Recipes.Id == Id);

        if (RecipesToDelete == null)
        {
            response.AddError("Id", "Recipe not found");
        }
        if (response.HasErrors)
        {
            return BadRequest(response);
        }
        _dataContext.Set<Recipes>().Remove(RecipesToDelete);
        _dataContext.SaveChanges();

        response.Data = true;
        return Ok(response);
    }


}

