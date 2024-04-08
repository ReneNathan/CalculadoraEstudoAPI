using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_Calculadora_Estudo.Entidades
{
    public class Conta
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public float Num1 { get; set; }
        public float Num2 { get; set; }
        public string Operation { get; set; } = string.Empty;
        public float Result { get; set; }
    }
}
