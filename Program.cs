//Hockey
class Metodos
{
    public void Titulo(string texto, int ancho_Pantalla)
    {
        Console.WriteLine($"{texto.PadLeft(((ancho_Pantalla - texto.Length) / 2) + texto.Length)}\n");
    }

    public (int, int) Choque_jugador(List<(int jugador_1_EjeX, int jugador_1_EjeY)> jugador_1, List<(int jugador_2_EjeX, int jugador_2_EjeY)> jugador_2, int X, int Y, int EjeX, int EjeY)
    {
        foreach (var posicion in jugador_1)
        {
            //Adelante
            if (X == posicion.jugador_1_EjeX && (Y > jugador_1.Min(posicion => posicion.jugador_1_EjeY) && Y < jugador_1.Max(posicion => posicion.jugador_1_EjeY))) 
            {
                EjeX = new Random().Next(0, 2); // 0 o 1
                if (EjeX == 0)
                {
                    do
                    {
                        EjeY = new Random().Next(-1, 2); // -1 o 1
                    } while (EjeY == 0);
                }
                else
                    EjeY = new Random().Next(-1, 2); // -1 a 1 
                return (EjeX, EjeY);
            }
            //Atras
            else if (X == posicion.jugador_1_EjeX - 1 && (Y >= jugador_1.Min(posicion => posicion.jugador_1_EjeY) && Y < jugador_1.Max(posicion => posicion.jugador_1_EjeY)))
            {
                EjeX = new Random().Next(-1, 1); // -1 o 0
                if (EjeX == 0)
                {
                    do
                    {
                        EjeY = new Random().Next(-1, 2); // -1 o 1
                    } while (EjeY == 0);
                }
                else
                    EjeY = new Random().Next(-1, 2); // -1 a 1 
                return (EjeX, EjeY);
            }
            else if (posicion == (X, Y))
            {
                //Arriba
                if(posicion.jugador_1_EjeX == X && Y <= jugador_1.Min(posicion => posicion.jugador_1_EjeY))
                {
                    EjeY = -1;
                    EjeX = new Random().Next(-1,2); //-1 a 1
                    return (EjeX, EjeY);
                }
                //Abajo
                else if (posicion.jugador_1_EjeX == X && jugador_1.Max(posicion => posicion.jugador_1_EjeY) == Y)
                {
                    EjeY = 1;
                    EjeX = new Random().Next(-1, 2); //-1 a 1
                    return (EjeX, EjeY);
                }
            }
        }
        foreach(var posicion in jugador_2)
        {
            //Adelante
            if (X == posicion.jugador_2_EjeX && (Y > jugador_2.Min(posicion => posicion.jugador_2_EjeY) && Y < jugador_2.Max(posicion => posicion.jugador_2_EjeY)))
            {
                EjeX = new Random().Next(-1, 1); // -1 o 0
                if (EjeX == 0)
                {
                    do
                    {
                        EjeY = new Random().Next(-1, 2); // -1 o 1
                    } while (EjeY == 0);
                }
                else
                    EjeY = new Random().Next(-1, 2); // -1 a 1 
                return (EjeX, EjeY);
            }
            //Atras
            else if (X == posicion.jugador_2_EjeX - 1 && (Y >= jugador_2.Min(posicion => posicion.jugador_2_EjeY) && Y < jugador_2.Max(posicion => posicion.jugador_2_EjeY)))
            {
                EjeX = new Random().Next(0, 2); // 0 o 1
                if (EjeX == 0)
                {
                    do
                    {
                        EjeY = new Random().Next(-1, 2); // -1 o 1
                    } while (EjeY == 0);
                }
                else
                    EjeY = new Random().Next(-1, 2); // -1 a 1 
                return (EjeX, EjeY);
            }
            else if (posicion == (X, Y))
            {
                //Arriba
                if (posicion.jugador_2_EjeX == X && Y <= jugador_2.Min(posicion => posicion.jugador_2_EjeY))
                {
                    EjeY = -1;
                    EjeX = new Random().Next(-1, 2); //-1 a 1
                    return (EjeX, EjeY);
                }
                //Abajo
                else if (posicion.jugador_2_EjeX == X && jugador_2.Max(posicion => posicion.jugador_2_EjeY) == Y)
                {
                    EjeY = 1;
                    EjeX = new Random().Next(-1, 2); //-1 a 1
                    return (EjeX, EjeY);
                }
            }
        }
        return (0,0);
    }
    public int velocidad_Juego(int velocidad_inicial)
    {
        int velocidad_Juego = 0;
        Console.Clear();
        Console.Write($"Bienvenido a la Configuración\nLa velocidad inicial esta en {velocidad_inicial}\nIngrese la velocidad inicial que desea para jugar:");
        int.TryParse(Console.ReadLine(), out velocidad_Juego);
        velocidad_inicial = velocidad_Juego > 0 ? velocidad_Juego : velocidad_inicial;
        Console.WriteLine($"La velocidad inicial quedo en {velocidad_inicial}");
        Console.ReadKey();
        return velocidad_Juego;
    }

