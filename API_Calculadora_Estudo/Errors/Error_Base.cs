namespace API_Calculadora_Estudo.Errors
{
    public class Error_Base
    {
        public string Message { get; set; } = string.Empty;
        public Error_Base(string message)
        {
            Message = message;
        }
    }
}
