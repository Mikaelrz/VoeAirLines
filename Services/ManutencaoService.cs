using VoeAirLinesSenai.Contexts;
using VoeAirLinesSenai.Entities;
using VoeAirlinesSenai.ViewModels.Manutencao;

namespace VoeAirlines.Services
{
    public class ManutencaoService
    {
        public readonly VoeAirlinesContext _context;

        public ManutencaoService(VoeAirlinesContext context)
        {
            _context = context;
        }

        public DetalhesManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados)
        {
            var manutencao = new Manutencao(dados.DataHora,dados.TipoManutencao,dados.AeronaveId,dados.Observacao);
            _context.Add(manutencao);
            _context.SaveChanges();

            return new DetalhesManutencaoViewModel(manutencao.Id,manutencao.DataHora,manutencao.Tipo,manutencao.Observacoes,manutencao.AeronaveId);
        }

        public DetalhesManutencaoViewModel? AtualizarManutencao(int id, AtualizarManutencaoViewModel dados)
        {
            var manutencao = _context.Manutencoes.Find(id);
            if (manutencao != null)
            {
                manutencao.DataHora = dados.DataHora;
                manutencao.Tipo = dados.TipoManutencao;
                manutencao.Observacoes = dados.Observacao;
                manutencao.AeronaveId = dados.AeronaveId;                
                _context.Update(manutencao);
                _context.SaveChanges();
                return new DetalhesManutencaoViewModel(manutencao.Id, manutencao.DataHora, 
                manutencao.Tipo, manutencao.Observacoes, manutencao.AeronaveId);

            }
            return null;

        }

        public IEnumerable<ListarManutencaoViewModel> ListarManutencoes()
        {
            return _context.Manutencoes.Select(m => new ListarManutencaoViewModel(m.Id, m.DataHora, m.Tipo, m.Observacoes, m.AeronaveId)) ;
        }

        public ListarManutencaoViewModel? ListarManutencaoPorId(int id)
        {
            var manutencao = _context.Manutencoes.Find(id);
            if (manutencao != null)
            {
                return new ListarManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.Tipo, manutencao.Observacoes, manutencao.AeronaveId);
            }
            return null;
        }

        public IEnumerable<ListarManutencaoViewModel> ListarManutencoesPorAeronave(int aeronaveId)
        {
            return _context.Manutencoes.Where(x => x.AeronaveId == aeronaveId).Select(m => new ListarManutencaoViewModel(m.Id, m.DataHora, m.Tipo, m.Observacoes, m.AeronaveId));
        }

        public DetalhesManutencaoViewModel? RemoverManutencao(int id)
        {
            var manutencao = _context.Manutencoes.Find(id);
            if (manutencao != null)
            {
                if (id == manutencao.Id)
                {
                    _context.Manutencoes.Remove(manutencao);
                    _context.SaveChanges();
                    return new DetalhesManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.Tipo, manutencao.Observacoes, manutencao.AeronaveId);
                }
            }
            return null;
        }
    }
}