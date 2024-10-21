// ROLETA RUSSA

using System;
using System.Collections.Generic;

int p1=0;
int p2=0;

inicio:

string[] cartas = {"Rainha","Rainha","Rainha","Rei","Rei","Rei","As","As","As","Joker"};
Random.Shared.Shuffle(cartas);
int[] cartucho = {0,0,0,0,0,0};
int[] array = { 0, 1, 2, 3, 4, 5 };
Random.Shared.Shuffle(array);
String[] mesa = {"As", "Rainha","Rei"};
Random.Shared.Shuffle(mesa);

string[] player1 = {cartas[0],cartas[1],cartas[2],cartas[3],cartas[4]};
string[] player2 = {cartas[5],cartas[6],cartas[7],cartas[8],cartas[9]};

String cartaMesa = mesa[2];
Boolean estadoCarta = true;  //Se é ou não a carta da mesa

int numeroRandom = array[2];
cartucho[numeroRandom] = 1;
int estado = 0; //0 = vivo  ||  1 = morto



bool Disparar(ref int player, ref int estado, int[] cartucho){
    if(player<=5 & estado != 1){

        Console.WriteLine("Desconfias-te mal! CLICA ENTER PARA DISPARAR!");
        Console.ReadLine();

    if(cartucho[player]==1){
      Console.WriteLine("MORRESTE NA "+ (player+1) + "ª BALA!!");
      estado = 1;
      return false;
    }else{
      Console.WriteLine("SAFASTE-TE!! "+ (player+1) + "/6");
      player++;
      Console.WriteLine("---------------------------------------");

      return true;
    }
}else{
  Console.WriteLine("Desconfias-te bem!");

  return true;
}

}





//----------------PLAYER 1----------------

anterior:
for(int z=0;z<player1.Length;z++){


Console.WriteLine("MESA DE " + cartaMesa);

//mostra cartas do player1
Console.WriteLine("PLAYER 1");
for(int j=0;j<player1.Length;j++)
    Console.WriteLine(player1[j]);

List<String> lista = new List<String>(player1);

Console.WriteLine("Que carta queres jogar? Ou Desconfias?");
String cartaJogada = Console.ReadLine();

if(cartaJogada=="Desconfio" & estadoCarta==true){
if(!Disparar(ref p2, ref estado, cartucho))
{
    goto end;
}else{
    goto inicio;
}

}

if(cartaJogada==cartaMesa & lista.Contains(cartaJogada) || cartaJogada=="Joker" & lista.Contains(cartaJogada)){
  estadoCarta=true;
}else{
  estadoCarta=false;
}

if(lista.Contains(cartaJogada)){
    lista.Remove(cartaJogada);
    player1 = lista.ToArray();

}else{
Console.WriteLine("A carta que queres jogar não existe");
z=z-1;

Console.WriteLine("---------------------------------------");

goto anterior;
}

Console.WriteLine("---------------------------------------");

goto seguinte;

}

//----------------PLAYER 2----------------

seguinte:
for(int z=0;z<player2.Length;z++){

Console.WriteLine("MESA DE " + cartaMesa);

//mostra cartas do player2
Console.WriteLine("PLAYER 2");
for(int j=0;j<player2.Length;j++)
    Console.WriteLine(player2[j]);

List<String> lista = new List<String>(player2);

Console.WriteLine("Que carta queres jogar? Ou Desconfias?");
String cartaJogada = Console.ReadLine();


if(cartaJogada=="Desconfio" & estadoCarta==true){

if(!Disparar(ref p1, ref estado, cartucho))
{
    goto end;
}else{
    goto inicio;
}

}



if(cartaJogada==cartaMesa || cartaJogada=="Joker" & lista.Contains(cartaJogada)){
  estadoCarta=true;
}else{
  estadoCarta=false;
}

if(lista.Contains(cartaJogada)){
    lista.Remove(cartaJogada);
    player2 = lista.ToArray();

}else{
Console.WriteLine("A carta que queres jogar não existe");
z=z-1;

Console.WriteLine("---------------------------------------");

goto seguinte;
}

Console.WriteLine("---------------------------------------");

goto anterior;

}

end:

Console.WriteLine("PERDESTE!!");

