using Quartz;
using Quartz.Impl;
using scheduler.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler
{
    class Program
    {
        static void Main(string[] args)
        {

            // Basandonos en la idea de separar lo ques bajo nivel de lo de alto nivel
            // vamos a hacer una clase llamada Scheduler que se "encargue del manejo de los eventos".
            // En realidad solamente va a delegar esta accion a una libreria de bajo nivel usando los metodos que esta defina
            // en este caso vamos a usar la libreria Quartz

            // Para esto vamos a aplicar el patron singleton ya que queremos que nuestro objeto Scheduler 
            // sea unico en todo el proyecto
            Scheduler sched = Scheduler.getInstance();

            // La realidad es que esto lo hacemos tambien ya que al trabajar con librerias de eventos
            // parte de nuestro codigo tiene que ser asincronico cosa que tiene un problema,
            // si uno no maneja bien esto puede que de forma obligada todo el resto del proyecto pase a ser asincronico
            // por ende siempre que se trabaja con algun modulo asi la idea es aislar el codigo asincronico para que no 
            // invada al resto...

            // Hay dos ejemplos hechos, uno con un job simple, y otro con un job complejo, por favor comenten uno de
            // los ejemplos antes de ejecutar el proyecto porque se van a marear ya que la unica forma que tengo de
            // demostrar la funcionalidad rapidamente es con la consola

            // Empieza a funcionar el scheduler
            sched.run();

            // EJEMPLO JOB SIMPLE
            // jobSimple(sched);

            // EJEMPLO JOB CON EDICION DE OBJETOS
            jobComplejo(sched);

            // El scheduler se puede parar con este metodo
            sched.stop();

        }

        public static void jobSimple(Scheduler sched)
        {

            // EJEMPLO JOB SIMPLE
            // Creo job con la clase JobEjemplo que dentro de su metodo Execute define que es lo que se va a ejecutar
            IJobDetail job = JobBuilder.Create<JobEjemplo>()
                // Aca defino un nombre para identificar al Job, y un nombre grupo para poder agruparlos/categorizar los jobs
                .WithIdentity("trabajoEjemplo", "grupoEjemplo")
                .Build();

            // Creo trigger que representa un timer de cada cuanto se va a ejecutar algo
            ITrigger trigger = TriggerBuilder.Create()
                  // Aca defino un nombre para identificar al Trigger, y un nombre grupo para poder agruparlos/categorizar los triggers
                  .WithIdentity("triggerEjemplo", "grupoEjemplo")
                  // Aca defino como se tiene que ejecutar, en este caso cada 30 segundos para siempre
                  // desde el primer momento
                  .StartNow()
                  .WithSimpleSchedule(x => x
                      .WithIntervalInSeconds(30)
                      .RepeatForever())
                  .Build();

            // Adjunto el job al timer, y lo meto en el Scheduler
            sched.agregarTask(job, trigger);

            // Agrego un readline para llegar a ver el output de consola
            Console.ReadLine();

        }

        private static void jobComplejo(Scheduler sched)
        {

            // EJEMPLO JOB CON EDICION DE OBJETOS
            // Si queremos que nuestro Task sea capaz de editar objetos y que estos cambios se repliquen en otras partes
            // del programa debemos aclararlo debido a que trabajan con la idea de hilos distintos
            // es una explicacion un poco vaga pero util...

            // Creo un objeto usuario
            Usuario usuario = new Usuario("admin", "admin123");

            // Guardo el objeto dentro un objeto diccionario para que pueda accederlo desde el job
            JobDataMap jobData = new JobDataMap();
            jobData.Add("usuario", usuario);

            IJobDetail jobComp = JobBuilder.Create<JobEjemploComp>()
                .WithIdentity("trabajoEjemplo2", "grupoEjemplo")
                // Aca le asigno meto el diccionario dentro del job
                .UsingJobData(jobData)
                .Build();

            ITrigger triggerComp = TriggerBuilder.Create()
                  .WithIdentity("triggerEjemplo2", "grupoEjemplo")
                  .StartNow()
                  // Este trigger se va a ejecutar cada 5 segundos
                  .WithSimpleSchedule(x => x
                      .WithIntervalInSeconds(5)
                      .RepeatForever())
                  .Build();

            // Asocio el job con el trigger
            sched.agregarTask(jobComp, triggerComp);

            // Pauso el hilo por 3 segundos
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("MAIN ------------------------- ");
            Console.WriteLine("Hola " + usuario.username);
            usuario.username = "admin";
            Console.WriteLine("Cambio el usuario desde el Job a " + usuario.username);
            Console.WriteLine("------------------------------ ");

            System.Threading.Thread.Sleep(8000);

        }

    }
}
