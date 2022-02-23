using System;

namespace ConsoleApp8
{
    internal class Lista_Contato
    {
        public class ListaContato
        {
            public Contato Cabeca { get; set; }
            public Contato Cauda { get; set; }

            public override string ToString()
            {
                string texto = "";

                if (Cabeca == null && Cauda == null)
                {
                    Console.WriteLine("Lista vazia.");
                }
                else
                {
                    Contato aux = Cabeca;
                    do
                    {
                        if (aux.Proximo == null)
                        {
                            texto += $"{aux}\n";
                        }
                        else
                        {
                            texto += $"{aux}\n";
                        }
                        aux = aux.Proximo;
                    } while (aux != null);
                }
                return texto;
            }
        }
    }
}
