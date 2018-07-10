namespace Common.Constantes
{
    public class Mensagens
    {
        public static class Alertas
        {
            public const string SENHA_USUARIO_OBRIGATORIO = "Por favor, informe a sua senha e seu usuário.";
            public const string USUARIO_NAO_ENCONTRADO = "Não encontramos o usuário na base de dados. Tem certeza que possui um cadastro em nosso sistema?";
            public const string LOGIN_INVALIDO = "Usuário e/ou senha inválidos. Verifique as informações informadas e tente novamente.";
        }

        public static class Excecoes
        {
            public const string ARGUMENTOS_NULOS = "Por favor, informe todos os dados obrigatórios.";
            public const string ARGUMENTOS_INVALIDOS = "Por favor, verifique todos os dados informados.";
            public const string SENHA_INVALIDA = "Senha e/ou confirmação de senha inválida. Verifique as informações digitadas e tente novamente.";
        }

        public const string LOGIN_SUCESSO = "Login efetuado com sucesso.";
    }
}
