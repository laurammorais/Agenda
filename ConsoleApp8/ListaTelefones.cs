using System;

namespace ConsoleApp8
{
    public class ListaTelefones
    {
        public Telefone Cabeca { get; set; }
        public Telefone Cauda { get; set; }

        public void Inserir(Telefone aux)
        {
            if (Cabeca == null && Cauda == null)
            {
                Cabeca = Cauda = aux;
            }
            else
            {
                Cauda.Proximo = aux;
                Cauda = aux;
            }
        }

        public override string ToString()
        {
            string texto = "";
            if (Cabeca == null && Cauda == null)
            {
                Console.WriteLine("Lista vazia.");
            }
            else
            {
                Telefone aux = Cabeca;
                do
                {
                    if (aux.Proximo == null)
                    {
                        texto += $"{aux}";
                    }
                    else
                    {
                        texto += $"{aux} | ";
                    }
                    aux = aux.Proximo;
                } while (aux != null);
            }
            return texto;
        }
    }
}
