using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioJogo
{
    class Jogador
    {
		public string nome { get; set; }
		public int classe { get; set; }
		public int vidaMaxima { get; set; }
		public int vidaAtual { get; set; }
		public int dano { get; set; }
		public int precisao { get; set; }
		public int posicao { get; set; }
        public int pocVida { get; set; }
        public int pocPrecisao { get; set; }
    }

    class Inimigo
    {
        public int vida { get; set; }
		public int danoMin { get; set; }
        public int danoMax { get; set; }
		public int precisao { get; set; }
		public int posicao { get; set; }
		public int tipo { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Jogador jogador = new Jogador();
            infoJogador(jogador);

            Lutar(jogador, 1);
            Lutar(jogador, 2);
        }

        static void Lutar(Jogador jogador, int tipoInimigo)
        {
            int opc, dano;
            bool continuar = false;

            Inimigo inimigo = new Inimigo();
            inimigo.tipo = tipoInimigo;
            infoInimigo(inimigo);

            Console.Clear();
            jogador.posicao = 1;

            do
            {
                do
                {
                    Console.Clear();
                    hisLutar(jogador, tipoInimigo);

                    Mapa(jogador.posicao);
                    Hud(jogador, inimigo);

                    continuar = false;
                    Console.WriteLine(" Escolha sua ação!");
                    Console.WriteLine(" 1 Andar");
                    Console.WriteLine(" 2 Atacar");
                    Console.WriteLine(" 3 Usar item");
                    int.TryParse(Console.ReadLine(), out opc);
                    switch (opc)
                    {
                        case 1:
                            if (jogador.posicao < 4)
                            {
                                if (jogador.classe == 1)
                                {
                                    jogador.posicao = 4;
                                }
                                else if (jogador.classe == 2)
                                {
                                    jogador.posicao = jogador.posicao + 1;
                                }
                                continuar = true;
                            }
                            else
                            {
                                Console.WriteLine(" Você já está frente a frente com o inimigo");
                                continuar = false;
                            }
                            break;

                        case 2:
                            if (jogador.posicao >= 4)
                            {
                                Random rand = new Random();
                                int acertou = rand.Next(1, 11);
                                if (acertou <= jogador.precisao && acertou != 10)
                                {
                                    Random rand2 = new Random();
                                    dano = rand2.Next(1, 4) + jogador.dano;
                                    inimigo.vida = inimigo.vida - dano;
                                    Console.WriteLine(" " + jogador.nome + " você acertou ele em cheio causando " + dano + " de dano! vida do inimigo restante: " + inimigo.vida);
                                }
                                else
                                {
                                    Console.WriteLine(" " + jogador.nome + " o inimigo desvia do seu ataque, você não causou nenhum dano");
                                }

                                continuar = true;
                            }
                            else
                            {
                                Console.WriteLine(" Você precisa andar até o inimigo primeiro");
                                continuar = false;
                            }
                            break;

                        case 3:
                            Console.WriteLine("");
                            Console.WriteLine(" 1 Poções de vida, restauram 5 pontos de saúde x" + jogador.pocVida);
                            Console.WriteLine(" 2 Poções de precisão, aumenta durante toda a batalha a precisão do usuário x" + jogador.pocPrecisao);
                            Console.WriteLine(" 3 Voltar");
                            int.TryParse(Console.ReadLine(), out opc);

                            switch(opc)
                            {
                                case 1:
                                    if(jogador.pocVida > 0)
                                    {
                                        jogador.pocVida--;
                                        jogador.vidaAtual = jogador.vidaAtual + 5;
                                        Console.WriteLine(" " + jogador.nome + "você toma uma poção de vida e se sente revigorado + 5 vida, sua vida agora é " + jogador.vidaAtual);
                                        continuar = true;
                                    }
                                    break;

                                case 2: 
                                    if(jogador.pocPrecisao > 0)
                                    {
                                        jogador.pocPrecisao--;
                                        jogador.precisao = jogador.precisao + 3;
                                        Console.WriteLine(" " + jogador.nome + " você toma uma poção de precisão e se sente mais focado, sua precisão aumentou");
                                        continuar = true;
                                    }
                                    break;

                                case 3:
                                    continuar = false;
                                    break;

                                default:
                                    Console.WriteLine(" Escolha uma opção válida");
                                    continuar = false;
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine(" Escolha uma opção válida");
                            continuar = false;
                            break;
                    }
                    Console.ReadKey();
                } while (continuar == false);

                //Ação do inimigo
                Random rand3 = new Random();
                int acertou2 = rand3.Next(1, 11);

                if(acertou2 <= inimigo.precisao)
                {
                    Random rand4 = new Random();
                    dano = rand4.Next(inimigo.danoMin, inimigo.danoMax + 1);
                    jogador.vidaAtual = jogador.vidaAtual - dano;
                    Console.WriteLine(" " + jogador.nome + " o inimigo te acertou, causando " + dano + " de dano, você agora está com " + jogador.vidaAtual + " de vida");
                }
                else
                {
                    Console.WriteLine(" " + jogador.nome + " você consegue desviar do ataque do inimigo, não recebendo nenhum dano!");
                }
                Console.ReadKey();

            } while (inimigo.vida > 0 && jogador.vidaAtual > 0);

            Console.WriteLine("");
            if(jogador.vidaAtual <= 0 && inimigo.vida > 0)
            {
                Console.WriteLine(" " + jogador.nome + " você sucumbiu aos seus ferimentos, sua visão escurece e sua aventura acaba aqui");
            }
            else if(jogador.vidaAtual > 0 && inimigo.vida <= 0)
            {
                Console.WriteLine(" " + jogador.nome + " com um golpe de espada poderoso o inimigio é derrubado, o resultado é claro, o oponente foi derrotado, você agora pode continuar sua aventura");
            }
            else
            {
                Console.WriteLine(" " + jogador.nome + " com um golpe de espada poderoso o inimigo é derrubado, mas você está muito ferido, sua visão escurece e sua aventura acaba aqui");
            }
            Console.ReadKey();
        }

        static void infoInimigo(Inimigo inimigo)
        {
            switch(inimigo.tipo)
            {
                case 1:
                    inimigo.vida = 14;
                    inimigo.danoMin = 2;
                    inimigo.danoMax = 5;
                    inimigo.precisao = 7;
                    inimigo.posicao = 5;
                    break;

                case 2:
                    inimigo.vida = 20;
                    inimigo.danoMin = 2;
                    inimigo.danoMax = 5;
                    inimigo.precisao = 7;
                    inimigo.posicao = 5;
                    break;
            }
        }

        static void hisLutar(Jogador jogador, int tipoInimigo)
        {
            switch(tipoInimigo)
            {
                case 1:
                    if (jogador.classe == 1)
                    {
                        Console.WriteLine(" Montado em seu cavalo você segue por um caminho estreito pela montanha, até que a frente você vê uma pilha de ossos, quando você começa a se aproximar a pilha de ossos " +
                        "começam a flutuar e formam um esqueleto do mau! você precisa derrota-lo se quiser continuar seu caminho");
                        Console.WriteLine("");
                    }
                    else if (jogador.classe == 2)
                    {
                        Console.WriteLine(" Andando por um caminho estreito pela montanha com sua confiante espada, você se depara a frente com uma pilha de ossos, quando você começa a se aproximar a pilha de ossos " +
                        "começam a flutuar e formam um esqueleto do mau! você precisa derrota-lo se quiser continuar seu caminho");
                        Console.WriteLine("");
                    }
                    break;

                case 2:
                    break;
            }
        }

        static void Mapa(int posicao)
        {
            Console.WriteLine(" ===========================================");
            switch(posicao)
            {
                case 1:
                    Console.WriteLine(" |  O ......'''......'''......'''...... P  |");
                    Console.WriteLine(" | /|\\......'''......'''......'''....../|) |");
                    Console.WriteLine(" | / \\......'''......'''......'''......[|] |");
                    break;
                case 2:
                    Console.WriteLine(" | '''...... O ......'''......'''...... P  |");
                    Console.WriteLine(" | '''....../|\\......'''......'''....../|) |");
                    Console.WriteLine(" | '''....../ \\......'''......'''......[|] |");
                    break;
                case 3:
                    Console.WriteLine(" | '''......'''...... O ......'''...... P  |");
                    Console.WriteLine(" | '''......'''....../|\\......'''....../|) |");
                    Console.WriteLine(" | '''......'''....../ \\......'''......[|] |");
                    break;
                case 4:
                    Console.WriteLine(" | '''......'''......'''...... O ...... P  |");
                    Console.WriteLine(" | '''......'''......'''....../|\\....../|) |");
                    Console.WriteLine(" | '''......'''......'''....../ \\......[|] |");
                    break;
                default:
                    break;
            }
            Console.WriteLine(" ===========================================");
            Console.WriteLine("");
        }

        static void Hud(Jogador jogador, Inimigo inimigo)
        {
            string Jprec, Iprec;

            if (jogador.precisao >= 0 && jogador.precisao <= 2)
            {
                Jprec = "Muito baixa";
            }
            else if(jogador.precisao >= 3 && jogador.precisao <= 4)
            {
                Jprec = "Baixa";
            }
            else if(jogador.precisao >= 5 && jogador.precisao <= 6)
            {
                Jprec = "Média";
            }
            else if(jogador.precisao >= 7 && jogador.precisao <= 8)
            {
                Jprec = "Alta";
            }
            else if(jogador.precisao >= 9)
            {
                Jprec = "Muito alta";
            }
            else
            {
                Jprec = "Impossivel de acertar";
            }

            if(inimigo.precisao >= 0 && inimigo.precisao <= 2)
            {
                Iprec = "Muito baixa";
            }
            else if(inimigo.precisao >= 3 && inimigo.precisao <= 4)
            {
                Iprec = "Baixa";
            }
            else if(inimigo.precisao >= 5 && inimigo.precisao <= 6)
            {
                Iprec = "Média";
            }
            else if(inimigo.precisao >= 7 && inimigo.precisao <= 8)
            {
                Iprec = "Alta";
            }
            else if(inimigo.precisao >= 9)
            {
                Iprec = "Muito alta";
            }
            else
            {
                Iprec = "Impossivel de acertar";
            }

            Console.WriteLine(" JOGADOR || Vida: " + jogador.vidaAtual + " || Precisão: " + Jprec);
            Console.WriteLine(" INIMIGO || Vida: " + inimigo.vida + " || Precisão: " + Iprec);
            Console.WriteLine("");
        }

        static void infoJogador(Jogador jogador)
        {
            bool continuar = false;

            jogador.pocVida = 2;
            jogador.pocPrecisao = 1;

            Console.WriteLine(" Olá aventureiro, qual o seu nome?");
            jogador.nome = Console.ReadLine();

            do
            {
                continuar = false;
                Console.WriteLine(" Qual a sua classe? [1 cavalaria, 2 infantaria]");
                int classe;
                int.TryParse(Console.ReadLine(), out classe);
                jogador.classe = classe;
                if (jogador.classe == 1)
                {
                    //cavalaria
                    continuar = true;
                    jogador.vidaAtual = 12;
                    jogador.dano = 3;
                    jogador.precisao = 5;
                }
                else if (jogador.classe == 2)
                {
                    //infantaria
                    continuar = true;
                    jogador.vidaAtual = 18;
                    jogador.dano = 2;
                    jogador.precisao = 7;
                }
            } while (continuar == false);
        }

    }
}
