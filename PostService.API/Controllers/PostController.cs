using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.API.DTO;
using PostService.API.Models;
using PostService.API.Services;
using System.Runtime.CompilerServices;

namespace PostService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostServices _postServices;

        public PostController(IMapper mapper, IPostServices postServices)
        {
            _mapper = mapper;
            _postServices = postServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _postServices.GetAllAsync();
            if (res.Any())
            {
                var mapRes = _mapper.Map<IEnumerable<ResponsePostDTO>>(res);
                return Ok(mapRes);
            }
            return NoContent();
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetById(string id)
        {
            var res = await _postServices.GetByIdAsync(id);
            if(res is not null)
            {
                var mapRes = _mapper.Map<ResponsePostDTO>(res);
                return Ok(mapRes);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePostDTO createPostDTO)
        {
            var mapInput = _mapper.Map<Post>(createPostDTO);
            var res = await _postServices.AddAsync(mapInput);
            if(res is not null)
            {
                var mapRes = _mapper.Map<ResponsePostDTO>(res);

                // It is better to pass CreatedAtAction
                return CreatedAtAction(nameof(GetById), new { id = mapRes.Id }, mapRes);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePostDTO updatePostDTO)
        {
            var mapInput = _mapper.Map<Post>(updatePostDTO);
            var res = await _postServices.EditAsync(mapInput);
            if(res is not null)
            {
                var mapRes = _mapper.Map<ResponsePostDTO>(res);
                return Ok(mapRes);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var res = await _postServices.DeleteAsync(id);
            if(res is true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
