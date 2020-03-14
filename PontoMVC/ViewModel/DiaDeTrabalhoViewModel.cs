using System;
using System.Collections.Generic;
using SistemaDePonto.Domain;

namespace PontoMVC.ViewModel
{
    public class DiaDeTrabalhoViewModel
    {
        public int IdDia { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime IntervaloEntrada { get; set; }
        public DateTime IntervaloSaida { get; set; }
        public DateTime Saida { get; set; }
    }
}