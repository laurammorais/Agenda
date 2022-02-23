using System;
using static ConsoleApp8.Lista_Contato;

namespace ConsoleApp8
{

    public class Program
    {
        static void Main(string[] args)
        {
            ListaContato contatos = new ListaContato();
            int opcao = 0;

            while (opcao != 6)
            {
                Console.WriteLine("-----MENU-----");
                Console.WriteLine("1-Inserir um Contato");
                Console.WriteLine("2-Localizar um Contato");
                Console.WriteLine("3-Excluir um Contato");
                Console.WriteLine("4-Editar um Contato");
                Console.WriteLine("5-Imprimir os Contatos");
                Console.WriteLine("6-Sair");
                opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Digite a quantidade de telefones que deseja adicionar: ");
                    int qtdTelefone = int.Parse(Console.ReadLine());

                    ListaTelefones telefones = new ListaTelefones();

                    for (int i = 0; i < qtdTelefone; i++)
                    {
                        Console.Write("\n(tipo) telefone: ");
                        string tipo = Console.ReadLine();
                        Console.Write("(ddd) telefone: ");
                        int ddd = int.Parse(Console.ReadLine());
                        Console.Write("(numero) telefone: ");
                        string numero = Console.ReadLine();
                        Telefone telefone = new Telefone(tipo, ddd, numero);
                        telefones.Inserir(telefone);
                    }

                    Contato aux = new Contato(nome, email, telefones);

                    if (contatos.Cabeca == null)
                    {
                        contatos.Cabeca = contatos.Cauda = aux;
                    }
                    else
                    {
                        Contato aux1, aux2;
                        aux1 = aux2 = contatos.Cabeca;
                        do
                        {
                            // UM ITEM NA LISTA
                            if (contatos.Cabeca == contatos.Cauda)
                            {
                                // NOVO CONTATO EH MAIOR -> COLOCA NA FRENTE
                                if (aux.Nome.CompareTo(contatos.Cauda.Nome) > 0)
                                {
                                    contatos.Cauda.Proximo = aux;
                                    contatos.Cauda = aux;
                                    break;
                                }
                                // NOVO CONTATO EH MENOR OU IGUAL -> COLOCA ATRAS
                                else
                                {
                                    aux.Proximo = contatos.Cabeca;
                                    contatos.Cabeca = aux;
                                    break;
                                }
                            }
                            // MAIS DE UM ITEM
                            else
                            {
                                // NOVO EH MENOR QUE O PROXIMO -> COLOCA ATRAS
                                if (aux.Nome.CompareTo(aux1.Nome) < 0)
                                {
                                    aux.Proximo = aux;
                                    contatos.Cabeca = aux;
                                    break;
                                }
                                // NOVO EH MAIOR OU IGUAL -> COLOCA PRA FRENTE
                                else if (aux.Nome.CompareTo(aux1.Nome) > 0 || aux.Nome.CompareTo(aux1.Nome) == 0)
                                {
                                    aux1 = aux1.Proximo;
                                    //
                                    if (aux1 == null)
                                    {
                                        contatos.Cauda.Proximo = aux;
                                        contatos.Cauda = aux;
                                        break;
                                    }
                                    else if (aux.Nome.CompareTo(aux1.Nome) < 0)
                                    {
                                        aux2.Proximo = aux;
                                        aux.Proximo = aux1;
                                        break;
                                    }
                                }
                            }

                            aux2 = aux1;
                        } while (aux1 != null);
                    }
                }
                else if (opcao == 2)
                {
                    Console.Write("Digite o nome do Contato: ");
                    string nome = Console.ReadLine();

                    Contato contato = null;
                    bool encontrou = false;

                    if (contatos.Cabeca != null)
                    {
                        Contato aux = contatos.Cabeca;
                        do
                        {
                            if (aux.Nome == nome)
                            {
                                contato = aux;
                                encontrou = true;
                            }
                            aux = aux.Proximo;
                        } while (aux != null && !encontrou);
                    }

                    if (encontrou)
                    {
                        Console.WriteLine(contato);
                    }
                    else
                    {
                        Console.WriteLine("Contato não localizado.");
                    }
                }
                else if (opcao == 3)
                {
                    Console.Write("Digite o nome do Contato para remover: ");
                    string nome = Console.ReadLine();

                    Contato contato = null;
                    bool encontrou = false;

                    if (contatos.Cabeca != null)
                    {
                        Contato aux = contatos.Cabeca;
                        do
                        {
                            if (aux.Nome == nome)
                            {
                                contato = aux;
                                encontrou = true;
                            }
                            aux = aux.Proximo;
                        } while (aux != null && !encontrou);
                    }

                    if (encontrou)
                    {
                        Contato aux1;
                        aux1 = contatos.Cabeca;

                        if (contatos.Cabeca == contatos.Cauda)
                        {
                            contatos.Cabeca = contatos.Cauda = null;
                        }
                        else
                        {
                            do
                            {
                                contato.Proximo = aux1;
                                contatos.Cabeca.Proximo = aux1;
                            } while (contatos.Cauda.Proximo != null);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Contato não localizado.");
                    }
                }
                else if (opcao == 4)
                {
                    Console.Write("Digite o nome do Contato para editar: ");
                    string nome = Console.ReadLine();

                    Contato contato = null;
                    bool encontrou = false;

                    if (contatos.Cabeca != null)
                    {
                        Contato aux = contatos.Cabeca;
                        do
                        {
                            if (aux.Nome == nome)
                            {
                                contato = aux;
                                encontrou = true;
                            }
                            aux = aux.Proximo;
                        } while (aux != null && !encontrou);
                    }

                    if (encontrou)
                    {
                        Console.WriteLine("\nQual informacao deste contato deseja editar?");
                        Console.WriteLine("1-Nome");
                        Console.WriteLine("2-Email");
                        Console.WriteLine("3-Telefones");
                        Console.WriteLine("4-Sair");
                        int opcaoDoContato = int.Parse(Console.ReadLine());
                        if (opcaoDoContato == 1)
                        {
                            Console.Write("Novo nome: ");
                            string novoNome = Console.ReadLine();
                            contato.Nome = novoNome;
                        }
                        else if (opcaoDoContato == 2)
                        {
                            Console.Write("Novo email: ");
                            string novoEmail = Console.ReadLine();
                            contato.Email = novoEmail;
                        }
                        else if (opcaoDoContato == 3)
                        {
                            Telefone aux = contato.Telefones.Cabeca;
                            int indice = 1;
                            do
                            {
                                if (aux.Proximo == null)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.Write($"\n(tipo) telefone {indice}: ");
                                    aux.Tipo = Console.ReadLine();
                                    Console.Write($"(ddd) telefone {indice}: ");
                                    aux.DDD = int.Parse(Console.ReadLine());
                                    Console.Write($"(numero) telefone {indice}: ");
                                    aux.Numero = Console.ReadLine();
                                    indice++;
                                }
                                aux = aux.Proximo;
                            } while (aux != null);
                        }
                        else if (opcaoDoContato != 4)
                        {
                            Console.WriteLine("Opção inválida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Contato não localizado.");
                    }
                }
                else if (opcao == 5)
                {
                    Console.WriteLine(contatos);
                }
                else if (opcao == 6)
                {
                    Console.WriteLine("Finalizando o programa...");
                }
                else
                {
                    Console.WriteLine("Digite uma opção válida.");
                }
            }
        }
    }
}
    

