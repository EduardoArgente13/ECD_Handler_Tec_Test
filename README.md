# Eduardo Arturo Argente Montes
# eduardoargente.dev@gmail.com

# Proyecto ECD Handler

Este proyecto fue desarrollado como parte de una prueba técnica para Bravos. El objetivo es procesar archivos XML que contienen estados de cuenta (ECD) y calcular el total de los montos (`<monto_total>`) dentro de las facturas (`<factura>`) que están en la liquidación con `num_liq="0"`.

---

## **Descripción del problema**

Los archivos XML contienen información sobre facturas y montos de dinero. El programa debe:
1. Leer los archivos XML desde una carpeta específica.
2. Buscar los valores de `<monto_total>` dentro de `<liquidacion num_liq="0">`.
3. Sumar esos valores y mostrar el total de cada factura.
4. Mostrar un resumen final con el total general de todas las facturas.

---

## **Proceso de desarrollo**

### **1. Configuración del proyecto**
- El proyecto fue creado en **.NET 8**, aunque originalmente estaba configurado para .NET 6. Se decidió usar .NET 8 porque es la versión instalada en el sistema.
- Se utilizó **Visual Studio Code** como editor de código.

### **2. Lectura de archivos XML**
- El programa lee los archivos XML desde la carpeta `XML_files` dentro del proyecto.
- Para leer los archivos, se usa la clase `XDocument` de .NET, que permite cargar y procesar archivos XML fácilmente.

### **3. Procesamiento de los datos**
- El programa busca todas las etiquetas `<monto_total>` dentro de `<liquidacion num_liq="0">`.
- Los valores de `<monto_total>` se convierten a números decimales y se suman para obtener el total de cada factura.

### **4. Manejo de errores**
- Se agregó un bloque `try-catch` para manejar posibles errores, como archivos XML corruptos o valores de `<monto_total>` que no sean números.
- Si ocurre un error, el programa muestra un mensaje en la consola indicando qué salió mal.

### **5. Mejora del formato de salida**
- El programa muestra el total de cada factura en la consola.
- Al final, se muestra un resumen con el total general de todas las facturas.

### **6. Ejecución del programa**
- El programa se ejecuta desde la terminal usando los comandos:
  ```bash
  dotnet build
  dotnet run
