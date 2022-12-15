//Escreva uma classe em que cada objeto representa um vôo que acontece em determinada data e em 
//determinado horário. Cada vôo possui no máximo 100 passageiros, e a classe permite controlar a 
//ocupação das cadeiras (considere as cadeiras um numero inteiro de 0 a 99). A classe deve ter os 
//seguintes métodos (com o nome exato):

//construtor(Voo): configura os dados do vôo: aeronave, número do vôo, data;
//AssentoDisponivel: retorna se o número da cadeira está ocupada.
//OcuparAssento: ocupa determinada cadeira do vôo e retorna se a operação foi bem sucedida
//QuantidadeVagasDisponivel: retorna o número de cadeiras vagas disponíveis (não ocupadas) no vôo
//ExibirInformacoesVoo: Imprime no console o conteúdo: “Aeronave nomeAeronave registrada sob voo de número 99 para o dia e hora 05/05/2005 01:01:0001”
//ProximoLivre: retorna o número da próxima cadeira livre


using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class Voo
{
    private string ModeloAeronave;
    private int numeroVoo;
    private DateTime DataVoo;
    private TimeSpan HorarioVoo;
    private int numeroPassageiros;
    private int assentosDisponveis;
    private int proximoAssentoDisponivel;
    List<bool> assentos = new List<bool>(new bool[99]);

    public Voo(String Aeronave, int numeroVoo, DateTime dataVoo)
    {
        this.ModeloAeronave = Aeronave;
        this.numeroVoo = numeroVoo;
        this.DataVoo = dataVoo.Date;
        this.HorarioVoo = dataVoo.TimeOfDay;
    }

    public bool AssentoDisponivel(int numeroAssento)
    {
        if (assentos[numeroAssento])
        {
            Console.WriteLine("O assento está ocupado.");
            return true;
        }
        Console.WriteLine("O assento está vago.");
        return false;
    }

    public void OcuparAssento(int numeroAssento)
    {
        Console.WriteLine("Operação bem sucedida, assento marcado!");
        var input = Console.ReadLine();
        if (!AssentoDisponivel(numeroAssento))
        {
            this.assentos[numeroAssento] = true;
            Console.WriteLine("Operação bem sucedida, assento marcado!");
        } else
        {
            Console.WriteLine("O assento selecionado encontra-se reservado, tente outro assento.");
        }
    }

    public int QuantidadeVagasDisponiveis()
    {
        foreach(bool assento in assentos)
        {
            if (!assento)
            {
                this.assentosDisponveis++;
            }
   
        }
        Console.WriteLine($"Este voo possui {this.assentosDisponveis} assentos disponiveis.");
        return this.assentosDisponveis;
    }

    public void ExibirInformacoesVoo()
    {
        Console.WriteLine($"Aeronave {this.ModeloAeronave} registrada sob voo de número {this.numeroVoo} para o dia e hora {this.DataVoo} {this.HorarioVoo}");
    }

    public int ProximoLivre()
    {
        this.proximoAssentoDisponivel = assentos.FindIndex(v => v == false);
        if(proximoAssentoDisponivel != -1)
        {
            Console.WriteLine($"O proximo assento disponivel é o {this.proximoAssentoDisponivel}");
            return this.proximoAssentoDisponivel;
        }
        Console.WriteLine("Não existem mais assentos disponiveis.");
        return 0;

    }

}


class Program
{

    public static void Main(string[] args)
    {

        Voo voo = new Voo("Boeing 737-NG", 5522,  DateTime.Now);
        voo.ExibirInformacoesVoo();
        voo.OcuparAssento(0);
        voo.OcuparAssento(1);
        voo.OcuparAssento(3);
        voo.OcuparAssento(20);
        voo.OcuparAssento(4);
        voo.OcuparAssento(1);
        voo.ProximoLivre();
        voo.AssentoDisponivel(2);
        voo.QuantidadeVagasDisponiveis();

    }
}