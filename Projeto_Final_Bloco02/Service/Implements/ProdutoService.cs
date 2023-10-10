using Microsoft.EntityFrameworkCore;
using Projeto_Final_Bloco02.Data;
using Projeto_Final_Bloco02.Model;

namespace Projeto_Final_Bloco02.Service.Implements
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
                       .Include(p => p.Categorias)
                       .ToListAsync();
        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _context.Produtos
                                    .Include(p => p.Categorias)
                                    .FirstAsync(i => i.Id == id);

                return Produto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var Produto = await _context.Produtos
                                 .Include(p => p.Categorias)
                                 .Where(p => p.Nome.Contains(nome))
                                 .ToListAsync();
            return Produto;
        }
        public async Task<Produto?> Create(Produto produto)
        {
            if (produto.Categorias is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(produto.Categorias.Id);
            
            if (BuscaCategoria is null)
                    return null;

                produto.Categorias = BuscaCategoria;
            
            }
            //produto.Categorias = produto.Categorias is not null ? _context.Categorias.FirstOrDefault(c => c.Id == produto.Categorias.Id) : null;

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;
        }
        public async Task<Produto?> Update(Produto produto)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(produto.Id);

            if (ProdutoUpdate is null)
            {
                return null;
            }
            if (produto.Categorias is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(produto.Categorias.Id);

                if (BuscaCategoria is null)
                    return null;

                produto.Categorias = BuscaCategoria;
            }

            _context.Entry(ProdutoUpdate).State = EntityState.Detached;
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task Delete(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }
       
    }
}
