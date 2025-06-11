using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Tutorial Endpoints")]
public class TutorialsController(
    ITutorialCommandService tutorialCommandService,
    ITutorialQueryService tutorialQueryService
) : ControllerBase
{
    [HttpGet("{tutorialId:int}")]
    [SwaggerOperation(
        Summary = "Gets a tutorial by its ID",
        Description = "Get a tutorial by given tutorial ID.",
        OperationId = "GetTutorialById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tutorial found", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Tutorial not found")]
    public async Task<IActionResult> GetTutorialById([FromRoute] int tutorialId)
    {
        {
            var getTutorialByIdQuery = new GetTutorialByIdQuery(tutorialId);
            var tutorial = await tutorialQueryService.Handle(getTutorialByIdQuery);
            if (tutorial is null) return NotFound();
            var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
            return Ok(tutorialResource);
        }
    }
    
    [HttpPost]
    [SwaggerOperation( 
        Summary = "Creates a new tutorial",
        Description = "Creates a new tutorial with the provided details.",
        OperationId = "CreateTutorial")]
    [SwaggerResponse(StatusCodes.Status201Created, "Tutorial created successfully", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid tutorial data")]
    public async Task<IActionResult> CreateTutorial([FromBody] CreateTutorialResource resource)
    {
        var createTutorialCommand = CreateTutorialCommandFromResourceAssembler.ToCommandFromResource(resource);
        var tutorial = await tutorialCommandService.Handle(createTutorialCommand);
        if (tutorial is null) return BadRequest("Tutorial could not be created.");
        var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), 
            new { tutorialId = tutorial.Id }, tutorialResource);
    }
    
    [HttpGet] 
    [SwaggerOperation( 
        Summary = "Gets all tutorials",
        Description = "Retrieves a list of all available tutorials.",
        OperationId = "GetAllTutorials")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of tutorials retrieved successfully", typeof(IEnumerable<TutorialResource>))]
    public async Task<IActionResult> GetAllTutorials()
    {
        var tutorials = await tutorialQueryService.Handle(new GetAllTutorialsQuery());
        var resources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPost("{tutorialId:int}/videos")]
    [SwaggerOperation( 
        Summary = "Adds a video to a tutorial",
        Description = "Adds a video asset to the specified tutorial.",
        OperationId = "AddVideoToTutorial")]
    [SwaggerResponse(StatusCodes.Status201Created, "Video added to tutorial successfully", typeof(TutorialResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid video data or tutorial not found")]
    public async Task<IActionResult> AddVideoToTutorial([FromRoute] int tutorialId, [FromBody] AddVideoAssetToTutorialResource resource)
    {
        var addVideoToTutorialCommand = AddVideoAssetToTutorialCommandFromResourceAssembler.ToCommandFromResource(resource, tutorialId);
        var tutorial = await tutorialCommandService.Handle(addVideoToTutorialCommand);
        if (tutorial is null) return BadRequest("The video could not be added to the tutorial.");
        var tutorialResource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialById), 
            new { tutorialId = tutorial.Id }, tutorialResource);
    }
    
}