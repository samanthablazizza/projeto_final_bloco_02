using Projeto_Final_Bloco02.Model;

namespace Projeto_Final_Bloco02.Service
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();

        Task<Categoria?> GetById(long id);

        Task<IEnumerable<Categoria>> GetByTipo(string tipo);

        Task<Categoria?> Create(Categoria Categoria);

        Task<Categoria?> Update(Categoria Categoria);

        Task Delete(Categoria Categoria);
    }
}
