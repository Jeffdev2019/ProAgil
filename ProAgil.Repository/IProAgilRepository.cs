using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        #region GERAL
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();
        #endregion

        #region EVENTOS
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes);
        #endregion

        #region PALESTRANTE
        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string PalestrantesNome, bool includeEventos);
        Task<Palestrante> GetAllPalestrantesAsync(int PalestrantesId, bool includeEventos);
        #endregion

    }
}