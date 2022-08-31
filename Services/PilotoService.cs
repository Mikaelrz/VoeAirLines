using VoeAirLinesSenai.Contexts;
using VoeAirLinesSenai.Entities;
using VoeAirlinesSenai.ViewModels.Piloto;

namespace VoeAirLines.Services
{
    public class PilotoService
    {
        private readonly VoeAirlinesContext _context;

        public PilotoService(VoeAirlinesContext context)
        {
            _context = context;
        }

        public DetalhesPilotoViewModel AdicionarPiloto(AdicionarPilotoViewModel dados)
        {
            var piloto = new Piloto(dados.Nome, dados.Matricula);
            _context.Add(piloto);
            _context.SaveChanges();
            return new DetalhesPilotoViewModel(piloto.Id,piloto.Nome,piloto.Matricula);
        }

        public DetalhesPilotoViewModel? AtualizarPiloto(int id, AtualizarPilotoViewModel dados)
        {
            var piloto = _context.Pilotos.Find(id);
            if (piloto != null)
            {
                if (id == piloto.Id)
                {
                    piloto.Nome = dados.Nome;
                    piloto.Matricula = dados.Matricula;
                    _context.Update(piloto);
                    _context.SaveChanges();
                    return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
                }
            }
            return null;
        }

        public IEnumerable<ListarPilotoViewModel> ListarPilotos()
        {
            return _context.Pilotos.Select(p => new ListarPilotoViewModel(p.Id, p.Nome,p.Matricula));
        }

        public ListarPilotoViewModel? ListarPorId(int id)
        {
            var piloto = _context.Pilotos.Find(id);
            if (piloto != null)
            {
                return new ListarPilotoViewModel(piloto.Id, piloto.Nome,piloto.Matricula);
            }
            return null;
        }

        public DetalhesPilotoViewModel? RemoverPiloto(int id)
        {
            var piloto = _context.Pilotos.Find(id);
            if (piloto != null)
            {
                if (id == piloto.Id)
                {
                    _context.Pilotos.Remove(piloto);
                    _context.SaveChanges();
                    return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome,piloto.Matricula);
                }
            }
            return null;
        }

    }
    



}