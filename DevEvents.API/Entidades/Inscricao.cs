using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.API.Entidades
{
    public class Inscricao
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }
    }
}