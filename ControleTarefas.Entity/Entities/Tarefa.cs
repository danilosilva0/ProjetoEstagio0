﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Entity.Entities
{
    public class Tarefa
    {
        public string Titulo { get; set; }
        public Tarefa()
        {

        }
        public Tarefa(string titulo)
        {
            Titulo = titulo;
        }
    }
}
