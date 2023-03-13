using IBIDConsoleApp.Model;
using System;

namespace IBIDConsoleApp
{
    class Program
    {
        static void Main(string[] args) 
        {
            //Obter dados

            Console.WriteLine("1 - Buscando Frete...");
            Frete frete = Services.ServiceFrete.Consultar("CIF");
            if (frete == null ) 
            {
                Console.WriteLine("O código CIF não foi encontrado");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"O código CIF {frete.descricaoPortugues} foi localizado." );
                Console.ReadKey();
            }

            Console.WriteLine("2 - Buscando Frete...");
            frete = Services.ServiceFrete.Consultar("CON");
            if (frete == null)
            {
                Console.WriteLine("O código CON não foi encontrado");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"O código CON {frete.descricaoPortugues} foi localizado.");
                Console.ReadKey();
            }


            Console.Clear();
            Console.WriteLine("2 - CRIANDO UM FRETE NOVO");
            frete = new Frete { ativo = true, 
                codigoFrete = "CON", 
                descricaoPortugues = "CON TESTE", 
                descricaoEspanhol = "",
                descricaoIngles = "", 
                necessitaTransportadora = true, 
                permiteValor = 1
            };

            var retornoFrete = Services.ServiceFrete.Adicionar(frete);
            if (retornoFrete != null)
            {
                Console.WriteLine($"O código CON inserido com sucesso id: {retornoFrete.id}");
                Console.ReadKey();
            }

        }
    }
}
