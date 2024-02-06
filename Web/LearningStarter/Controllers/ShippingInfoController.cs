using System.Diagnostics.Metrics;
using System.Linq;
using System.Xml.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStater.Entities;
using Microsoft.AspNetCore.Mvc;
namespace LearningStarter.Controllers;


[ApiController]
[Route("api/ShippingInfo")]
public class ShippingInfoController : ControllerBase
{
    private readonly DataContext _dataContext;

    public ShippingInfoController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = new Response();

        var data = _dataContext
        .Set<ShippingInfo>()
        .Select(ShippingInfo => new ShippingInfoGetDto
        {
            Id = ShippingInfo.Id,
            Name = ShippingInfo.Name,
            PhoneNumber = ShippingInfo.PhoneNumber,
            Country = ShippingInfo.Country,
            State = ShippingInfo.State,
            City = ShippingInfo.City,
            Zip = ShippingInfo.Zip,
            StreetAddress = ShippingInfo.StreetAddress,
            SuiteNumber = ShippingInfo.SuiteNumber,


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

        .Set<ShippingInfo>()
        .Select(ShippingInfo => new ShippingInfoGetDto
        {
            Id = ShippingInfo.Id,
            Name = ShippingInfo.Name,
            PhoneNumber = ShippingInfo.PhoneNumber,
            Country = ShippingInfo.Country,
            State = ShippingInfo.State,
            City = ShippingInfo.City,
            Zip = ShippingInfo.Zip,
            StreetAddress = ShippingInfo.StreetAddress,
            SuiteNumber = ShippingInfo.SuiteNumber,



        })
        .FirstOrDefault(ShippingInfo => ShippingInfo.Id == Id);
        response.Data = data;
        return Ok(response);


    }

    [HttpPost]
    public IActionResult Create([FromBody] ShippingInfoCreateDto CreateDto)
    {
        var response = new Response();
        var ShippingInfoToCreate = new ShippingInfo
        {
            Name = CreateDto.Name,
            PhoneNumber = CreateDto.PhoneNumber,
            Country = CreateDto.Country,
            State = CreateDto.State,
            City = CreateDto.City,
            Zip = CreateDto.Zip,
            StreetAddress = CreateDto.StreetAddress,
            SuiteNumber = CreateDto.SuiteNumber,

        };

        _dataContext.Set<ShippingInfo>().Add(ShippingInfoToCreate);
        _dataContext.SaveChanges();

        var ShippingInfoToReturn = new ShippingInfoGetDto
        {
            Id = ShippingInfoToCreate.Id,
            Name = ShippingInfoToCreate.Name,
            PhoneNumber = ShippingInfoToCreate.PhoneNumber,
            Country = ShippingInfoToCreate.Country,
            State = ShippingInfoToCreate.State,
            City = ShippingInfoToCreate.City,
            Zip = ShippingInfoToCreate.Zip,
            StreetAddress = ShippingInfoToCreate.StreetAddress,
            SuiteNumber = ShippingInfoToCreate.SuiteNumber,

        };

        response.Data = ShippingInfoToReturn;

        return Created("", response);

    }

    [HttpPut("{Id}")]
    public IActionResult Update([FromBody] ShippingInfoUpdateDto updateDto, int Id)
    {
        var response = new Response();

        var ShippingInfoToUpdate = _dataContext.Set<ShippingInfo>()
            .FirstOrDefault(ShippingInfo => ShippingInfo.Id == Id);


        ShippingInfoToUpdate.Name = updateDto.Name;
        ShippingInfoToUpdate.PhoneNumber = updateDto.PhoneNumber;
        ShippingInfoToUpdate.Country = updateDto.Country;
        ShippingInfoToUpdate.State = updateDto.State;
        ShippingInfoToUpdate.City = updateDto.City;
        ShippingInfoToUpdate.Zip = updateDto.Zip;
        ShippingInfoToUpdate.StreetAddress = updateDto.StreetAddress;
        ShippingInfoToUpdate.SuiteNumber = updateDto.SuiteNumber;


        _dataContext.SaveChanges();

        var ShippingInfoToReturn = new ShippingInfoGetDto
        {
            Id = ShippingInfoToUpdate.Id,
            Name = ShippingInfoToUpdate.Name,
            PhoneNumber = ShippingInfoToUpdate.PhoneNumber,
            Country = ShippingInfoToUpdate.Country,
            State = ShippingInfoToUpdate.State,
            City = ShippingInfoToUpdate.City,
            Zip = ShippingInfoToUpdate.Zip,
            StreetAddress = ShippingInfoToUpdate.StreetAddress,
            SuiteNumber = ShippingInfoToUpdate.SuiteNumber,

        };

        response.Data = ShippingInfoToReturn;
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        var response = new Response();

        var ShippingInfoToDelete = _dataContext.Set<ShippingInfo>()
            .FirstOrDefault(ShippingInfo => ShippingInfo.Id == Id);
        if (ShippingInfoToDelete == null)
        {
            response.AddError("Id", "Measurement not found");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }
        _dataContext.Set<ShippingInfo>().Remove(ShippingInfoToDelete);
        _dataContext.SaveChanges();

        response.Data = true;
        return Ok(response);

    }
}