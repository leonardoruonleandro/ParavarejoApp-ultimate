using System;

namespace ParavarejoApp1.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public double Value { get; set; }

        public double CalculatedValue { get; set; }

        public LucroRealVariavel Variavel { get; set; }

    }

    public enum LucroRealVariavel
    {
        PreçoDeCompra,
        CreditoICMS,
        CreditoPISCofins,
        AcrescimoIPI,
        PreçoDeCusto,
        PreçoDeVenda,
        DebitoICMS,
        DebitoPISCofins,
        LucroBruto
    }
}