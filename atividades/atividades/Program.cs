﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividades
{
    class Program
    {
        static void Main(string[] args)
        {
            //atv1();
            //atv2();
            atv3();
            //atv4();
        }

        static void atv1()
        {
            int pos;

            Console.WriteLine("Aperte qualquer coisa para jogar um dado para saber o quanto andou");
            Console.ReadKey();
            Console.WriteLine("");

            Random rand = new Random();
            pos = rand.Next(1, 7);

            if(pos == 1)
            {
                Console.WriteLine("Você andou " + pos + " posição");
            }
            else
            {
                Console.WriteLine("Você andou " + pos + " posições");
            }
            Console.ReadKey();
        }

        static void atv2()
        {
            int escolha, escolha2;
            bool continuar = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Você está em busca de uma lenda de uma cidade perdida");
                Console.WriteLine("Um oraculo da vila em que você acabou de sair te deu uma direção");
                Console.WriteLine("Mas em frente você se depara com 3 caminhos");
                Console.WriteLine("(1) Caminho da esquerda");
                Console.WriteLine("(2) Caminho do meio");
                Console.WriteLine("(3) Caminho da direita");
                int.TryParse(Console.ReadLine(), out escolha);

                continuar = true;

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Você encontrou um rio e precisará cruzá-lo para continuar");
                        Console.WriteLine("(1) Deseja construir uma ponte ou (2) nadar?");
                        break;

                    case 2:
                        Console.WriteLine("Você encontrou uma clareira onde pode descansar e se recuperar");
                        Console.WriteLine("(1) Deseja explorar a clareira ou (2) seguir em frente?");
                        break;

                    case 3:
                        Console.WriteLine("Você encontrou um atalho, mas terá que passar por uma caverna escura e perigosa");
                        Console.WriteLine("(1) Deseja entrar na caverna ou (2) dar a volta pelo caminho mais longo?");
                        break;

                    default:
                        Console.WriteLine("Por favor, digite o número de uma opção valida");
                        continuar = false;
                        break;
                }
                Console.ReadKey();
            } while (continuar == false);

            do
            {
                continuar = true;
                int.TryParse(Console.ReadLine(), out escolha2);

                switch(escolha2)
                {
                    case 1:
                        if(escolha == 1)
                        {
                            Console.WriteLine("Você construiu uma ponte com sucesso e conseguiu atravessar o rio com segurança");
                        }
                        else if(escolha == 2)
                        {
                            Console.WriteLine("Você encontrou uma fonte de água fresca e um arbusto com frutas silvestres");
                        }
                        else if (escolha == 3)
                        {
                            Console.WriteLine("Você enfrentou monstros e armadilhas na caverna, mas conseguiu sair com um tesouro valioso");
                        }
                        break;

                    case 2:
                        if (escolha == 1)
                        {
                            Console.WriteLine("Você tentou nadar, mas foi arrastado pela correnteza e acabou sendo resgatado por um grupo de viajantes");
                        }
                        else if (escolha == 2)
                        {
                            Console.WriteLine("Você seguiu em frente e encontrou um bosque encantado");
                        }
                        else if (escolha == 3)
                        {
                            Console.WriteLine("Você escolheu o caminho mais longo e encontrou um antigo templo abandonado");
                        }
                        break;

                    default:
                        Console.WriteLine("Por favor, digite o número de uma opção valida");
                        continuar = false;
                        break;
                }
                Console.ReadKey();
            } while (continuar == false);
        }

        static void atv3()
        {
            int Cjogo, Cjogador;
            Random rand = new Random();
            Cjogo = rand.Next(1, 4);

            Console.WriteLine("Em direção a cidade perdia você se depara com 3 caminhos, apenas 1 é o correto!");
            Console.WriteLine("(1) Caminho da esquerda");
            Console.WriteLine("(2) Caminho do meio");
            Console.WriteLine("(3) Caminho da direita");
            int.TryParse(Console.ReadLine(), out Cjogador);

            
        }

        static void atv4()
        {

        }
    }
}
