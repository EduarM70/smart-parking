# Smart Parking

## Proceso de Instalación 📦
1. Clonar el repositorio
    ```bas
    git clone https://github.com/EduarM70/smart-parking.git
    ```
2. Abra el proyecto en su IDE favorito
3. Asegurese de tener instaldo SQLServer
4. Ajuste las confuguraciones de la conexión a la base de datos en `SmartParking/App.config`
    ```properties
    <appSettings>
	      <add key="DB_CONNECTION" value="Data Source=localhost\NOMBREINSTANCIA;Initial Catalog=SmartParkingDB;Integrated Security=True"/>
    </appSettings>
    ```
5. Asegúrese de crear la base de datos en SQLServer
8. Ejecutar el proyecto


## Usage License ⚖️

<a rel="license" href="http://creativecommons.org/licenses/by-nc/4.0/"><img alt="Licencia Creative Commons" style="border-width:0" src="https://i.creativecommons.org/l/by-nc/4.0/88x31.png" /></a><br /><span xmlns:dct="http://purl.org/dc/terms/" href="http://purl.org/dc/dcmitype/Dataset" property="dct:title" rel="dct:type">
SmartParking is distributed under an <a rel="license" href="http://creativecommons.org/licenses/by-nc/4.0/">Attribution-NonCommercial 4.0 International License</a>.
