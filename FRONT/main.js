
function versubmenu()
{
    document.getElementById("menu").style.display = "none";
    document.getElementById("submenu").style.display = "block";
}

function regresubmenu()
{
    document.getElementById("submenu").style.display = "none";
    document.getElementById("menu").style.display = "block";
}


function regresarMenuPrincipal() {
    document.getElementById("servicio-pagado").style.display = "none";
    document.getElementById("menu").style.display = "block";
}

function regresarmenuprincipio()
{
    document.getElementById("card-form").style.display = "none";
    document.getElementById("menu").style.display = "block";
}

function regresarmenuprincipio1()
{
    document.getElementById("service-menu").style.display = "none";
    document.getElementById("menu").style.display = "block";
}


function regreMenuD()
{
    document.getElementById("deposito").style.display = "none";
    document.getElementById("menuD").style.display = "block";
}

function regreMenuD2()
{
    document.getElementById("retiro").style.display = "none";
    document.getElementById("menuD").style.display = "block";
}

function regreMenuD3()
{
    document.getElementById("cambioNIP").style.display = "none";
    document.getElementById("menuD").style.display = "block";
}

function regresarmenuprincipio2()
{
    document.getElementById("transaction-history").style.display = "none";
    document.getElementById("menuD").style.display = "block";
}

function regreMenuDEB()
{
    document.getElementById("service-menu2").style.display = "none";
    document.getElementById("menuD").style.display = "block";
}





function showServiceMenu() {
    document.getElementById("menu").style.display = "none";
    document.getElementById("service-menu").style.display = "block";
}
// Función para pagar el servicio y mostrar la diapositiva de servicio pagado

 // Función para mostrar el formulario de ingreso con tarjeta
 function showCardForm() {
    document.getElementById("menu").style.display = "none";
    document.getElementById("card-form").style.display = "block";
    }


    var opcionesSeleccionadas = 0; 

    function showMenu(menuId) {
       
        if (opcionesSeleccionadas < 5) {
            
            document.getElementById(menuId).style.display = "block";
            
            opcionesSeleccionadas++;
        } else {
            alert("Lo sentimos ha alcanzado el numero maximo de movimientos!");

            document.getElementById("menu").style.display = "block";
            opcionesSeleccionadas = 0; 
        }
    }

    function volverasubmenu() 
    {
     
        var menusSecundarios = document.querySelectorAll('.submenu');
        menusSecundarios.forEach(function(menu) {
            menu.style.display = "none";
        });
       
        opcionesSeleccionadas = 0;
     
        document.getElementById("menu").style.display = "block";
    }




    
    var intentosValidacion = 0; 

    var intentosValidacion = 0; 

    function validateCard() {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
    
        if (cardNumber.length === 16) {
            fetch('http://localhost:5100/Tarjeta/Verificar?numeroTarjeta=' + cardNumber)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Ocurrió un error al verificar la tarjeta');
                    }
                    return response.json();
                })
                .then(data => {
                    if (data === true) {
                        document.getElementById("card-form").style.display = "none";
                        document.getElementById("processing").style.display = "block";
                        setTimeout(function() {
                            document.getElementById("processing").style.display = "none";
                            document.getElementById("pin-form").style.display = "block";
                        }, 3000);
                    } else {
                        // Incrementar el contador de intentos
                        intentosValidacion++;
    
                        if (intentosValidacion >= 3) {
                            alert("!Lo sentimos ha alcanzado el numero maximo de movimientos!");
                            mostrarMenuGeneral();
                        } else {
                            document.getElementById("card-error").style.display = "block";
                        }
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    document.getElementById("resultado").innerText = "Ocurrió un error al verificar la tarjeta.";
                });
        } else {
            document.getElementById("card-error").style.display = "block";
        }
        //ESTE ES LA NUEVA
    }
    
    function mostrarMenuGeneral() {
        // Aquí agregarás el código para regresar al menú principal
        document.getElementById("menu").style.display = "block";
        document.getElementById("card-form").style.display = "none";
        intentosValidacion = 0; // Reiniciar el contador de intentos
    }


var intentosNIP = 0; // Contador de intentos de ingreso del NIP


