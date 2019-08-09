using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Jobs
{
    class JobEjemplo : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {

            await Console.Out.WriteLineAsync("Hola este es un mensaje de prueba");

        }

    }
}
