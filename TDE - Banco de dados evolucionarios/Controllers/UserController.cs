using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDE___Banco_de_dados_evolucionarios.DataBase;
using TDE___Banco_de_dados_evolucionarios.Entities;

namespace TDE___Banco_de_dados_evolucionarios.Controllers;
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return _context.Users.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user =_context.Users.FirstOrDefault(u => u.Id == id);
        if(user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest();
        }

        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.Nome = user.Nome;
        existingUser.Descricao = user.Descricao;

        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}
