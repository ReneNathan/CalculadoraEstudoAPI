namespace API_Calculadora_Estudo.Errors
{
    public class NotFoundError : SystemException
    {
        public string Message { get; set; } = string.Empty;
        public NotFoundError(string message)
        {
            Message = message;
        }
    }
}
