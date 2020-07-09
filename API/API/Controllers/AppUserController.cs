using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data.Interfaces;
using API.Dtos.AppUserDtos;
using API.Extentions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepo _repo;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppUsers([FromQuery] AppUserParams userParams)
        {

            var users = await _repo.GetAppUsers(userParams);

            var usersToReturn = _mapper.Map<IEnumerable<AppUserForListDto>>(users);

            Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            var user = await _repo.GetAppUser(id);

            var userToReturn = _mapper.Map<AppUserForDetailedDto>(user);

            return Ok(userToReturn);

        }

    }
}
