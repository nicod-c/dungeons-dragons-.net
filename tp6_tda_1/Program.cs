using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp6_tda_1
{
    class Program
    {
        // 0- Resolver el ejercicio 6 de la práctica parte 1 y 2 usando clases (Dungeons & dragons).
        class Personaje
        {
            public string nombre;
            public int Fuerza;
            public int Agilidad;
            public int Aguante;
            public int Fuerza_del_Arma;
            public int Peso_del_Arma;
            public int damage;
            public int Total_damage;
        }

        class Enemigo
        {
            public string nombre_enemigo;
            public int Aguante_enemigo;
            public int Agilidad_enemigo;
            public int Escudo_enemigo;
            public int Vida_enemigo;
            public int Defensa_enemigo;
        }


        static int ataque(int Fuerza, int Agilidad, int Peso_del_Arma, int Aguante)
        {
            if (Fuerza < 1 || Fuerza > 10 || Agilidad < 1 || Agilidad > 10 || Peso_del_Arma < 1 || Peso_del_Arma > 10
                || Aguante < 1 || Aguante > 10)
            {
                throw new ArgumentOutOfRangeException("Debes elegir números del 1 al 10");
            }
            int damage;
            damage = (Fuerza + Agilidad) - (Peso_del_Arma % Aguante);
            if (Peso_del_Arma % Fuerza == 0)
                damage = damage + damage * 3 / 100; // bono +%3
            if (Fuerza < Peso_del_Arma)
                damage = damage - damage * 2 / 100; // penalidad -%2
            return damage;
        }

        static int damageAdicional(int damage, int dado_punteria)
        {
            if (dado_punteria % 2 == 0)
                damage += dado_punteria; // suma puntos por número de dado par
            else if (dado_punteria % 2 != 0)
                damage -= dado_punteria; // resta puntos por número de dado impar
            return damage;
        }
        static int DefensaEnemigo(int Aguante_enemigo, int Agilidad_enemigo, int Escudo_enemigo)
        {
            return (Aguante_enemigo * Agilidad_enemigo) + (Escudo_enemigo + Escudo_enemigo / 2);
        }

        static void BendicionDivina(int dado_suerte, ref int Escudo_enemigo)
        {
            if (dado_suerte == 5 | dado_suerte == 6)
            {
                Escudo_enemigo = 0;
                Console.WriteLine($"Recibiste la 'Bendición divina! Tu ataque atravesó el escudo de tu enemigo.");

            }
        }
        static void FinJuego(int Total_damage, int Vida_enemigo)
        {
            if (Total_damage < 0)
            {
                Total_damage = 0;
                Vida_enemigo -= Total_damage;
                Console.WriteLine($"El daño ocasionado a tu enemigo es de {Total_damage}.");
                Console.WriteLine($"La vida de de tu enemigo es {Vida_enemigo}.");
                Console.WriteLine($"No fue sufieciente para ganar esta batalla!");
                Console.WriteLine($"Muchas gracias por jugar Dungeons & Dragons!");
            }
            else if (Total_damage == 0)
            {
                Console.WriteLine($"Tus poderes y los de tu enemigo estan igualados.");
                Console.WriteLine($"Sigue entrenando para vencer a tu enemigo en una futura batalla!");
                Console.WriteLine($"Muchas gracias por jugar Dungeons & Dragons!");
            }
            else
            {
                Vida_enemigo = 0;
                Console.WriteLine($"Ocasionaste un daño de {Total_damage}.");
                Console.WriteLine($"Tu ataque fue crítico.");
                Console.WriteLine($"La vida de tu enemigo es {Vida_enemigo}. Ha muerto!");
                Console.WriteLine($"Ganaste!!");
                Console.WriteLine($"Muchas gracias por jugar Dungeons & Dragons!");
            }
        }

        static void Main(string[] args)
        {

            int dado_punteria;
            int dado_suerte;
            Random rnd = new Random();
         
            Personaje jugador = new Personaje();
            Enemigo cpu = new Enemigo();

            Console.WriteLine("Bienvenid@ a Dungeons & Dragons!");
            Console.Write("Escribe tu nombre: ");
            jugador.nombre = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Hola {jugador.nombre}!");
            Console.WriteLine("Primero necesito que me cuentes, en números del 1 al 10, el nivel de tus poderes...");
            Console.Write("Define tu Fuerza: ");
            jugador.Fuerza = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Define tu Agilidad: ");
            jugador.Agilidad = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Define tu Aguante: ");
            jugador.Aguante = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Define la Fuerza de tu arma: ");
            jugador.Fuerza_del_Arma = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Define el Peso de tu arma: ");
            jugador.Peso_del_Arma = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Muy bien!");
            Console.WriteLine("Ahora vamos a conocer a tu enemigo");
            Console.WriteLine();
            Console.Write("Cómo se llama?: ");
            cpu.nombre_enemigo = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Estos son los poderes de {cpu.nombre_enemigo}...");
            cpu.Aguante_enemigo = rnd.Next(1, 11);
            cpu.Agilidad_enemigo = rnd.Next(1, 11);
            cpu.Escudo_enemigo = rnd.Next(1, 11);
            cpu.Vida_enemigo = rnd.Next(1, 11);
            Console.WriteLine($"Aguante: {cpu.Aguante_enemigo}");
            Console.WriteLine($"Agilidad: {cpu.Agilidad_enemigo}");
            Console.WriteLine($"Escudo: {cpu.Escudo_enemigo}");
            Console.WriteLine($"Vida: {cpu.Vida_enemigo}");
            Console.WriteLine();
            Console.WriteLine($"Es momento de atacar a {cpu.nombre_enemigo}.");
            Console.WriteLine($"Presiona 'Enter' para atacar, {jugador.nombre}!");
            Console.ReadKey();
            jugador.damage = ataque(jugador.Fuerza, jugador.Agilidad, jugador.Peso_del_Arma, jugador.Aguante);
            Console.WriteLine($"Estas atacando");
            Console.WriteLine();
            Console.WriteLine($"Vamos bien, {jugador.nombre}!");
            Console.WriteLine("Para seguir atacando debes lanzar el 'Dado de punteria'. Presiona una tecla");
            Console.ReadKey();
            dado_punteria = rnd.Next(1, 7);
            Console.WriteLine($"Sacaste {dado_punteria}");
            Console.WriteLine("Ahora lanza el 'Dado de suerte'. Presiona una tecla");
            Console.ReadKey();
            dado_suerte = rnd.Next(1, 7);
            Console.WriteLine($"Sacaste {dado_suerte}");
            jugador.damage += damageAdicional(jugador.damage, dado_punteria);
            BendicionDivina(dado_suerte, ref cpu.Escudo_enemigo);
            Console.WriteLine();
            Console.WriteLine($"{jugador.nombre} tu puntaje de ataque es de {jugador.damage}.");
            Console.WriteLine();
            Console.WriteLine($"{cpu.nombre_enemigo} se está defendiendo.");
            cpu.Defensa_enemigo = DefensaEnemigo(cpu.Aguante_enemigo, cpu.Agilidad_enemigo, cpu.Escudo_enemigo);
            Console.WriteLine();
            Console.WriteLine($"El puntaje de defensa de {cpu.nombre_enemigo} es de {cpu.Defensa_enemigo}");
            Console.ReadLine();
            jugador.Total_damage = jugador.damage - cpu.Defensa_enemigo;

            FinJuego(jugador.Total_damage, cpu.Vida_enemigo);

            Console.ReadLine();




        }
    }
}
