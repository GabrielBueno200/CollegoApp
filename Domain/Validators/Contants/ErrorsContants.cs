namespace Domain.Validators
{
    public static class ErrorsContants{
        public static string FORGOT_FIELD(string propertyName) => $" {propertyName}: Certifique-se de que o campo foi preenchido!";
        public const string PASSWORD_CONFIRM = "As senhas informadas não coincidem!";

    }
}