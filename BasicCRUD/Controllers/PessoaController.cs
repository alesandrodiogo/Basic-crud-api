using BasicCRUD.Context;
using BasicCRUD.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUD.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PessoaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("create")]
   public IActionResult Create(Pessoa pessoa)
    {
        _context.Add(pessoa);
        _context.SaveChanges();

        return Created();
    }

    [HttpGet("read")]
    public IActionResult GetAll()
    {
       var all = _context.Pessoa.ToList();

        return Ok(all);
    }

    [HttpPut("update/{id}")]
    public IActionResult Update(int id, Pessoa pessoa)
    {
        var find = _context.Pessoa.Find(id);

        if (find == null) return NotFound();

        find.Nome = pessoa.Nome;
        find.Idade = pessoa.Idade;
        find.Altura = pessoa.Altura;
        find.Endereco = pessoa.Endereco;

        _context.SaveChanges();

        return Ok(find);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var find = _context.Pessoa.Find(id);
        if (find == null) return NotFound();

        _context.Remove(find);
        _context.SaveChanges();

        return Ok(find);
    }
}
