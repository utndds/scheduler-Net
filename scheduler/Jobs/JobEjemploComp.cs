using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Jobs
{
    class JobEjemploComp : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {

            Usuario usuario = (Usuario)context.JobDetail.JobDataMap.Get("usuario");
            await Console.Out.WriteLineAsync("JOB --------------------------- ");
            await Console.Out.WriteLineAsync("Hola " + usuario.username);

            usuario.username = "admin2";

            await Console.Out.WriteLineAsync("Cambio el usuario desde el Job a " + usuario.username);
            await Console.Out.WriteLineAsync("--------------------------------- ");

        }

    }
}
