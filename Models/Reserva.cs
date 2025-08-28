using System.Runtime.CompilerServices;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            if (Suite == null)
            {
                throw new InvalidOperationException("Suite precisa ser cadastrada antes de cadastrar hospedes.");
            }
            else if (hospedes.Count > Suite.Capacidade)
            {
                throw new ArgumentOutOfRangeException(nameof(hospedes), "O número de hospedes que desejam se hospedar excede a capacidade da suite.");
            }
            if (hospedes == null || hospedes.Count == 0)
            {
                throw new ArgumentException("A lista de hóspedes não pode ser nula ou vazia.");
            }
            else
            {
                Hospedes = hospedes;
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 00;
        }

        public decimal CalcularValorDiaria()
        {

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor -= valor / 10;
            }

            return valor;
        }
    }
}