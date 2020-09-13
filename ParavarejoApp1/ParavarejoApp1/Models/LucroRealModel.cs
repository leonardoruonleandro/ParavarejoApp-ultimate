using System;
using System.Collections.Generic;
using System.Text;

namespace ParavarejoApp1.Models
{
    public class LucroRealModel
    {

        public void Calculate(List<Item> items)
        {

            Item preçoDeCompra = null;
            Item creditoICMS = null;
            Item creditoPISCofins = null;
            Item acrescimoIPI = null;
            Item preçoDeCusto = null;
            Item preçoDeVenda = null;
            Item debitoICMS = null;
            Item debitoPISCofins = null;
            Item lucroBruto = null;

            foreach (var item in items)
            {
                switch (item.Variavel)
                {
                    case LucroRealVariavel.PreçoDeCompra:
                        preçoDeCompra = item;
                        break;
                    case LucroRealVariavel.CreditoICMS:
                        creditoICMS = item;
                        break;
                    case LucroRealVariavel.CreditoPISCofins:
                        creditoPISCofins = item;
                        break;
                    case LucroRealVariavel.AcrescimoIPI:
                        acrescimoIPI = item;
                        break;
                    case LucroRealVariavel.PreçoDeCusto:
                        preçoDeCusto = item;
                        break;
                    case LucroRealVariavel.PreçoDeVenda:
                        preçoDeVenda = item;
                        break;
                    case LucroRealVariavel.DebitoICMS:
                        debitoICMS = item;
                        break;
                    case LucroRealVariavel.DebitoPISCofins:
                        debitoPISCofins = item;
                        break;
                    case LucroRealVariavel.LucroBruto:
                        lucroBruto = item;
                        break;
                    default:
                        throw new ArgumentException($"Variable '{item.Variavel}' is not expected. Item: {item}");
                }
            }

            creditoICMS.CalculatedValue = preçoDeCompra.Value * creditoICMS.Value / 100;
            creditoPISCofins.CalculatedValue = preçoDeCompra.Value * creditoPISCofins.Value / 100;
            acrescimoIPI.CalculatedValue = preçoDeCompra.Value * acrescimoIPI.Value / 100;
            preçoDeCusto.CalculatedValue = preçoDeCompra.Value - creditoICMS.CalculatedValue - creditoPISCofins.CalculatedValue + acrescimoIPI.CalculatedValue;
            debitoICMS.CalculatedValue = preçoDeVenda.Value * debitoICMS.Value / 100;
            debitoPISCofins.CalculatedValue = preçoDeVenda.Value * debitoPISCofins.Value / 100;
            lucroBruto.CalculatedValue = preçoDeVenda.Value - debitoICMS.CalculatedValue - debitoPISCofins.CalculatedValue - preçoDeCusto.CalculatedValue;
            lucroBruto.Value = preçoDeVenda.Value != 0 ? lucroBruto.CalculatedValue / preçoDeVenda.Value * 100 : 0;
        }

    }
}
