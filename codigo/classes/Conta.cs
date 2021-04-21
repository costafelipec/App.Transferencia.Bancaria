using System;

namespace bank
{
    public class Conta
    {
        private string Nome { get; set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(string nome, TipoConta tipoConta, double saldo, double credito)
        {
            this.Nome = nome;
            this.TipoConta = tipoConta;            
            if (validarValor(credito) && validarValor(credito)){
              this.Saldo = saldo;              
              this.Credito = credito;      
            }
            
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine($"Seu saldo é insuficiente para completar a operação, seu saldo é de {this.Saldo}");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine($"Seu novo saldo é {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            if (validarValor(valorDeposito))
            {
                this.Saldo += valorDeposito;
                Console.WriteLine($"Seu novo saldo é {this.Saldo}");
            }            
        }

        public void Transferir(double valorTransferencia, Conta contaDepositar)
        {            
            if (this.Sacar(valorTransferencia))
            {
                contaDepositar.Depositar(valorTransferencia);
            }
        }

        public bool validarValor(double valor)
        {
            if (valor >= 0)
            {
                return true;
            }
            Console.WriteLine($"OPS! Não é permitido depósito com valor negativo ({valor}), por informe o valor correto!");
            return false;
        }

        public override string ToString()
        {
            string dadosConta = "";            
            dadosConta += "Nome: " + this.Nome + " | ";
            dadosConta += "Tipo da Conta: " + this.TipoConta + " | ";
            dadosConta += "Saldo: " + this.Saldo + " | ";
            dadosConta += "Crédito: " + this.Credito;
            return dadosConta;
        }
    }
}