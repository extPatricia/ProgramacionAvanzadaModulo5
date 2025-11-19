# ProgramacionAvanzadaModulo5

## Ejercicio MiniGolf (Ejercicio 1 Mod 5 | Programando Físicas)
Enunciado de ChatGPT:

El jugador controla una bola estilo minigolf. Cuando hace clic y arrastra con el ratón, aparece una línea de predicción que se calcula con un raycast (o varios).
Suelta el botón → la bola recibe una fuerza y rueda por un pequeño circuito con rampas y obstáculos.
La meta es meter la bola en un hoyo con trigger

## Ejercicio Spawner Figuras (Ejercicio 2 Mod 5 | Gestión de componentes | pdf 5.2.8)
Enunciado de ChatGPT:

Crea una pequeña escena con 3 prefabs de figuras geométricas (por ejemplo: cubo, esfera, cápsula).
Cada figura tendrá un color o material diferente.
El jugador puede pulsar una tecla (1, 2 o 3) para generar una figura en una posición aleatoria y con un color aleatorio.

Además, vas a guardar la información de cada figura (su tipo, posición y color) en un archivo JSON usando structs y listas. 
Al cerrar el juego, todos los datos se guardarán; y al volver a entrar, si el archivo existe, deberás cargarlo y volver a instanciar todas las figuras exactamente como estaban antes.

## Ejercicio Inventario minimalista de coleccionables (Ejercicio 2 Mod 5 | Gestión de componentes | pdf 5.2.8)
Enunciado de ChatGPT:

Crear un pequeño sistema de inventario donde el jugador puede recoger coleccionables dispersos por la escena.
Habrá tres tipos de objetos: gemas, monedas y pergaminos, que se generarán en posiciones aleatorias al iniciar la escena. 
Cuando el jugador “coja” un objeto (por ejemplo, haciendo click sobre él), este desaparecerá de la escena y se añadirá a su inventario. 
La información del inventario se guardará en un archivo JSON usando structs y listas, de manera que al reiniciar la escena los objetos ya recogidos no vuelvan a aparecer y los que no se han recogido sí se instancien de nuevo