function validatePin() {
    var pin = document.getElementById("pin").value;
    var cardInput = document.getElementById("cardNumber");
    var cardNumber = cardInput.value;

    if (pin.length === 4) {
        fetch('http://localhost:5100/Tarjeta/VerificacionPIN?numeroTarjeta=' + cardNumber + '&pin=' + pin)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Ocurrió un error al verificar la tarjeta');
                }
                return response.text();
            })
            .then(data => {
                if (data === "D") {
                    document.getElementById("pin-form").style.display = "none";
                    document.getElementById("menuD").style.display = "block";
                } 
                if (data === "C") {
                    document.getElementById("pin-form").style.display = "none";
                    document.getElementById("menu-credito").style.display = "block";
                } 
                else  {
                    // Incrementar el contador de intentos
                    intentosNIP++;
                        
                    if (intentosNIP >= 3) {
                        alert("Has excedido el número máximo de intentos. Regresando al menú.");
                        // Aquí regresas al menú principal
                        document.getElementById("menu").style.display = "block";
                        document.getElementById("pin-form").style.display = "none";
                        intentosNIP = 0; // Reinicias el contador de intentos
                    } else {
                        document.getElementById("card-error").style.display = "block";
                    }
                }
            })
           
            .catch(error => {
                console.error('Error:', error);
                document.getElementById("resultado").innerText = "Ocurrió un error al verificar la tarjeta.";
            });
    } else {
        document.getElementById("pin-error").style.display = "block";
    }
    //ESTE ES LA NUEVA
}
   

    // Función para mostrar el menú general
    function mostrarMenuGeneral() {
        document.getElementById("historial-exitoso").style.display = "none";
        document.getElementById("menu").style.display = "block";
    }

    // Función para mostrar el menú específico según la opción seleccionada
    function showMenu(menu) {
        document.getElementById("menu").style.display = "none";
        document.getElementById( menu).style.display = "block";
    }



    // Función para realizar un retiro
   

    // Función para continuar después de un evento exitoso
    function continuar() {
        // Aquí podrías redirigir a otra página o realizar otras acciones necesarias
        alert("Continuar...");
    }

    // Función para continuar desde el historial de transacciones
    function continuarDesdeHistorial() {
        // Aquí podrías redirigir a otra página o realizar otras acciones necesarias
        alert("Continuar desde el historial...");
    }

    // Función para cambiar el NIP
    function cambiarNIP() {
        var pin = document.getElementById("pin").value;
        var nuevopin = document.getElementById("newpin").value;
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value
        if (nuevopin===pin)
        {
            alert("No se pudo cambiar el pin")
        }
        else
        {
            fetch('http://localhost:5100/Tarjeta/CambioPIN?numeroTarjeta=' + cardNumber + '&NuevoPIN=' + nuevopin)
            .then(response => {
                if (!response.ok) {
                    alert('Ocurrió un error al verificar la tarjeta');
                }
                return response.json();
            })
            .then(data => {
                if (data === true) {
                    document.getElementById("cambioNIP").style.display = "none";
                    document.getElementById("change-pin-success").style.display = "block";
                    pin=nuevopin
                    
                } else {
                    alert("Error no se pudo cambia el pin")
                    document.getElementById("card-error").style.display = "block";
                }
            })
            .catch(error => {
                console.error('Error:', error);
                document.getElementById("resultado").innerText = "Ocurrió un error al verificar la tarjeta.";
            });
        };
        
    }

    
    function realizarDeposito() {
        // Obtener la cantidad a depositar del input
        var cantidad = parseFloat(document.getElementById("cantidadDeposito").value);
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
    
        // Validar que la cantidad sea un múltiplo de 50
        if (cantidad % 50 !== 0) {
            alert("La cantidad a depositar debe ser un múltiplo de $50.");
            return; // Salir de la función sin realizar el depósito
        }
    
        // Validar que la cantidad no exceda los $9000
        if (cantidad > 9000) {
            alert("La cantidad máxima para depositar es de $9000.");
            return; // Salir de la función sin realizar el depósito
        }
    
        if (cantidad >= 50) {
            fetch('http://localhost:5100/Tarjeta/Deposito?numeroTarjeta=' + cardNumber + '&Deposito=' + cantidad)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    console.log("Dato recibido desde la API: ", data);
                    alert("Depósito realizado correctamente. Su nuevo saldo es: $" + data);
    
                    // Aquí puedes hacer lo que quieras con el dato recibido
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                });
    
            // Mostrar el saldo actualizado al usuario
            document.getElementById("deposit-success").style.display = "block";
            document.getElementById("deposito").style.display = "none";
        } else {
            // Mostrar mensaje de error si la cantidad es menor que 50
            alert("La cantidad mínima para depositar es de $50.");
        }
        //ESTE ES LA NUEVA
    }
  
    function realizarRetiro() {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        var monto = parseFloat(document.getElementById("retiro-amount").value);
    
       
        if (monto % 50 === 0) {
            fetch('http://localhost:5100/Tarjeta/VerSaldo?Tarjeta=' + cardNumber)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(saldo => {
                    // Verificar si el saldo es suficiente para realizar el retiro
                    if (saldo >= monto) {
                       
                        fetch('http://localhost:5100/Tarjeta/Retiro?numeroTarjeta=' + cardNumber + '&Retiros=' + monto)
                            .then(response => {
                                if (!response.ok) {
                                    throw new Error('Network response was not ok');
                                }
                                return response.json();
                            })
                            .then(data => {
                                console.log("Dato recibido desde la API: ", data);
                                alert("Retiro realizado correctamente. Su nuevo saldo es: $" + data);
                            })
                            .catch(error => {
                                console.error('There has been a problem with your fetch operation:', error);
                            });
                        
                        document.getElementById('retiro').style.display = 'none';
                        document.getElementById('withdraw-success').style.display = 'block';
                    } else {
                        
                        alert("Fondos insuficientes. No puede retirar más de lo que tiene en su saldo actual.");
                    }
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                });
        } else {
            // Si el monto no es un múltiplo de 50, mostrar un mensaje de error
            alert("El monto a retirar debe ser un múltiplo de $50.");
        }
        //ESTA ES LA NUEVA
    }

        
    // Función para continuar después de un evento exitoso
    function continuar() {
        // Aquí podrías redirigir a otra página o realizar otras acciones necesarias
        alert("Continuar...");
    }

    // Función para continuar desde el historial de transacciones
    function continuarDesdeHistorial() {
        // Aquí podrías redirigir a otra página o realizar otras acciones necesarias
        alert("Continuar desde el historial...");
    }


    function Regre(menu) {
        document.getElementById(menu).style.display = "none";
        document.getElementById("menuD").style.display = "block";
    }

    function pagarServicio() {
        var numServicio = document.getElementById("numeroServicio").value;
        fetch('http://localhost:5100/Tarjeta/ServicioEX?numeroServicio=' + numServicio)
        .then(response => response.json())
        .then(data => {
            // Imprime la respuesta completa
            console.log('Respuesta del servidor:', data);

            // Aquí puedes acceder a los datos individualmente
            const cantidad = data.cantidad;
            const tipoServicio = data.tipoSE;
            // Verificar si los datos existen
            document.getElementById("cantidad-pago").innerText = cantidad;
            document.getElementById("tipo-servicio-pago").innerText = tipoServicio;
            console.log("Cantidad:", cantidad);
            console.log("Tipo de Servicio:", tipoServicio);
            document.getElementById("service-menu").style.display = "none";
            document.getElementById("PAGOS").style.display = "block";
            
        })
    
        .catch(error => {
            console.error('Error:', error);
        });
        
        // Por ahora, simplemente mostramos la diapositiva de servicio pagado
        
    }

    function serPago() {
        var numServicio = document.getElementById("numeroServicio").value;
        var cantidadIngresada = parseFloat(document.getElementById('CantidaS').value);
        var cantidadAPagar = parseFloat(document.getElementById('cantidad-pago').textContent);
        if (cantidadIngresada === cantidadAPagar )
        {
        fetch('http://localhost:5100/Tarjeta/PagoS?numero=' + numServicio + '&pago=' + cantidadIngresada +'&Cantotal='+cantidadAPagar)
        .then(response => response.json())
        .then(data => {
            if (data === true) {
            alert("Pago exitoso");
            document.getElementById("PAGOS").style.display = "none";
            document.getElementById("servicio-pagado").style.display = "block";
            }
            else{
                alert("La cantida tiene que ser exacta");
            }
        })
        }
        else {
            alert("La cantida tiene que ser exacta");
        }
        
        
    }
    function Inicio(menu) {
        document.getElementById(menu).style.display = "none";
        document.getElementById("menu").style.display = "block";
    }
    



    function mostrarSaldo() {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
    
        fetch('http://localhost:5100/Tarjeta/VerSaldo?Tarjeta=' + encodeURIComponent(cardNumber))
            .then(response => response.json())
            .then(data => {
                console.log('Respuesta del servidor:', data);
                document.getElementById("saldo").innerText = data.saldo; // Adjust according to the actual response structure
                document.getElementById("menuD").style.display = "none";
                document.getElementById("consultaSaldo").style.display = "block";
            })
            .catch(error => {
                console.error('Error:', error);
                // Handle the error, perhaps display a user-friendly message
            });
    }
    

    // Función simulada para obtener el saldo actual del usuario desde el servidor
    function obtenerSaldoDelServidor() {
        // En este ejemplo, se simula que el saldo es de $10,000
        return "$10,000";
    }



    function volverMenudebito()
    {
        document.getElementById("consultaSaldo").style.display = "none";
        document.getElementById("menuD").style.display = "block";
    }







      // Simular que la anualidad está pendiente de pago
      var anualidadPendiente = true;

      if (anualidadPendiente) {
          document.getElementById("pagoPendiente").classList.remove("hidden");
      } else {
          document.getElementById("anualidadPagada").classList.remove("hidden");
      }


      function elegirOpcion(opcion) {
        // Aquí podrías agregar la lógica para procesar la opción seleccionada
        // Por ejemplo, podrías redirigir a una página de solicitud de préstamo con la opción seleccionada
        alert("Has seleccionado la opción: " + opcion);
    }


    var movimientosRealizados = 0; 

    function showMenu(menu) {
    // Incrementar el contador de movimientos
    document.getElementById("menuD").style.display = "none";
    document.getElementById(menu).style.display = "block";
    movimientosRealizados++;
    

    // Verificar si se han realizado más de 5 movimientos
    if (movimientosRealizados > 5) {
        alert("!Lo sentimos ha alcanzado el numero maximo de movimientos!");
        mostrarMenuGeneral();
        document.getElementById("menu").style.display = "block";
        return; // Salir de la función sin ejecutar más acciones
    }

    // Aquí iría el resto de tu lógica para mostrar la opción seleccionada

    }
