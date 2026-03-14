using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;

        public WalksController(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}
