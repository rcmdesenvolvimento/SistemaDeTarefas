﻿using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum StatusTarefas
    {
        [Description("A fazer")]
        AFazer = 1,

        [Description("em Andamento")]
        EmAndamento = 2,

        [Description("Concluído")]
        Concluido = 3
    }
}