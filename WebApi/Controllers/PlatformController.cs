using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;

        public IMapper _mapper { get; }

        public PlatformController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("[Action]")]
        public ActionResult<List<PlatformReadDto>> GetAllPlatforms()
        {
            var platforms = _platformRepo.GetAllPlatforms();
            var result = _mapper.Map<List<PlatformReadDto>>(platforms);

            return Ok(result);
        }

        [HttpGet]
        [Route("[Action]")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platform = _platformRepo.GetPlatformById(id);
            var result = _mapper.Map<PlatformReadDto>(platform);

            return Ok(result);
        }

        [HttpPost]
        [Route("[Action]")]
        public ActionResult<PlatformReadDto> AddPlatform(PlatformCreateDto platformCreateDto)
        {
            var platform = _mapper.Map<Platform>(platformCreateDto);

            _platformRepo.CreatePlatform(platform);
            _platformRepo.SaveChanges();

            var result = _mapper.Map<PlatformReadDto>(platform);

            return Ok(result);
        }



    }
}
