
# 📱 App de Monitoreo de Aceleración en Tiempo Real con Detección de Caídas

Este proyecto es una aplicación Android desarrollada con **Xamarin** que utiliza el acelerómetro del dispositivo para monitorear la aceleración en tiempo real. La app grafica la evolución de la aceleración a lo largo del tiempo utilizando la librería **OxyPlot** y es capaz de detectar posibles caídas basadas en los datos del acelerómetro.

## 🚀 Características

- **Monitoreo en Tiempo Real**: Muestra un gráfico en tiempo real de la aceleración del dispositivo utilizando el acelerómetro.
- **Detección de Caídas**: Notifica al usuario con una alerta cuando se detecta una posible caída (cuando la aceleración supera un umbral de 2.5 G).
- **Interfaz Gráfica**: Utiliza la librería **OxyPlot** para generar gráficos que muestran la evolución de la aceleración.
- **Historial de Puntos de Datos**: Mantiene un máximo de 20 puntos de datos en el gráfico para evitar la sobrecarga de la interfaz.
  
## 🛠️ Tecnologías Utilizadas

- **Xamarin.Android**: Plataforma principal para el desarrollo de la aplicación Android.
- **Xamarin.Essentials**: Usado para acceder al acelerómetro del dispositivo.
- **OxyPlot.Xamarin.Android**: Librería para la creación y actualización de gráficos en tiempo real.
- **C#**: Lenguaje de programación utilizado.
- **Android SDK**: Entorno de desarrollo para aplicaciones Android.

## 📂 Estructura del Proyecto

- **MainActivity.cs**: Contiene la lógica principal de la aplicación. Se encarga de iniciar el acelerómetro, manejar la lectura de los datos y actualizar el gráfico.
- **OxyPlot**: Utilizado para graficar la aceleración en tiempo real en la interfaz del usuario.

## 📋 Requisitos del Sistema

- **Android SDK**.
- **Visual Studio con Xamarin** (preferiblemente Visual Studio 2022).
- **Emulador Android o un dispositivo físico** para pruebas.

## ⚙️ Instalación y Configuración

1. **Clona este repositorio**:

   ```bash
   git clone https://github.com/usuario/AccelerationMonitorApp.git
   cd AccelerationMonitorApp
   ```

2. **Abre la solución en Visual Studio**:

   - Abre el archivo de la solución `.sln` en Visual Studio.

3. **Configura el dispositivo de prueba**:

   - Puedes utilizar un emulador Android o un dispositivo físico conectado por USB.

4. **Compila y ejecuta la aplicación**:

   - Haz clic en **Ejecutar** para compilar y ejecutar la aplicación en el dispositivo o emulador seleccionado.

## 🖼️ Demostraciones

- **Gráfico de Aceleración**: 
  ![Gráfico de aceleración en tiempo real](screenshots/acceleration_plot.png)

- **Detección de Caída**: 
  ![Alerta de detección de caída](screenshots/fall_alert.png)

## 🚨 Funcionalidad de Detección de Caídas

Cuando la aceleración supera el umbral de **2.5 G**, se muestra una notificación al usuario alertando sobre una posible caída.

## 🧑‍💻 Contribuciones

Las contribuciones son bienvenidas. Si tienes ideas para mejorar el proyecto, no dudes en hacer un fork y abrir un pull request.

1. Haz un fork del proyecto.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios (`git commit -am 'Agregada nueva funcionalidad'`).
4. Haz push a tu rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un pull request.

## 📜 Licencia

Este proyecto está bajo la Licencia MIT - consulta el archivo [LICENSE](LICENSE) para más detalles.
