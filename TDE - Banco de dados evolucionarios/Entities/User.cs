using System.Text.Json.Serialization;

namespace TDE___Banco_de_dados_evolucionarios.Entities;

public class User
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}