    public (int, int, int, int, int, int) movimiento_Pelota(int ancho_Pantalla, int largo_Pantalla, int direcion_Inicial_Pelota_EjeX, int direcion_Inicial_Pelota_EjeY, List<(int pelota_EjeX, int pelota_EjeY)> pelota, int EjeX, int EjeY,int espacio, int espacion_Tablero,int puntos_Jugador1, int puntos_Jugador2, List<(int jugador_1_EjeX, int jugador_1_EjeY)> jugador_1, List<(int jugador_2_EjeX, int jugador_2_EjeY)> jugador_2)
    {
        var nueva_posicion = pelota[0];
        int X = 0; int Y = 0;
        string mensaje = "Punto para el Jugador 1";

        //Direccion de Pelota hasta LLegar al Eje  X y Y
        if ((pelota[0].pelota_EjeX > 1 && pelota[0].pelota_EjeX < ancho_Pantalla -1) && (pelota[0].pelota_EjeY >= 3 && pelota[0].pelota_EjeY <= (int)Math.Ceiling(largo_Pantalla / 1.5) + 2)) 
        {
            //Continuar mimsa Direccion
            X = nueva_posicion.pelota_EjeX + direcion_Inicial_Pelota_EjeX;
            Y = nueva_posicion.pelota_EjeY + direcion_Inicial_Pelota_EjeY;
            (int redirecionX,int redirecionY) = new Metodos().Choque_jugador(jugador_1, jugador_2, X, Y, EjeX, EjeY);
            if (redirecionX != 0 || redirecionY != 0)
            {
                direcion_Inicial_Pelota_EjeX = redirecionX;
                direcion_Inicial_Pelota_EjeY = redirecionY;
                X = nueva_posicion.pelota_EjeX + direcion_Inicial_Pelota_EjeX;
                Y = nueva_posicion.pelota_EjeY + direcion_Inicial_Pelota_EjeY;
            }
            return (X, Y, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2);
        }
        //Direccion X inferior
        if (pelota[0].pelota_EjeX == 1)
        {
            //Esquina Superior Izquierda
            if (pelota[0].pelota_EjeY == 3)
            {
                EjeX = new Random().Next(0, 2); // 0 o 1
                if (EjeX == 0)
                    EjeY = 1;
                else
                    EjeY = new Random().Next(0, 2); // 0 a 1 
            }
            //Esquina Inferior Izquierda
            else if (pelota[0].pelota_EjeY == ((largo_Pantalla / 1.5) + 2))
            {
                EjeX = new Random().Next(0, 2); // 0 o 1
                if (EjeX == 0)
                    EjeY = -1;
                else
                    EjeY = new Random().Next(-1, 1);
            }
            //Izquierda sin Esquinas
            else 
            {
                //Punto de Jugador 2
                if (EjeX == 1 &&  EjeY >= espacio && EjeY <= (espacio + espacion_Tablero))
                {
                    puntos_Jugador2 += 1;
                    X = ancho_Pantalla / 2; Y = Convert.ToInt32(largo_Pantalla * 0.4);
                    direcion_Inicial_Pelota_EjeX = 0; direcion_Inicial_Pelota_EjeY = 0;

                    Console.SetCursorPosition((ancho_Pantalla - mensaje.Length)/2,(largo_Pantalla - 3)/2);
                    Console.WriteLine(mensaje); Thread.Sleep(3000);
                    return (X, Y, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2);
                }
                
                EjeX = new Random().Next(0, 2); // 0 o 1
                if (EjeX == 0)
                {
                    do
                    {
                        EjeY = new Random().Next(-1, 2); // -1 o 1
                    } while (EjeY == 0);
                }
                else
                    EjeY = new Random().Next(-1, 2); // -1 a 1 
            }
            direcion_Inicial_Pelota_EjeX = EjeX;
            direcion_Inicial_Pelota_EjeY = EjeY;
            X = nueva_posicion.pelota_EjeX + direcion_Inicial_Pelota_EjeX;
            Y = nueva_posicion.pelota_EjeY + direcion_Inicial_Pelota_EjeY;
            return (X, Y, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2);
        }
        //Direccion X Superior
        else if (pelota[0].pelota_EjeX == ancho_Pantalla - 1)
        {
            //Esquina Superior Derecha
            if (pelota[0].pelota_EjeY == 2)
            {
                EjeX = new Random().Next(-1, 1); // -1 o 0

                if (EjeX == 0)
                    EjeY = 1;
                else
                    EjeY = new Random().Next(0, 2); // 0 a 1 
            }
            //Esquina Inferior Derecha
            else if (pelota[0].pelota_EjeY == ((largo_Pantalla / 1.5) + 3))
            {
                EjeX = new Random().Next(-1, 1); // -1 o 0

                if (EjeX == 0)
                    EjeY = -1;
                else
                    EjeY = new Random().Next(-1, 1);
            }
            // Derecha sin esquinas
            else
            {
                //Punto de Jugador 2
                if (EjeX == ancho_Pantalla -1 && EjeY >= espacio && EjeY <= (espacio + espacion_Tablero))
                {
                    puntos_Jugador1 += 1;
                    X = ancho_Pantalla / 2; Y = Convert.ToInt32(largo_Pantalla * 0.4);
                    direcion_Inicial_Pelota_EjeX = 0; direcion_Inicial_Pelota_EjeY = 0;
                    
                    Console.SetCursorPosition((ancho_Pantalla - mensaje.Length) / 2, (largo_Pantalla - 3) / 2);
                    Console.WriteLine(mensaje); Thread.Sleep(3000);
                    return (X, Y, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2);
                }

                EjeX = new Random().Next(-1, 1); // -1 o 0
                if (EjeX == 0)
                {
                    do
                    {
                        EjeY = new Random().Next(-1, 2); // -1 o 1
                    } while (EjeY == 0);
                }
                else
                    EjeY = new Random().Next(-1, 2); // -1 a 1 
            }
            direcion_Inicial_Pelota_EjeX = EjeX;
            direcion_Inicial_Pelota_EjeY = EjeY;
            X = nueva_posicion.pelota_EjeX + direcion_Inicial_Pelota_EjeX;
            Y = nueva_posicion.pelota_EjeY + direcion_Inicial_Pelota_EjeY;
            return (X, Y, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2);
        }
        //Direccion Y Superior
        else if (pelota[0].pelota_EjeY == 2)
        {
            EjeX = new Random().Next(-1, 2); // -1 a 1

            if (EjeX == 0)
                EjeY = 1;
            else
                EjeY = new Random().Next(0, 2); // 0 o 1 

            direcion_Inicial_Pelota_EjeX = EjeX;
            direcion_Inicial_Pelota_EjeY = EjeY;
            X = nueva_posicion.pelota_EjeX + direcion_Inicial_Pelota_EjeX;
            Y = nueva_posicion.pelota_EjeY + direcion_Inicial_Pelota_EjeY;
            return (X, Y, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2);
        }
        //Direccion Y Inferior
        else if (pelota[0].pelota_EjeY == (int)Math.Ceiling(largo_Pantalla / 1.5) + 3) 
        {
            EjeX = new Random().Next(-1, 2); // -1 a 1

            if (EjeX == 0)
                EjeY = -1;
            else
                EjeY = new Random().Next(-1, 1); // -1 o 0

            direcion_Inicial_Pelota_EjeX = EjeX;
            direcion_Inicial_Pelota_EjeY = EjeY;
            X = nueva_posicion.pelota_EjeX + direcion_Inicial_Pelota_EjeX;
            Y = nueva_posicion.pelota_EjeY + direcion_Inicial_Pelota_EjeY;
            return (X, Y, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2);
        }
        return (X, Y, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2);
    }
}
class Programa
{
    public static void Main()
    {
        int velocidad_Inicial = 100;
        while (true)
        {
            //Variables Internas
            string titulo = "Hockey de Mesa";
            int ancho_Pantalla = Console.WindowWidth;
            int largo_Pantalla = Console.WindowHeight;
            

            //Monitoreo de Tamaño de Pantalla
            Thread Monitor_Tamaño_Thread = new Thread(() => new Programa().Monitor_Tamaño(ancho_Pantalla, largo_Pantalla));
            Monitor_Tamaño_Thread.Start();

            //Menu Principal
            Console.Clear();
            new Metodos().Titulo(titulo, ancho_Pantalla);
            Console.WriteLine($"1. Jugar \n2. Configurar \n3. Salir");
            Console.Write("Ingrese su respuesta:");

            switch (Console.ReadLine().ToLower().Trim())
            {
                case "jugar":
                    {
                        Console.WriteLine("Vamos a jugar");
                        new Programa().Juego(titulo, largo_Pantalla, ancho_Pantalla, velocidad_Inicial);
                        break;
                    }
                case "configurar":
                    {
                        Console.WriteLine("Configuración");
                        velocidad_Inicial = new Metodos().velocidad_Juego(velocidad_Inicial);
                        break;
                    }
                case "salir":
                    {
                        System.Environment.Exit(0);
                        break;
                    }
            }
        }
    }
    
