﻿using System.Collections.Generic;

namespace UsuariosApi.Models
{
    public class Mensagem
    {
        public List<?> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigo)
        {
            Destinario = ???;
            Assunto = assunto;
            Conteudo = $"https://localhost:6000/ativa?UsuarioId ={usuarioId}&CodigoDeAtivacao={codigo}";
        }
    }
}
