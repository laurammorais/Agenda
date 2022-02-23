
namespace ConsoleApp8
{
    public class Telefone
    {
        public string Numero { get; set; }
        public int DDD { get; set; }
        public string Tipo { get; set; }
        public Telefone Proximo { get; set; }
        public Telefone(string numero, int ddd, string tipo)
        {
            Numero = numero;
            DDD = ddd;
            Tipo = tipo;
            Proximo = null;
        }

        public override string ToString()
        {
            return $"{Tipo}: ({DDD}) {Numero}";
        }
    }
}

