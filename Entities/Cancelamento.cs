namespace VoeAirLinesSenai.Entities;

public class Cancelamento
{

public Cancelamento(string motivo, DateTime dataHoraNotificacao, int vooId)
{
    Motivo = motivo;
    DataHoraNotificacao = dataHoraNotificacao;
    VooId = vooId;
}
public int Id { get; set; }

public string Motivo { get; set; }

public DateTime DataHoraNotificacao { get; set; }

public int VooId { get; set; }

public Voo voo { get; set; } = null!;

}