// Función para regresar al menú principal
function Inicio(id) {
    document.getElementById("menuD").style.display = "none";
    document.getElementById("menu").style.display = "block";
    movimientosRealizados = 0; // Reiniciar el contador de movimientos
}

function Histor() {
    var cardInput = document.getElementById("cardNumber");
    var cardNumber = cardInput.value;
    fetch('http://localhost:5100/Tarjeta/Historial?numeroTarjeta='+ cardNumber + "&TipoT=" + "D" )
      .then(response => response.json())
      .then(data => {
        // Iterar sobre cada objeto en el arreglo de datos recibidos
        data.forEach(transaccion => {
          // Acceder a las propiedades de cada transacción
          
          document.getElementById("transaction-history").style.display = "none";
          document.getElementById( "history89").style.display = "block";
          var transactionContainer = document.getElementById("transaction-container");
        // Limpiar el contenedor antes de agregar nuevas transacciones
        transactionContainer.innerHTML = "";
        
        // Iterar sobre cada objeto en el arreglo de datos recibidos
        data.forEach(transaccion => {
          // Crear elementos HTML para mostrar los detalles de la transacción
          var transaccionElement = document.createElement("div");
          transaccionElement.classList.add("transaccion");
          
          var fechaElement = document.createElement("p");
          fechaElement.innerText = "Fecha: " + transaccion.fecha;
          transaccionElement.appendChild(fechaElement);
          
          var tipoElement = document.createElement("p");
          tipoElement.innerText = "Tipo de transacción: " + transaccion.tipo;
          transaccionElement.appendChild(tipoElement);
          
          var montoElement = document.createElement("p");
          montoElement.innerText = "Monto: " + transaccion.monto;
          transaccionElement.appendChild(montoElement);
          
          // Agregar el elemento de transacción al contenedor
          transactionContainer.appendChild(transaccionElement);
        });
  
          // Puedes hacer lo que necesites con esta información, por ejemplo, imprimir los detalles de la transacción
        
        });
      })
      .catch(error => {
        console.error('Error al obtener el historial:', error);
      });

    }

    function MEN ()
    {
        document.getElementById("submenu").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }


    function pagarServicio2() {
        var numServicio = document.getElementById("numeroServicio2").value;
        fetch('http://localhost:5100/Tarjeta/ServicioEX?numeroServicio=' + numServicio)
        .then(response => response.json())
        .then(data => {
            // Imprime la respuesta completa
            console.log('Respuesta del servidor:', data);

            // Aquí puedes acceder a los datos individualmente
            const cantidad = data.cantidad;
            const tipoServicio = data.tipoSE;
            // Verificar si los datos existen
            document.getElementById("cantidad-pago").innerText = cantidad;
            document.getElementById("tipo-servicio-pago").innerText = tipoServicio;
            console.log("Cantidad:", cantidad);
            console.log("Tipo de Servicio:", tipoServicio);
            document.getElementById("service-menu2").style.display = "none";
            document.getElementById("PAGOS").style.display = "block";
            
        })
    }

    function volverasubmenu()
    {
        document.getElementById("menuD").style.display = "none";
        document.getElementById("menu").style.display = "block";
    }

    function volvermenuD()
    {
        document.getElementById("menu-credito").style.display = "none";
        document.getElementById("menu").style.display = "block";
    }


    function PagoTarjeta()
    {
        document.getElementById("menu-credito").style.display = "none";
        document.getElementById("pagotarjetadebito").style.display = "block";
    }

    function Pagocredito()
    {
        document.getElementById("menu-credito").style.display = "none";
        document.getElementById("pagodecredito").style.display = "block";
    }
    
    function PagoAnualidad()
    {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/VerAnual?numero=' + cardNumber)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Ocurrió un error al verificar la tarjeta');
                    }
                    return response.json();
                })
                .then(data => {
                    if (data === true) {
                        document.getElementById("menu-credito").style.display = "none";
                        document.getElementById("pagoanualidad2").style.display = "block";
                    } else {
                        fetch('http://localhost:5100/Tarjeta/NoPago?numero=' + cardNumber)
                        .then(response => {
                            if (!response.ok) {
                                throw new Error('Ocurrió un error al verificar la tarjeta');
                            }
                            return response.json();
                        })
                        .then(data => {
                           
                                document.getElementById("CantidadaboAN").textContent = data;
                                // Incrementar el contador de intentos
                                ddocument.getElementById("menu-credito").style.display = "none";
                                document.getElementById("pagoanualidad").style.display = "block";;;
            
                                
                            
                        })
                        .catch(error => {
                            console.error('Error:', error);
                            document.getElementById("resultado").innerText = "Ocurrió un error al verificar la tarjeta.";
                        });
                        // Incrementar el contador de intentos
                        
    
                        
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    document.getElementById("resultado").innerText = "Ocurrió un error al verificar la tarjeta.";
                });
        
    }

    function PagoEstudiante()
    {
        document.getElementById("menu-credito").style.display = "none";
        document.getElementById("deudaestudiante").style.display = "block";
    }

    // APARTIR DE AQUI EMPIEZA LOS SCRIPTS DE PAGO DE TARJETA
    
    function volvermenucredito()
    {
        document.getElementById("pagotarjetadebito").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }

    function pagocompleto()
    {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/CreSal?numeroCredito=' + cardNumber )
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    if(data==0)
                    {
                        alert("La trajeta ya esta pagada")
                    }
                    else
                    {
                    console.log("Dato recibido desde la API: ", data);
                     // Actualizar el texto dentro del span con el dato recibido
                    document.getElementById("labelCantidad").textContent = data;
                    document.getElementById("pagotarjetadebito").style.display = "none";
                    document.getElementById("pagocompleto").style.display = "block";
                    // Aquí puedes hacer lo que quieras con el dato recibido
                    }
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                })
        
        
    }

    function pagoabonos()
    {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/CreSal?numeroCredito=' + cardNumber )
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    if(data==0)
                    {
                        alert("La tarjeta ya esta pagada")
                    }
                    else
                    {
                    console.log("Dato recibido desde la API: ", data);
                     // Actualizar el texto dentro del span con el dato recibido
                    document.getElementById("Cantidadabo").textContent = data;
                    document.getElementById("pagotarjetadebito").style.display = "none";
                    document.getElementById("pagoabonos").style.display = "block";
                    // Aquí puedes hacer lo que quieras con el dato recibido
                    }
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                })
        
    }

    function volveraPago1()
    {
        document.getElementById("pagocompleto").style.display = "none";
        document.getElementById("pagotarjetadebito").style.display = "block";
    }

    function volveraPago2()
    {
        document.getElementById("pagoabonos").style.display = "none";
        document.getElementById("pagotarjetadebito").style.display = "block";
    }

    function volvermenucredito2()
    {
        document.getElementById("pagocompletoexitoso").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }

    function volvermenucredito3()
    {
        document.getElementById("pagoabonosexitoso").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }

    //A PARTIR DE AQUI SON LOS SCRIPTS DE PAGO CREDITO

    function regresarmenuCredito()
    {
        document.getElementById("pagodecredito").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }

    function abonoCapital()
    {
        document.getElementById("pagodecredito").style.display = "none";
        document.getElementById("abonocapital").style.display = "block";
    }

    function pagoMensual()
    {
        document.getElementById("pagodecredito").style.display = "none";
        document.getElementById("pagomensual").style.display = "block";
    }

    function regresarmenuPagocredito()
    {
        document.getElementById("abonocapitalexitoso").style.display = "none";
        document.getElementById("pagodecredito").style.display = "block";
    }

    function regresarmenuPagocredito2()
    {
        document.getElementById("pagomensual").style.display = "none";
        document.getElementById("pagodecredito").style.display = "block";
    }

    function regresarmenuPagocredito3()
    {
        document.getElementById("mensualexitoso").style.display = "none";
        document.getElementById("pagodecredito").style.display = "block";
    }

    // A PARTIR DE AQUI EMPIEZAN LOS SCRIPTS DE ANUALIDAD

    
    function denuevoMenuCredito()
    {
        document.getElementById("pagoanualidad").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }

    function denuevoMenuCredito2()
    {
        document.getElementById("pagoanualidad2").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }

    // A PARTIR DE AQUI EMPIEZAN LOS SCRIPTS DE DEUDA ESTUDIANTIL

    function VolverAcredito()
    {
        document.getElementById("deudaestudiante").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }

    function Tradicional()
    {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/VerCantiEs?numero=' + cardNumber )
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            
            console.log("Dato recibido desde la API: ", data);
            document.getElementById("Deuda2").innerText = data.canDeudaEstu;
            document.getElementById("Cpado2").innerText = data.pagoDeudaEstu;
             
            document.getElementById("deudaestudiante").style.display = "none";
        document.getElementById("tradicional").style.display = "block";
            // Aquí puedes hacer lo que quieras con el dato recibido
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        })
        
    }

    function menuDeudaestudiante()
    {
        document.getElementById("tradicional").style.display = "none";
        document.getElementById("deudaestudiante").style.display = "block";
    }

    function menuDeudaestudiante2()
    {
        document.getElementById("tradiexitoso").style.display = "none";
        document.getElementById("deudaestudiante").style.display = "block";
    }

    function Contingente()
    {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/VerCantiEs?numero=' + cardNumber )
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            
            console.log("Dato recibido desde la API: ", data);
            document.getElementById("Deuda").innerText = data.canDeudaEstu;
            document.getElementById("Cpado").innerText = data.pagoDeudaEstu;
             
            document.getElementById("deudaestudiante").style.display = "none";
            document.getElementById("opcioncontingente").style.display = "block";
            // Aquí puedes hacer lo que quieras con el dato recibido
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        })
       
    }
    
     var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            var mes = parseInt(document.getElementById("mesC2").innerText);
            var pago = parseInt(document.getElementById("pagoCapiC2").innerText);
            var cantidad = parseInt(document.getElementById("cantimensualidad").value);
            var suma = cantidad + pago;
            if (cantidad % 50 === 0) {
                if(mes == suma )
                {
                    fetch('http://localhost:5100/Tarjeta/PagocomC?numero=' + cardNumber + '&canti=' + suma)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        
                        console.log("Dato recibido desde la API: ", data);
                        
                        document.getElementById("pagomensu").style.display = "none";
                        document.getElementById("pagomensuexitoso").style.display = "block";
                        console.log(suma);
                        
                        
                        // Aquí puedes hacer lo que quieras con el dato recibido
                    })
                    .catch(error => {
                        console.error('There has been a problem with your fetch operation:', error);
                    })
                    
                }
                else
                {
                    alert("tiene que ser igual")
                }
            }

            function  PagarMENSU3()
        {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            var mes = parseInt(document.getElementById("Deuda2").innerText);
            var pago = parseInt(document.getElementById("Cpado2").innerText);
            var cantidad = parseInt(document.getElementById("pagotradi").value);
            var suma = cantidad + pago;
            if (cantidad % 50 === 0) {
                if(mes == suma )
                {
                    fetch('http://localhost:5100/Tarjeta/PagoTradi?numero=' + cardNumber + '&canti=' + suma)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        
                        console.log("Dato recibido desde la API: ", data);
                        
                        document.getElementById("tradicional").style.display = "none";
                        document.getElementById("tradiexitoso").style.display = "block";
                        console.log(suma);
                        
                        
                        // Aquí puedes hacer lo que quieras con el dato recibido
                    })
                    .catch(error => {
                        console.error('There has been a problem with your fetch operation:', error);
                    })
                    
                }
                else
                {
                    alert("tiene que ser igual")
                }
            }
            
        }
    function  PagarMENSU2()
        {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            var mes = parseInt(document.getElementById("Deuda").innerText);
            var pago = parseInt(document.getElementById("Cpado").innerText);
            var cantidad = parseInt(document.getElementById("pagoconti").value);
            var suma = cantidad + pago;
            if (cantidad % 50 === 0) {
                if(mes > suma )
                {
                    fetch('http://localhost:5100/Tarjeta/PagoConti?numero=' + cardNumber + '&canti=' + suma)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        
                        console.log("Dato recibido desde la API: ", data);
                        
                        document.getElementById("opcioncontingente").style.display = "none";
                        document.getElementById("pagocontiexitoso").style.display = "block";
                        console.log(suma);
                        
                        
                        // Aquí puedes hacer lo que quieras con el dato recibido
                    })
                    .catch(error => {
                        console.error('There has been a problem with your fetch operation:', error);
                    })
                    
                }
                else
                {
                    alert("tiene que ser igual")
                }
            }
            
        }
    function menuDeudaestudiante3()
    {
        document.getElementById("opcioncontingente").style.display = "none";
        document.getElementById("deudaestudiante").style.display = "block";
    }

    function menuDeudaestudiante4()
    {
        document.getElementById("pagocontiexitoso").style.display = "none";
        document.getElementById("deudaestudiante").style.display = "block";
    }

    // SCRIPTS DE PAGO DE HIPOTECA Y DE AUTO

    function verhipoteca()
    {
        document.getElementById("menu-credito").style.display = "none";
        document.getElementById("hipoteca").style.display = "block";
    }

    function regremenuC()
    {
        document.getElementById("hipoteca").style.display = "none";
        document.getElementById("menu-credito").style.display = "block";
    }
    


    function pagocompletC()
    {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        
        var cantidadIngresada = parseFloat(document.getElementById('cantidadcompleto1').value);
        var cantidadAPagar = parseFloat(document.getElementById('labelCantidad').textContent);
        
        if (cantidadIngresada === cantidadAPagar )
        {
            fetch('http://localhost:5100/Tarjeta/Pagocredi?numero=' + cardNumber + '&cantidad=' + cantidadIngresada)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    
                    console.log("Dato recibido desde la API: ", data);
                    console.log("Dato recibido desde la API: ", cantidadIngresada);
                     
                    document.getElementById("pagocompleto").style.display = "none";
                    document.getElementById("pagocompletoexitoso").style.display = "block";
                    // Aquí puedes hacer lo que quieras con el dato recibido
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                })
        }
        else
        {
            alert("La cantidad tiene que se exacta")
        }
    }

    function pagoabonoC()
    {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        
        var cantidadIngresada = parseFloat(document.getElementById('cantidadcompleto').value);
        var cantidadAPagar = parseFloat(document.getElementById('Cantidadabo').textContent);
        if(cantidadIngresada<=0)
        {
            alert("No se acepta cantidades negativas")
        }
        else{

        
        if (cantidadIngresada === cantidadAPagar )
        {
            alert("La cantidad no puede ser exacta")
        }
        else
        {
                fetch('http://localhost:5100/Tarjeta/Pagocredi?numero=' + cardNumber + '&cantidad=' + cantidadIngresada)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    
                    console.log("Dato recibido desde la API: ", data);
                    console.log("Dato recibido desde la API: ", cantidadIngresada);
                    
                    document.getElementById("pagoabonos").style.display = "none";
                    document.getElementById("pagoabonosexitoso").style.display = "block";
                    // Aquí puedes hacer lo que quieras con el dato recibido
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                })
        }
    }
        
     }

     function PagarMensualidad() 
        {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/VerpagoC?numero=' + cardNumber)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            
            
            document.getElementById("mesC2").innerText = data.mesC;
            document.getElementById("pagoCapiC2").innerText = data.pagoCapiC;
            
            
            document.getElementById("hipoauto").style.display = "none";
            document.getElementById("pagomensu").style.display = "block";
            
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        })
            

        }

    function  PagarMENSU()
        {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            var mes = parseInt(document.getElementById("mesC2").innerText);
            var pago = parseInt(document.getElementById("pagoCapiC2").innerText);
            var cantidad = parseInt(document.getElementById("cantimensualidad").value);
            var suma = cantidad + pago;
            if (cantidad % 50 === 0) {
                if(mes == suma )
                {
                    fetch('http://localhost:5100/Tarjeta/PagocomC?numero=' + cardNumber + '&canti=' + suma)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        
                        console.log("Dato recibido desde la API: ", data);
                        
                        document.getElementById("pagomensu").style.display = "none";
                        document.getElementById("pagomensuexitoso").style.display = "block";
                        console.log(suma);
                        
                        
                        // Aquí puedes hacer lo que quieras con el dato recibido
                    })
                    .catch(error => {
                        console.error('There has been a problem with your fetch operation:', error);
                    })
                    
                }
                else
                {
                    alert("tiene que ser igual")
                }
            }
            
        }

        
     
     function pagocapital()
     {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/AutoHC?numeroCredito=' + cardNumber)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    
                    console.log("Dato recibido desde la API: ", data);
                    
                    // Actualizar el elemento HTML con el dato recibido
                    document.getElementById("datoAPI").innerText = data;
                    
                    document.getElementById("hipoteca").style.display = "none";
                    document.getElementById("hipoauto").style.display = "block";
                    // Aquí puedes hacer lo que quieras con el dato recibido
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                })

        
     }

     function pagocapital2()
     {
        var cardInput = document.getElementById("cardNumber");
        var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/VerpagoC?numero=' + cardNumber)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            
            console.log("Dato recibido desde la API: ", data);
            
            document.getElementById("mesC").innerText = data.mesC;
            document.getElementById("pagoCapiC").innerText = data.pagoCapiC;
            
            
            document.getElementById("hipoauto").style.display = "none";
            document.getElementById("pagocapital").style.display = "block";
            // Aquí puedes hacer lo que quieras con el dato recibido
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        })
        
     }

     function regrehipoteca()
     {
        document.getElementById("hipoauto").style.display = "none";
        document.getElementById("hipoteca").style.display = "block";
     }

     function regrehipoteca1()
     {
        document.getElementById("pagocapital").style.display = "none";
        document.getElementById("hipoauto").style.display = "block";
     }

     function regrehipoteca3()
     {
        document.getElementById("pagomensualcasa").style.display = "none";
        document.getElementById("hipocasa").style.display = "block";
     }

     function regreauto()
     {
        document.getElementById("pagocapitalexitoso").style.display = "none";
        document.getElementById("hipoteca").style.display = "block";
     }

     function regreauto2()
     {
        document.getElementById("pagomensuexitoso").style.display = "none";
        document.getElementById("hipoteca").style.display = "block";
     }



     function pagarcapital() 
        {   
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            var mes = parseInt(document.getElementById("mesC").innerText);
            var pago = parseInt(document.getElementById("pagoCapiC").innerText);
            var cantidad = parseInt(document.getElementById("canticapital").value);
            var suma = cantidad + pago;
            if (cantidad % 50 === 0) {
                if(mes> suma )
                {
                    fetch('http://localhost:5100/Tarjeta/CapitarC?numero=' + cardNumber + '&canti=' + suma)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        
                        console.log("Dato recibido desde la API: ", data);
                        
                        document.getElementById("pagocapital").style.display = "none";
                        document.getElementById("pagocapitalexitoso").style.display = "block";
                        console.log(suma);
                        
                        
                        // Aquí puedes hacer lo que quieras con el dato recibido
                    })
                    .catch(error => {
                        console.error('There has been a problem with your fetch operation:', error);
                    })
                    
                }
                else
                {
                    alert("la cantida no puede ser mayo o igual")
                }

                // Aquí colocas el código para procesar el pago
                
            } else {
                alert("La cantidad debe ser un múltiplo de 50.");
            }
        }
        PagoAnualidad
        function volverhipoteca()
        {
            document.getElementById("hipocasa").style.display = "none";
            document.getElementById("hipoteca").style.display = "block";
        }


        function verhipocasa()
        {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
        fetch('http://localhost:5100/Tarjeta/casaHC?numeroCredito=' + cardNumber)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    
                    console.log("Dato recibido desde la API: ", data);
                    
                    // Actualizar el elemento HTML con el dato recibido
                    document.getElementById("datoAPI2").innerText = data;
                    
                    document.getElementById("hipoteca").style.display = "none";
                    document.getElementById("hipocasa").style.display = "block";
                    // Aquí puedes hacer lo que quieras con el dato recibido
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                })
           
        }


        function verhipocasa1()
        {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            fetch('http://localhost:5100/Tarjeta/VerpagoH?numero=' + cardNumber)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                
                console.log("Dato recibido desde la API: ", data);
                
                document.getElementById("mesC3").innerText = data.mesH;
                document.getElementById("pagoCapiC3").innerText = data.pagoHipoteca;
                
                
                document.getElementById("hipocasa").style.display = "none";
                document.getElementById("pagocapitalcasa").style.display = "block";
                // Aquí puedes hacer lo que quieras con el dato recibido
            })
            .catch(error => {
                console.error('There has been a problem with your fetch operation:', error);
            })
            
        }

        function verhipocasa2()
        {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            fetch('http://localhost:5100/Tarjeta/VerpagoH?numero=' + cardNumber)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                
                console.log("Dato recibido desde la API: ", data);
                
                document.getElementById("mesC4").innerText = data.mesH;
                document.getElementById("pagoCapiC4").innerText = data.pagoHipoteca;
                
                
                document.getElementById("hipocasa").style.display = "none";
                document.getElementById("pagomensualcasa").style.display = "block";
                // Aquí puedes hacer lo que quieras con el dato recibido
            })
            .catch(error => {
                console.error('There has been a problem with your fetch operation:', error);
            })
            
        }

        function verhipocasa3()
        {
            document.getElementById("pagocapitalcasa").style.display = "none";
            document.getElementById("hipocasa").style.display = "block";
        }

        function pagarcapitalcasa()
        {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            var mes = parseInt(document.getElementById("mesC3").innerText);
            var pago = parseInt(document.getElementById("pagoCapiC3").innerText);
            var cantidad = parseInt(document.getElementById("canticapital").value);
            var suma = cantidad + pago;
            if (cantidad % 50 === 0) {
                if(mes> suma )
                {
                    fetch('http://localhost:5100/Tarjeta/CapitarH?numero=' + cardNumber + '&canti=' + suma)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        
                        console.log("Dato recibido desde la API: ", data);
                        
                        document.getElementById("pagocapitalcasa").style.display = "none";
                        document.getElementById("pagocapitalcasaexito").style.display = "block";
                        console.log(suma);
                        
                        
                        // Aquí puedes hacer lo que quieras con el dato recibido
                    })
                    .catch(error => {
                        console.error('There has been a problem with your fetch operation:', error);
                    })
                    
                }
                else
                {
                    alert("la cantida no puede ser mayo o igual")
                }
            }

            
            
        }

        function verhipocasa4()
        {
            document.getElementById("pagocapitalcasaexito").style.display = "none";
            document.getElementById("hipoteca").style.display = "block";
        }

        function verhipocasa5()
        {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            var mes = parseInt(document.getElementById("mesC3").innerText);
            var pago = parseInt(document.getElementById("pagoCapiC3").innerText);
            var cantidad = parseInt(document.getElementById("cantimensualidad1").value);
            var suma = cantidad + pago;
            if (cantidad % 50 === 0) {
                if(mes == suma )
                {
                    fetch('http://localhost:5100/Tarjeta/PagocomH?numero=' + cardNumber + '&canti=' + suma)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        
                        console.log("Dato recibido desde la API: ", data);
                        
                        document.getElementById("pagomensualcasa").style.display = "none";
                        document.getElementById("pagocasaexitosomes").style.display = "block";
                        console.log(suma);
                        
                        
                        // Aquí puedes hacer lo que quieras con el dato recibido
                    })
                    .catch(error => {
                        console.error('There has been a problem with your fetch operation:', error);
                    })
                    
                }
                else
                {
                    alert("tiene que ser igual")
                }
            }
            
        }
            
        Contingente

        function regrecasa1()
     {
        document.getElementById("pagocasaexitosomes").style.display = "none";
        document.getElementById("hipoteca").style.display = "block";
     }

     function regresarhipo()
        {
            document.getElementById("pagocasaexitosomes").style.display = "none";
            document.getElementById("hipoteca").style.display = "block";
        }

        
        function pagarServicio2() {
            var numServicio = document.getElementById("numeroServicio2").value;
            fetch('http://localhost:5100/Tarjeta/ServicioEX?numeroServicio=' + numServicio)
            .then(response => response.json())
            .then(data => {
                // Imprime la respuesta completa
                console.log('Respuesta del servidor:', data);
    
                // Aquí puedes acceder a los datos individualmente
                const cantidad = data.cantidad;
                const tipoServicio = data.tipoSE;
                // Verificar si los datos existen
                document.getElementById("cantidad-pago2").innerText = cantidad;
                document.getElementById("tipo-servicio-pago2").innerText = tipoServicio;
                console.log("Cantidad:", cantidad);
                console.log("Tipo de Servicio:", tipoServicio);
                document.getElementById("service-menu2").style.display = "none";
                document.getElementById("PAGOS2").style.display = "block";
                
            })
        }

        function serPago2() {
            var cardInput = document.getElementById("cardNumber");
            var cardNumber = cardInput.value;
            var numServicio = document.getElementById("numeroServicio2").value;
            var cantidadIngresada = parseFloat(document.getElementById('CantidaSE').value);
            var cantidadAPagar = parseFloat(document.getElementById('cantidad-pago2').textContent);
            console.log(numServicio)
            console.log(cantidadIngresada)
            console.log(cantidadAPagar)
            if (cantidadIngresada === cantidadAPagar )
            {
            fetch('http://localhost:5100/Tarjeta/PagoS?numero=' + numServicio + '&pago=' + cantidadIngresada +'&Cantotal='+cantidadAPagar)
            .then(response => response.json())
            .then(data => {
                if (data === true) {
                fetch('http://localhost:5100/Tarjeta/Retiro?numeroTarjeta=' + cardNumber + '&Retiros=' + cantidadIngresada)
                document.getElementById("PAGOS2").style.display = "none";
                document.getElementById("servicio-pagadodebito").style.display = "block";
                }
                else{
                   
                    alert("XD");
                    
                }
            })
            }
            else {
               

                alert("La cantida tiene que ser exacta");
                
            }
        }