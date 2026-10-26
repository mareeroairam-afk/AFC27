# AFC 27 — Starter para Unity (Android)

Este paquete es una base de código para empezar un prototipo de fútbol 3D para Android. **No es todavía un juego completo ni incluye modelos 3D, caras, equipaciones, estadio o animaciones finales.**

## Requisitos
- Unity Hub y una versión LTS de Unity instalada.
- Módulos **Android Build Support**, **Android SDK & NDK Tools** y **OpenJDK** instalados desde Unity Hub.
- Crear un proyecto Unity 3D (Built-in o URP) y copiar `Assets/Scripts` a ese proyecto.

## Qué incluye
- Movimiento básico del jugador con controles táctiles en pantalla y teclado para probar en PC.
- Cámara de seguimiento estilo retransmisión, con posición elevada detrás de la jugada.
- Configuración de balón sencilla basada en Rigidbody.
- Comprobación de gol al entrar el balón en una zona de portería.

## Cómo probar
1. Crea un proyecto Unity 3D.
2. Copia la carpeta `Assets/Scripts` dentro de la carpeta `Assets` del proyecto.
3. Crea una escena y un terreno/campo, un jugador con `CharacterController`, un balón con `Rigidbody` y `SphereCollider`, y una zona de gol con `BoxCollider` marcado como `Is Trigger`.
4. Añade los scripts siguiendo los comentarios de cada archivo.
5. En **File > Build Profiles** (o **Build Settings**, según versión), selecciona Android y cambia a Android.
6. Para generar un APK, configura Package Name, orientación Landscape y pulsa Build.

## Importante
Los gráficos realistas y el tamaño final dependen de los modelos, texturas, sonidos, animaciones y configuración de renderizado. Para mantenerlo ligero, usa modelos low-poly bien texturizados, texturas comprimidas, iluminación horneada y limita la resolución de sombras.
