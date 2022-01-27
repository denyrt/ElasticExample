using ElasticExample.BusinessLogic.Commands.Articles;
using ElasticExample.BusinessLogic.Queries.Articles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElasticExample.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] Guid id)
        {
            var query = new GetArticleQuery { Id = id };
            var response = await _mediator.Send(query, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles() 
        { 
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand command)
        {
            var response = await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticle()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteArticles()
        {
            return Ok();
        }
    }
}