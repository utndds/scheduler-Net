# scheduler-Net
Ejemplo de como hacer un Scheduler usando la libreria de Quartz en .NET

### Programacion sincronica/asincronica
Para poder hacer un scheduler se debe usar la programación con hilos o asincrónica, debido a que un "hilo" sigue corriendo con la funcionalidad "main" del programa y otra controlando el tiempo y la ejecución de los jobs. Ustedes todo lo que venían haciendo y programando en la facultad era mayormente código sincrónico.
El código asincrónico especialmente en el paradigma de objetos es complicado de aplicar ya que tenemos que usar las propiedades async/await que al usarlas mal uno puede terminar haciendo todo el código asincrónico incluso aquellas partes que no necesitan serlas.
Siempre que trabajan con código que tenga que ser parte asincrónico y parte sincrónica lo mejor es aislar toda la parte que sea asincrónica para que no afecte al resto.
Debido a esto y a que estamos usando una librería de bajo nivel vamos a armar nuestra propia clase Scheduler que sería como un adaptador entre nuestro código y los métodos de la librería en sí. Esta va a usar el patrón singleton para que sea un único objeto en todo el proyecto.

### Ejemplos
Hay dos ejemplos en el proyecto, uno en donde el job es simple y solamente imprime algo por consola, y otro en donde el job edita un (objeto que es lo que ustedes seguramente necesiten en el TP).
Lo importante de esto es que cuando prueben el proyecto solo ejecuten un ejemplo a la vez comentando el otro si no se van a marear con los outputs de consola.

### Documentación
[Link oficial](https://www.quartz-scheduler.net/documentation/quartz-3.x/tutorial/index.html)




