using System.Diagnostics.Metrics;
using System.Linq;
using System.Xml.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStater.Entities;
using Microsoft.AspNetCore.Mvc;
namespace LearningStarter.Controllers;


[ApiController]
[Route("api/BillingInfo")]
public class BillingInfoController : ControllerBase
{
    private readonly DataContext _dataContext;

    public BillingInfoController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = new Response();

        var data = _dataContext
        .Set<BillingInfo>()
        .Select(BillingInfo => new BillingInfoGetDto
        {
            Id = BillingInfo.Id,
            Name = BillingInfo.Name,
            PhoneNumber = BillingInfo.PhoneNumber,
            Country = BillingInfo.Country,
            State = BillingInfo.State,
            City = BillingInfo.City,
            Zip = BillingInfo.Zip,
            StreetAddress = BillingInfo.StreetAddress,
            SuiteNumber = BillingInfo.SuiteNumber,
            NameOnCard = BillingInfo.NameOnCard,
            CardNumber = BillingInfo.CardNumber,
            ExpirationMonth = BillingInfo.ExpirationMonth,
            ExpirationYear = BillingInfo.ExpirationYear,
            CVV = BillingInfo.CVV,

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

        .Set<BillingInfo>()
        .Select(BillingInfo => new BillingInfoGetDto
        {
            Id = BillingInfo.Id,
            Name = BillingInfo.Name,
            PhoneNumber = BillingInfo.PhoneNumber,
            Country = BillingInfo.Country,
            State = BillingInfo.State,
            City = BillingInfo.City,
            Zip = BillingInfo.Zip,
            StreetAddress = BillingInfo.StreetAddress,
            SuiteNumber = BillingInfo.SuiteNumber,
            NameOnCard = BillingInfo.NameOnCard,
            CardNumber = BillingInfo.CardNumber,
            ExpirationMonth = BillingInfo.ExpirationMonth,
            ExpirationYear = BillingInfo.ExpirationYear,
            CVV = BillingInfo.CVV,


        })
        .FirstOrDefault(BillingInfo => BillingInfo.Id == Id);
        response.Data = data;
        return Ok(response);


    }

    [HttpPost]
    public IActionResult Create([FromBody] BillingInfoCreateDto CreateDto)
    {
        var response = new Response();
        var BillingInfoToCreate = new BillingInfo
        {
            Name = CreateDto.Name,
            PhoneNumber = CreateDto.PhoneNumber,
            Country = CreateDto.Country,
            State = CreateDto.State,
            City = CreateDto.City,
            Zip = CreateDto.Zip,
            StreetAddress = CreateDto.StreetAddress,
            SuiteNumber = CreateDto.SuiteNumber,
            NameOnCard = CreateDto.NameOnCard,
            CardNumber = CreateDto.CardNumber,
            ExpirationMonth = CreateDto.ExpirationMonth,
            ExpirationYear = CreateDto.ExpirationYear,
            CVV = CreateDto.CVV,
        };

        _dataContext.Set<BillingInfo>().Add(BillingInfoToCreate);
        _dataContext.SaveChanges();

        var BillingInfoToReturn = new BillingInfoGetDto
        {
            Id = BillingInfoToCreate.Id,
            Name = BillingInfoToCreate.Name,
            PhoneNumber = BillingInfoToCreate.PhoneNumber,
            Country = BillingInfoToCreate.Country,
            State = BillingInfoToCreate.State,
            City = BillingInfoToCreate.City,
            Zip = BillingInfoToCreate.Zip,
            StreetAddress = BillingInfoToCreate.StreetAddress,
            SuiteNumber = BillingInfoToCreate.SuiteNumber,
            NameOnCard = BillingInfoToCreate.NameOnCard,
            CardNumber = BillingInfoToCreate.CardNumber,
            ExpirationMonth = BillingInfoToCreate.ExpirationMonth,
            ExpirationYear = BillingInfoToCreate.ExpirationYear,
            CVV = BillingInfoToCreate.CVV,
        };

        response.Data = BillingInfoToReturn;

        return Created("", response);

    }

    [HttpPut("{Id}")]
    public IActionResult Update([FromBody] BillingInfoUpdateDto updateDto, int Id)
    {
        var response = new Response();

        var BillingInfoToUpdate = _dataContext.Set<BillingInfo>()
            .FirstOrDefault(BillingInfo => BillingInfo.Id == Id);


        BillingInfoToUpdate.Name = updateDto.Name;
        BillingInfoToUpdate.PhoneNumber = updateDto.PhoneNumber;
        BillingInfoToUpdate.Country = updateDto.Country;
        BillingInfoToUpdate.State = updateDto.State;
        BillingInfoToUpdate.City = updateDto.City;
        BillingInfoToUpdate.Zip = updateDto.Zip;
        BillingInfoToUpdate.StreetAddress = updateDto.StreetAddress;
        BillingInfoToUpdate.SuiteNumber = updateDto.SuiteNumber;
        BillingInfoToUpdate.NameOnCard = updateDto.NameOnCard;
        BillingInfoToUpdate.CardNumber = updateDto.CardNumber;
        BillingInfoToUpdate.ExpirationMonth = updateDto.ExpirationMonth;
        BillingInfoToUpdate.ExpirationYear = updateDto.ExpirationYear;
        BillingInfoToUpdate.CVV = updateDto.CVV;

        _dataContext.SaveChanges();

        var BillingInfoToReturn = new BillingInfoGetDto
        {
            Id = BillingInfoToUpdate.Id,
            Name = BillingInfoToUpdate.Name,
            PhoneNumber = BillingInfoToUpdate.PhoneNumber,
            Country = BillingInfoToUpdate.Country,
            State = BillingInfoToUpdate.State,
            City = BillingInfoToUpdate.City,
            Zip = BillingInfoToUpdate.Zip,
            StreetAddress = BillingInfoToUpdate.StreetAddress,
            SuiteNumber = BillingInfoToUpdate.SuiteNumber,
            NameOnCard = BillingInfoToUpdate.NameOnCard,
            CardNumber = BillingInfoToUpdate.CardNumber,
            ExpirationMonth = BillingInfoToUpdate.ExpirationMonth,
            ExpirationYear = BillingInfoToUpdate.ExpirationYear,
            CVV = BillingInfoToUpdate.CVV,

        };

        response.Data = BillingInfoToReturn;
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        var response = new Response();

        var BillingInfoToDelete = _dataContext.Set<BillingInfo>()
            .FirstOrDefault(BillingInfo => BillingInfo.Id == Id);
        if (BillingInfoToDelete == null)
        {
            response.AddError("Id", "Measurement not found");

        }
        if (response.HasErrors)
        {
            return BadRequest(response);

        }
        _dataContext.Set<BillingInfo>().Remove(BillingInfoToDelete);
        _dataContext.SaveChanges();

        response.Data = true;
        return Ok(response);

    }
}