using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static string opcaoUsuario = "";
        static List<Conta> RegistrosConta = new List<Conta>();
        static void Main(string[] args)
        {
            Console.Clear();
            opcaoUsuario = Menu();
            while (opcaoUsuario != "0")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        CriarConta();
                        break;
                    case "2":
                        ListarContas();
                        break;
                    case "3":
                        Depositar();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "9":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção informada é inválida");
                        break;
                }
                opcaoUsuario = Menu();
            }
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("¤------------------------------------------------------------------------------¤");
            Console.WriteLine("|                             LISTA DE CONTAS                                  |");
            Console.WriteLine("|------------------------------------------------------------------------------|");


            if (RegistrosConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < RegistrosConta.Count; i++)
            {
                Conta conta = RegistrosConta[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
            Console.WriteLine();

        }

        private static void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("¤------------------------------------------------------------------------------¤");
            Console.WriteLine("|                              CADATRAR NOVA CONTA                             |");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine();

            Console.WriteLine("Informe o nome do Cliente");
            string nome = Console.ReadLine();

            int tipoPessoa = 0;
            Console.WriteLine("Qual o tipo de conta? 1 para Física ou 2 para Jurídica");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result == 1 || result == 2)
                {
                    tipoPessoa = result;
                }
                else
                {
                    Console.WriteLine("**ATENÇÃO: Tipo de pessoa informado é inválido, cadastro não concluído!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("**ATENÇÃO: Tipo de pessoa informado é inválido, cadastro não concluído!");
            }

            Console.WriteLine("Informe o crédito concedido");
            double credito = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe o saldo inicial");
            double saldo = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome: nome, tipoConta: (TipoConta)tipoPessoa, saldo: saldo, credito: credito);
            RegistrosConta.Add(novaConta);
        }

        private static void Depositar()
        {
            Console.Clear();
            Console.WriteLine("¤------------------------------------------------------------------------------¤");
            Console.WriteLine("|                               NOVO DEPÓSITO                                  |");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            if (verificarContaExiste(indiceConta))
            {
                RegistrosConta[indiceConta].Depositar(valorDeposito);
            }
        }

        private static void Sacar()
        {
            Console.Clear();
            Console.WriteLine("¤------------------------------------------------------------------------------¤");
            Console.WriteLine("|                                FAZER SAQUE                                   |");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            if (verificarContaExiste(indiceConta))
            {
                RegistrosConta[indiceConta].Sacar(valorSaque);
            }
        }

        private static void Transferir()
        {
            Console.Clear();
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            if (verificarContaExiste(indiceContaOrigem) && verificarContaExiste(indiceContaDestino))
            {
                RegistrosConta[indiceContaOrigem].Transferir(valorTransferencia, RegistrosConta[indiceContaDestino]);
            }
        }

        private static bool verificarContaExiste(int numeroConta)
        {
            try
            {
                var res = RegistrosConta[numeroConta];
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Número da conta não existe");
                return false;
            }
        }

        private static string Menu()
        {
            Console.WriteLine("¤------------------------------------------------------------------------------¤");
            Console.WriteLine("|                             MENU DO SISTEMA                                  |");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("| 0 - Sair                                                                     |");
            Console.WriteLine("| 1 - Criar Conta                                                              |");
            Console.WriteLine("| 2 - Listar Contas                                                            |");
            Console.WriteLine("| 3 - Depositar                                                                |");
            Console.WriteLine("| 4 - Sacar                                                                    |");
            Console.WriteLine("| 5 - Transferir                                                               |");
            Console.WriteLine("| 9 - Limpar Tela                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("| Selecione a opção para realizar a operação:                                  |");
            Console.Write("  »» ");
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
