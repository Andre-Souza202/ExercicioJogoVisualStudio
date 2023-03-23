using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioJogo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;
            int vida, classe, posicao, vidaInimigo, opc, danoFixo, dano, precisao, pocVida, pocPrecisao ;
            bool continuar = false;

            Console.Clear();
            posicao = 1;
            vidaInimigo = 14;
            vida = 0;
            danoFixo = 0;
            precisao = 0;
            pocVida = 2;
            pocPrecisao = 1;

            Console.WriteLine("Olá aventureiro, qual o seu nome?");
            nome = Console.ReadLine();

            do
            {
                continuar = false;
                Console.WriteLine("Qual a sua classe? [1 cavalaria, 2 infantaria]");
                int.TryParse(Console.ReadLine(), out classe);
                if (classe == 1)
                {
                    //cavalaria
                    continuar = true;
                    vida = 12;
                    danoFixo = 3;
                    precisao = 5;
                }
                else if (classe == 2)
                {
                    //infantaria
                    continuar = true;
                    vida = 18;
                    danoFixo = 2;
                    precisao = 7;
                }
            } while (continuar == false);

            do
            {
                do
                {
                    Console.Clear();
                    if (classe == 1)
                    {
                        Console.WriteLine("Montado em seu cavalo você segue por um caminho estreito pela montanha, até que a frente você vê uma pilha de ossos, quando você começa a se aproximar a pilha de ossos " +
                            "começam a flutuar e formam um esqueleto do mau! você precisa derrota-lo se quiser continuar seu caminho");
                        Console.WriteLine("");
                    }
                    else if (classe == 2)
                    {
                        Console.WriteLine("Andando por um caminho estreito pela montanha com sua confiante espada, você se depara a frente com uma pilha de ossos, quando você começa a se aproximar a pilha de ossos " +
    "começam a flutuar e formam um esqueleto do mau! você precisa derrota-lo se quiser continuar seu caminho");
                        Console.WriteLine("");
                    }

                    Mapa(posicao);

                    Console.WriteLine("Sua vida: " + vida);
                    Console.WriteLine("Vida do inimigo: " + vidaInimigo);
                    Console.WriteLine("");

                    continuar = false;
                    Console.WriteLine("Escolha sua ação!");
                    Console.WriteLine("1 Andar");
                    Console.WriteLine("2 Atacar");
                    Console.WriteLine("3 Usar item");
                    int.TryParse(Console.ReadLine(), out opc);
                    switch (opc)
                    {
                        case 1:
                            if (posicao < 4)
                            {
                                if (classe == 1)
                                {
                                    posicao = 4;
                                }
                                else if (classe == 2)
                                {
                                    posicao = posicao + 1;
                                }
                                continuar = true;
                            }
                            else
                            {
                                Console.WriteLine("Você já está frente a frente com o inimigo");
                                continuar = false;
                            }
                            break;

                        case 2:
                            if (posicao >= 4)
                            {
                                Random rand = new Random();
                                int acertou = rand.Next(1, 11);
                                if (acertou <= precisao && acertou != 10)
                                {
                                    Random rand2 = new Random();
                                    dano = rand2.Next(1, 4) + danoFixo;
                                    vidaInimigo = vidaInimigo - dano;
                                    Console.WriteLine(nome + " você acertou ele em cheio causando " + dano + " de dano! vida do inimigo restante: " + vidaInimigo);
                                }
                                else
                                {
                                    Console.WriteLine(nome + " o inimigo desvia do seu ataque, você não causou nenhum dano");
                                }

                                continuar = true;
                            }
                            else
                            {
                                Console.WriteLine("Você precisa andar até o inimigo primeiro");
                                continuar = false;
                            }
                            break;

                        case 3:
                            Console.WriteLine("");
                            Console.WriteLine("1 Poções de vida, restauram 5 pontos de saúde x" + pocVida);
                            Console.WriteLine("2 Poções de precisão, aumenta durante toda a batalha a precisão do usuário x" + pocPrecisao);
                            Console.WriteLine("3 Voltar");
                            int.TryParse(Console.ReadLine(), out opc);

                            switch(opc)
                            {
                                case 1:
                                    if(pocVida > 0)
                                    {
                                        pocVida--;
                                        vida = vida + 5;
                                        Console.WriteLine(nome + "você toma uma poção de vida e se sente revigorado + 5 vida, sua vida agora é " + vida);
                                        continuar = true;
                                    }
                                    break;

                                case 2: 
                                    if(pocPrecisao > 0)
                                    {
                                        pocPrecisao--;
                                        precisao = precisao + 3;
                                        Console.WriteLine(nome + " você toma uma poção de precisão e se sente mais focado, sua precisão aumentou");
                                        continuar = true;
                                    }
                                    break;

                                case 3:
                                    continuar = false;
                                    break;

                                default:
                                    Console.WriteLine("Escolha uma opção válida");
                                    continuar = false;
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Escolha uma opção válida");
                            continuar = false;
                            break;
                    }
                    Console.ReadKey();
                } while (continuar == false);

                //Ação do inimigo
                Random rand3 = new Random();
                int acertou2 = rand3.Next(1, 11);

                if(acertou2 <= 7)
                {
                    Random rand4 = new Random();
                    dano = rand4.Next(2, 6);
                    vida = vida - dano;
                    Console.WriteLine(nome + " o inimigo te acertou, causando " + dano + " de dano, você agora está com " + vida + " de vida");
                }
                else
                {
                    Console.WriteLine(nome + " você consegue desviar do ataque do inimigo, não recebendo nenhum dano!");
                }
                Console.ReadKey();

            } while (vidaInimigo > 0 && vida > 0);

            Console.WriteLine("");
            if(vida <= 0 && vidaInimigo > 0)
            {
                Console.WriteLine(nome + " você sucumbiu aos seus ferimentos, sua visão escurece e sua aventura acaba aqui");
            }
            else if(vida > 0 && vidaInimigo <= 0)
            {
                Console.WriteLine(nome + " com um golpe de espada poderoso o inimigio é derrubado, o resultado é claro, o oponente foi derrotado, você agora pode continuar sua aventura");
            }
            else
            {
                Console.WriteLine(nome + " com um golpe de espada poderoso o inimigo é derrubado, mas você está muito ferido, sua visão escurece e sua aventura acaba aqui");
            }
            Console.ReadKey();
        }

        static void Mapa(int posicao)
        {
            Console.WriteLine("--------------------------------");
            switch(posicao)
            {
                case 1:
                    Console.WriteLine("O......()......()......()......ç");
                    Console.WriteLine("|......()......()......()......l");
                    Console.WriteLine("^......()......()......()......V");
                    break;
                case 2:
                    Console.WriteLine("()......O......()......()......ç");
                    Console.WriteLine("()......|......()......()......l");
                    Console.WriteLine("()......^......()......()......V");
                    break;
                case 3:
                    Console.WriteLine("()......()......O......()......ç");
                    Console.WriteLine("()......()......|......()......l");
                    Console.WriteLine("()......()......^......()......V");
                    break;
                case 4:
                    Console.WriteLine("()......()......()......O......ç");
                    Console.WriteLine("()......()......()......|......l");
                    Console.WriteLine("()......()......()......^......V");
                    break;
                default:
                    break;
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
        }
    }
}
