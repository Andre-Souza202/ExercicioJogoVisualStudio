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

        public int coragem { get; set; }
        public int furtividade { get; set; }
        public int vontade { get; set; }
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
            jogador.vidaAtual = 12;
            jogador.dano = 2;
            jogador.precisao = 7;

            Historia(jogador, 1);

            Lutar(jogador, 1);

            Historia(jogador, 2);

            //infoJogador(jogador);
        }

        static void Historia(Jogador jogador, int sequencia)
        {
            int opc;
            bool continuar = false;

            switch(sequencia)
            {
                case 1:
                    do
                    {
                        continuar = true;
                        Console.Clear();
                        Console.WriteLine(" Você acorda, ouvindo gritos do lado de fora");
                        Console.WriteLine(" Se levantando, você vai até a porta e a abre levemente");
                        Console.WriteLine(" Olhando cuidadosamente, você vê um grupo de esqueletos morto-vivos");
                        Console.WriteLine(" Rapidamente você fecha a porta e se afasta");
                        Console.WriteLine(" Esqueletos morto-vivos... são criaturas malignas, você precisa sair da vila ou eles vão te encontrar");
                        Console.WriteLine(" De repente começam a bater na sua porta, batidas fortes, ela vai ser derrubada em breve");
                        Console.WriteLine("");
                        Console.WriteLine("(1) Emboscar");
                        Console.WriteLine("(2) Se esconder");
                        Console.WriteLine("(3) Fortificar porta");
                        int.TryParse(Console.ReadLine(), out opc);
                        switch(opc)
                        {
                            case 1:
                                Console.WriteLine(" Você rapidamente pega uma faca e se posiciona ao lado da porta");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine(" A porta... cai, um ser formado apenas por um esqueleto entra");
                                Console.WriteLine(" Você estava preparado e ataca a criatura com sua faca");
                                Console.WriteLine(" O dano causado é minimo, mas é o suficiente para te dar a oportunidade de correr");
                                Console.WriteLine(" Você corre em direção para fora da vila");
                                Console.WriteLine("");
                                Console.WriteLine(" Coragem +");
                                Console.WriteLine(" Furtividade -");
                                jogador.coragem++;
                                jogador.furtividade--;
                                break;

                            case 2:
                                Console.WriteLine(" Você se esconde em baixo da cama, fingindo que não ah ninguem em casa");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine(" A porta... cai, um ser formado apenas por um esqueleto entra");
                                Console.WriteLine(" Você está escondido, e torce para que a criatura não te encontre");
                                Console.WriteLine(" A criatura anda pela casa, até que chega ao seu quarto, olhando em volta, mas não encontra nada");
                                Console.WriteLine(" A criatura sai de sua casa, mas é muito perigoso continuar aqui");
                                Console.WriteLine(" Você sai de seu esconderijo, e de sua casa, indo em direção para sair da vila");
                                Console.WriteLine("");
                                Console.WriteLine(" Coragem -");
                                Console.WriteLine(" Furtividade +");
                                jogador.coragem--;
                                jogador.furtividade++;
                                break;

                            case 3:
                                Console.WriteLine(" Usando tudo que você pode encontrar, você bloqueou a porta");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine(" A porta... permanece intacta, quem quer que seja que estava batendo parou");
                                Console.WriteLine(" Você ouve murmurios indecifraveis e logo em seguida passos, se afastando da porta");
                                Console.WriteLine(" Ele provavelmente vai chamar reforços, você desfaz toda a barricada e sai, antes que ele volte");
                                Console.WriteLine("");
                                Console.WriteLine(" Vontade +");
                                jogador.vontade++;
                                break;

                            default:
                                Console.WriteLine(" Escolha uma opção valida");
                                continuar = false;
                                break;
                        }
                        Console.ReadKey();
                    } while(continuar == false);

                     continuar = true;
                     Console.Clear();
                     Console.WriteLine(" Você continua seguindo para fora da vila, consegue ver a floresta, está quase la");
                     Console.WriteLine(" Mas logo em frente na direção da floresta, você vê um dos esqueletos, com uma espada infincada em uma pessoa");
                     Console.WriteLine(" Ele termina sua vitima e se vira, olhando diretamente para você");
                     Console.WriteLine(" Você corre para outra direção, com o inimigo na sua cola, ele está determinado a te pegar");
                     Console.WriteLine(" Com o caos que está acontecendo, você se encontra em um caminho sem saida, se virando, o esqueleto andando lentamente até você");
                     Console.WriteLine(" Alguém te chama, você olha em volta, é o ferreiro da vila, segurando uma porta aberta te chamando para entrar correndo");
                     Console.WriteLine(" Logo quando você entra e o ferreiro vai fechar a porta, a espada do esqueleto atinge o ferreiro, causando graves ferimentos");
                     Console.WriteLine(" O esqueleto vai em sua direção, você pega uma espada que estava em uma das estandes");
                     Console.ReadKey();
                     jogador.posicao = 4;
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine(" O esqueleto cai, seu corpo levemente brilha, e logo em seguida desaparece em pó");
                    Console.WriteLine(" Você se vira ao ferreiro machucado no chão, vai até ele e o ajuda a levantar, levando até um lugar onde ele possa deitar");
                    Console.WriteLine(" Ele te aponta onde encontrar as ervas de vida, e você as busca");
                    Console.WriteLine(" Ferreiro - Obrigado, qual o seu nome?");
                    jogador.nome = Console.ReadLine();
                    Console.WriteLine(" Ferreiro Gary - O meu é Gary, você se da bem com espadas pelo que vi ali atrás, não é " + jogador.nome + "?");
                    Console.WriteLine(" Você responde com uma leve mechida de cabeça, lembrando de seu passado");
                    Console.WriteLine("");
                    Console.WriteLine("(1) Eu Fazia parte da guarda real, tenho treinamento com espada, mas isso já faz muito tempo");
                    Console.WriteLine("(Precisão: Alta || Velocidade: Baixa || Dano: Médio || Defesa: Alta)");
                    Console.WriteLine("");
                    Console.WriteLine("(2) Eu era usado por um grupo de ladrões que roubavam caravanas quando eu era um adolescente, mas fugi quando tive uma oportunidade");
                    Console.WriteLine("(Precisão: Média || Velocidade: Alta || Dano: Alto) || Defesa: Baixa");
                    Console.WriteLine("");
                    Console.WriteLine("(3) Meu pai me ensinou, ele era muito bom nisso, sinto saudades dele");
                    Console.WriteLine("(Precisão: Média || Velocidade: Média || Dano: Médio) || Defesa: Média");
                    Console.WriteLine("");

                    break;
                }
            
        }

        static void Lutar(Jogador jogador, int tipoInimigo)
        {
            int opc, dano;
            bool continuar = false;

            Inimigo inimigo = new Inimigo();
            inimigo.tipo = tipoInimigo;
            infoInimigo(inimigo);

            Console.Clear();

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
                                    Console.WriteLine(" Você acertou ele em cheio causando " + dano + " de dano! vida do inimigo restante: " + inimigo.vida);
                                }
                                else
                                {
                                    Console.WriteLine(" O inimigo desvia do seu ataque, você não causou nenhum dano");
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
                                        Console.WriteLine(" Você toma uma poção de vida e se sente revigorado + 5 vida, sua vida agora é " + jogador.vidaAtual);
                                        continuar = true;
                                    }
                                    break;

                                case 2: 
                                    if(jogador.pocPrecisao > 0)
                                    {
                                        jogador.pocPrecisao--;
                                        jogador.precisao = jogador.precisao + 3;
                                        Console.WriteLine(" Você toma uma poção de precisão e se sente mais focado, sua precisão aumentou");
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
                if(inimigo.vida > 0)
                {
                    if(acertou2 <= inimigo.precisao )
                    {
                        Random rand4 = new Random();
                        dano = rand4.Next(inimigo.danoMin, inimigo.danoMax + 1);
                        jogador.vidaAtual = jogador.vidaAtual - dano;
                        Console.WriteLine(" O inimigo te acertou, causando " + dano + " de dano, você agora está com " + jogador.vidaAtual + " de vida");
                    }
                    else
                    {
                        Console.WriteLine(" Você consegue desviar do ataque do inimigo, não recebendo nenhum dano!");
                    }
                
                    Console.ReadKey();
                }
            } while (inimigo.vida > 0 && jogador.vidaAtual > 0);

            Console.WriteLine("");
            if(jogador.vidaAtual <= 0 && inimigo.vida > 0)
            {
                Console.WriteLine(" Você sucumbiu aos seus ferimentos, sua visão escurece e sua aventura acaba aqui");
            }
            else if(jogador.vidaAtual > 0 && inimigo.vida <= 0)
            {
                Console.WriteLine(" Com um golpe de espada poderoso o inimigio é derrubado, o resultado é claro, o oponente foi derrotado");
                Console.WriteLine(" Você agora pode continuar sua aventura");
            }
            Console.ReadKey();
        }

        static void infoInimigo(Inimigo inimigo)
        {
            switch(inimigo.tipo)
            {
                case 1:
                    inimigo.vida = 8;
                    inimigo.danoMin = 1;
                    inimigo.danoMax = 3;
                    inimigo.precisao = 6;
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
                    Console.WriteLine("Em uma vila sendo destruida, você enpunha uma espada contra um esqueleto");
                    Console.WriteLine("O ferreiro machucado, e um sonho ainda não realizado");
                    Console.WriteLine("Acabe com ele, ou ele acaba com você");
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
