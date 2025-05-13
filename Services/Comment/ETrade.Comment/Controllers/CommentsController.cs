﻿using ETrade.Comment.Context;
using ETrade.Comment.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values =_context.UserComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Yorum Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum Güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _context.UserComments.Find(id);
            _context.UserComments.Remove(value);
            _context.SaveChanges();
            return Ok("Yorum Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value= _context.UserComments.Find(id);
            return Ok(value);
        }

        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var value =_context.UserComments.Where(x=>x.ProductId==id).ToList();
            return Ok(value);
        }
    }
}
