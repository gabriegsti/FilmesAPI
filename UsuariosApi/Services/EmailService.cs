using System;

namespace UsuariosApi.Services
{
    public class EmailService
    {
        public void EnviarEmail()
        {
            throw new NotImplementedException();
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code)
        }
    }
}