﻿using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorksAssessment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentController : ControllerBase
    {
        private readonly IUserCommentService _userCommentService;

        public UserCommentController(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserCommentInputModel comment)
        {
            var Id = await _userCommentService.CreateCommentary(comment);

            return Ok(Id);
        }
    }
}