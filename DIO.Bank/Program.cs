using DIO.Bank.Entities;
using DIO.Bank.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> contas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            ListarContas();

            Console.Write("Digite o número da conta de origem: ");
            int numeroContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int numeroContaDestino = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            contas[numeroContaOrigem].Transferir(valorTransferencia, contas[numeroContaDestino]);
        }

        private static void Depositar()
        {
            ListarContas();

            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            contas[numeroConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma conta cadastrada! Por favor, cadastre uma conta para poder sacar.");
                return;
            }

            ListarContas();

            Console.WriteLine();
            Console.Write("Digite o número da conta que deseja fazer o saque: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            contas[numeroConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            int i = 0;
            Console.WriteLine("Lista de contas cadastradas");
            foreach (Conta conta in contas)
            {
                Console.WriteLine($"#{i} - " + conta);
                i++;
            }
            
            Console.WriteLine();

        }

        private static void InserirConta()
        {
            Console.Write("Informe o tipo da conta: ");
            TipoConta tipoConta = Enum.Parse<TipoConta>(Console.ReadLine());

            Console.Write("Informe o saldo inicial da conta: ");
            double saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Informe o crédito inicial da conta: ");
            double credito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Informe o nome do cliente: ");
            string nome = Console.ReadLine();

            contas.Add(new Conta(tipoConta, saldo, credito, nome));

            Console.WriteLine("Conta registrada com sucesso!");
            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
