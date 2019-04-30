namespace Senai.ToDo.MVC.Utils
{
    public class ValidacaoUtil
    {
        public static bool ValidarEmail (string email)
        {
            if (email.Contains("@") && email.Contains("."))
            {
                return true;
            }
            return false;
        }
        public static bool ValidacaoSenha (string senha)
        {
            if (senha.Length > 6)
            {
                return true;
            }
            return false;
        }
    }
}