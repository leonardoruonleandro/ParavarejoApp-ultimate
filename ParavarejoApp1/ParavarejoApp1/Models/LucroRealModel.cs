using System;
using System.Collections.Generic;
using System.Text;

namespace ParavarejoApp1.Models
{
    public class LucroRealModel
    {

        public void Calculate(Item preçoDeCompra, 
                              Item creditoICMS, 
                              Item creditoPISCofins, 
                              Item acrescimoIPI, 
                              Item preçoDeCusto, 
                              Item preçoDeVenda,
                              Item debitoICMS,
                              Item debitoPISCofins,
                              Item lucroBruto
                              )
        {

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
