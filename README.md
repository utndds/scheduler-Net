# scheduler-Net
Ejemplo de como hacer un Scheduler usando la libreria de Quartz en .NET

### Programacion sincrónica/asincrónica
Para poder hacer un scheduler se debe usar la programación con hilos o asincrónica, debido a que un "hilo" sigue corriendo con la funcionalidad "main" del programa y otra controlando el tiempo y la ejecución de los jobs. Ustedes todo lo que venían haciendo y programando en la facultad era mayormente código sincrónico.
El código asincrónico especialmente en el paradigma de objetos es complicado de aplicar ya que tenemos que usar las propiedades async/await que al usarlas mal uno puede terminar haciendo todo el código asincrónico incluso aquellas partes que no necesitan serlas.
Siempre que trabajan con código que tenga que ser parte asincrónico y parte sincrónica lo mejor es aislar toda la parte que sea asincrónica para que no afecte al resto.
Debido a esto y a que estamos usando una librería de bajo nivel vamos a armar nuestra propia clase Scheduler que sería como un adaptador entre nuestro código y los métodos de la librería en sí. Esta va a usar el patrón singleton para que sea un único objeto en todo el proyecto.

### Ejemplos
Hay dos ejemplos en el proyecto, uno en donde el job es simple y solamente imprime algo por consola, y otro en donde el job edita un objeto (que es lo que ustedes probablemente necesiten en el TP).
Lo importante de esto es que cuando prueben el proyecto solo ejecuten un ejemplo a la vez comentando el otro si no se van a marear con los outputs de consola.

### Explicación
- **Job Simple:** En este ejemplo solamente se hace un job que cada X tiempo imprima algo por consola mientras el resto del código sigue  "ejecutando" en este caso solo hay un Console.Readline() para poder leer el output de consola
- **Job Complejo:** Se crea un job que edita el estado/atributos de un objeto en este caso el username de un Usuario. Como van a ver en el código lo que se propone es ver como cambiando el atributo del objeto tanto en el proceso main del programa como en el proceso job/scheduler se impacta tambien en el otro. Para esto demostrar esto lo que se hace es imprimir el nombre actual del usuario y cambiarlo por otro distinto, mostrando de que proceso viene cada output de consola.

### Documentación
[Link documentación - Quartz](https://www.quartz-scheduler.net/documentation/quartz-3.x/tutorial/index.html)




