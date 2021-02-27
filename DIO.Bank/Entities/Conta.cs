using DIO.Bank.Entities.Enums;
using System;
using System.Globalization;

namespace DIO.Bank.Entities
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(Saldo - valorSaque < (Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo.ToString("F2", CultureInfo.InvariantCulture));

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo.ToString("F2", CultureInfo.InvariantCulture));
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) 
        {
            if(Sacar(valorTransferencia)) {
                contaDestino.Depositar(valorTransferencia); 
            }
        }

        public override string ToString()
        {
            return $"TipoConta: {TipoConta} " +
                   $"| Nome: {Nome} " +
                   $"| Saldo: {Saldo.ToString("F2", CultureInfo.InvariantCulture)} " +
                   $"| Crédito: {Credito.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
