using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LivroController : ApiController
    {
        Livro[] livros = new Livro[]
        {
            new Livro { Id = 1, Nome = "Livro 123", Categoria = "Sci-Fi", Preco= 45.60M },
            new Livro { Id = 2, Nome = "Livro 456", Categoria = "Drama", Preco = 23.75M },
            new Livro { Id = 3, Nome = "Livro 789", Categoria = "Ação", Preco = 19.90M }
        };

        public IEnumerable GetAllLivros()
        {
            return livros;
        }

        public Livro GetLivroById(int id)
        {
            var livro = livros.FirstOrDefault((p) => p.Id == id);
            if (livro == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return livro;
        }

        public IEnumerable GetLivrosByCategory(string categoria)
        {
            return livros.Where(
                (p) => string.Equals(p.Categoria, categoria,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}