    public void Juego(string titulo, int largo_Pantalla, int ancho_Pantalla, int velociad_Inicial)
    {
        int largo_Antiguo = 0; int ancho_Antiguo = 0;
        int direcion_Inicial_Pelota_EjeX = 0; int direcion_Inicial_Pelota_EjeY = 0;
        bool juego = true;
        int EjeX = 0; int EjeY = 0;
        int espacio = Convert.ToInt32(((Console.WindowHeight / 1.5) / 3) * 1.5);
        int espacio_Tablero = Convert.ToInt32((Console.WindowHeight / 1.5) / 3);
        int puntos_Jugador1 = 0; int puntos_Jugador2 = 0;

        //Posicionamineto Inicial
        List<(int jugador_1_EjeX, int jugador_1_EjeY)> jugador_1 = new List<(int jugador_1_EjeX, int jugador_1_EjeY)>();
        for (int i = 0; i < espacio_Tablero - 2; i++)
            jugador_1.Add((9, espacio + i));

        List<(int jugador_2_EjeX, int jugador_2_EjeY)> jugador_2 = new List<(int jugador_2_EjeX, int jugador_2_EjeY)>(); 
        for (int i = 0; i < espacio_Tablero - 2; i++)
            jugador_2.Add((Console.WindowWidth - (Convert.ToInt32(Console.WindowWidth * 0.096)), (espacio) + i));

        List<(int pelota_EjeX, int pelota_EjeY)> pelota = new List<(int pelota_EjeX, int pelota_EjeY)>();
        pelota.Add((ancho_Pantalla / 2, Convert.ToInt32(largo_Pantalla * 0.4)));
        var nueva_posicion = pelota[0];
        try
        {
            while (juego)
            {
                largo_Pantalla = Console.WindowHeight;
                ancho_Pantalla = Console.WindowWidth;

                if (largo_Antiguo != 0 || ancho_Antiguo != 0)
                    if (largo_Pantalla != largo_Antiguo || ancho_Pantalla != ancho_Antiguo)
                    {
                        Console.ReadKey();
                        juego = false;
                        new Programa().Juego(titulo, largo_Pantalla, ancho_Pantalla, velociad_Inicial);
                    }

                //Pantalla
                Console.Clear();
                new Metodos().Titulo(titulo, ancho_Pantalla);

                Console.WriteLine(new string('-', ancho_Pantalla));
                for (int i = 0; i < (largo_Pantalla / 1.5); i++)
                    Console.WriteLine(i >= espacio_Tablero && i <= espacio_Tablero * 2 ? "" : $"|{"".PadRight(ancho_Pantalla - 2)}|");
                Console.WriteLine(new string('-', ancho_Pantalla));

                Console.WriteLine($"Jugador 1 = {puntos_Jugador1}".PadLeft(Convert.ToInt32(ancho_Pantalla * 0.175)).PadRight(Convert.ToInt32(ancho_Pantalla * 0.816)) + $"Jugador 2 = {puntos_Jugador2}");
                Console.WriteLine("\nPresione la tecla \"P\" para parar el juego \nPresione la tecla \"E\" salir del juego \nPresione la tecla \"I\" para iniciar el juego");

                //Jugador 1
                foreach (var posicion in jugador_1)
                {
                    Console.SetCursorPosition(posicion.jugador_1_EjeX, posicion.jugador_1_EjeY);
                    Console.WriteLine("|");
                }
                //Jugador 2
                foreach (var posicion in jugador_2)
                {
                    Console.SetCursorPosition(posicion.jugador_2_EjeX, posicion.jugador_2_EjeY);
                    Console.WriteLine("|");
                }
                //Pelota
                Console.SetCursorPosition(pelota[0].pelota_EjeX, pelota[0].pelota_EjeY);
                Console.WriteLine("*");
                
                (EjeX, EjeY,direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, puntos_Jugador1, puntos_Jugador2) = new Metodos().movimiento_Pelota(ancho_Pantalla, largo_Pantalla, direcion_Inicial_Pelota_EjeX, direcion_Inicial_Pelota_EjeY, pelota, EjeX, EjeY,espacio, espacio_Tablero, puntos_Jugador1, puntos_Jugador2, jugador_1, jugador_2);
                nueva_posicion.pelota_EjeX = EjeX;
                nueva_posicion.pelota_EjeY =EjeY;
                pelota[0] = nueva_posicion;

                Thread.Sleep(velociad_Inicial);

                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                if (jugador_2[0].jugador_2_EjeY >= 4)
                                    for (int i = 0; i < jugador_2.Count; i++)
                                    {
                                        var nueva = jugador_2[i];
                                        nueva.jugador_2_EjeY -= 1;
                                        jugador_2[i] = nueva;
                                    }
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (jugador_2[jugador_2.Count - 1].jugador_2_EjeY <= (int)Math.Ceiling(largo_Pantalla / 1.5) + 1)
                                    for (int i = 0; i < jugador_2.Count; i++)
                                    {
                                        var nueva = jugador_2[i];
                                        nueva.jugador_2_EjeY += 1;
                                        jugador_2[i] = nueva;
                                    }
                                break;
                            }
                        case ConsoleKey.W:
                            {
                                if (jugador_1[0].jugador_1_EjeY >= 4)
                                    for (int i = 0; i < jugador_1.Count; i++)
                                    {
                                        var nueva = jugador_1[i];
                                        nueva.jugador_1_EjeY -= 1;
                                        jugador_1[i] = nueva;
                                    }
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                if (jugador_1[jugador_1.Count - 1].jugador_1_EjeY <= (int)Math.Ceiling(largo_Pantalla / 1.5) + 1)
                                    for (int i = 0; i < jugador_1.Count; i++)
                                    {
                                        var nueva = jugador_1[i];
                                        nueva.jugador_1_EjeY += 1;
                                        jugador_1[i] = nueva;
                                    }
                                break;
                            }
                        case ConsoleKey.P:
                            {
                                Console.ReadKey();
                                break;
                            }
                        case ConsoleKey.I:
                            {
                                do
                                {
                                    direcion_Inicial_Pelota_EjeX = (new Random()).Next(-1, 2); direcion_Inicial_Pelota_EjeY = (new Random()).Next(-1, 2);
                                } while (direcion_Inicial_Pelota_EjeX == 0 || direcion_Inicial_Pelota_EjeY == 0);
                                var movimineto_Inicial_Pelota = pelota[0];
                                movimineto_Inicial_Pelota.pelota_EjeX += direcion_Inicial_Pelota_EjeX;
                                movimineto_Inicial_Pelota.pelota_EjeY += direcion_Inicial_Pelota_EjeY;
                                pelota[0] = movimineto_Inicial_Pelota;
                                break;
                            }
                        case ConsoleKey.E:
                            {
                                juego = false;
                                break;
                            }
                    }
                }
                largo_Antiguo = largo_Pantalla; ancho_Antiguo = ancho_Pantalla;
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.ReadKey();
            new Programa().Juego(titulo, largo_Pantalla, ancho_Pantalla,velociad_Inicial);
        }
    }
    public void Monitor_Tamaño(int ancho_Pantalla, int largo_Pantalla)
    {
        while (true)
        {
            if (Console.WindowWidth != ancho_Pantalla || Console.WindowHeight != largo_Pantalla)
            {
                Console.Clear();
                Console.WriteLine("\nEl tamaño de la pantalla se cambio se cambio");
                ancho_Pantalla = Console.WindowWidth; largo_Pantalla = Console.WindowHeight;
                Thread.Sleep(2000); Console.Clear();
                Console.WriteLine("Presione Cualquier tecla para continuar");
            }
            Thread.Sleep(500);
        }
    }
}