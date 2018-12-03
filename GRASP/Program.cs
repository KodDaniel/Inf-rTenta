using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Här ska man kunna:
            // Välja spelare
            // Välja vilken piece (spelpjäs) för respektive spelare  
            var game = new MonopolyGame();


        }
    }

    public class MonopolyGame
    {
        public List<Player> Players { get; set; }

        private int _roundCnt;
        private int _rounds = 10;

        public void PlayGame()
        {
            while (_roundCnt < _rounds)
            {
                PlayRound();
                _roundCnt++;
            }

        }

        public void PlayRound()
        {
            foreach (var player in Players)
            {
                player.TakeTurn();
            }
        }
    }
    public class Board
    {
        // Enligt LRG bör Board känna till alla sina rutor.
        //Enligt Expert blir därför Board ansvarigt för att känna till:
        //– den nya rutans läge givet den gamla rutans läge samt
        //– utfallet från tärningskastet
        public List<Square> Squares { get; set; }

        public List<Square> GetAllSquares()
        {
            return Squares;
        }

        public Square GetSquare(string name)
        {
            throw new NotImplementedException();

        }

    }
    public class Square
    {
        public string Name { get; set; }
    }

    public class Piece
    {
        // Enligt LRG bör piece (pjäsen) känna till sin ruta (square)
        // • Enligt Expert skall därför pjäsen (piece) hitta sin nya placering. Information om  den nya placeringen kan den få från sin ägare (player)
        public string Name { get; set; }
        public Square Square { get; set; }


    }

    public class Player
    {
        public string Name { get; set; }
        // Visibility: Om Player koordinerar stegen krävs objektreferenser till Die, Board och Piece
        // Enligt LRG bör spelaren (player) känna till sin pjäs(piece)
        private Die _die = new Die();
        private Board _board = new Board();
        private Piece _piece = new Piece();


        public void TakeTurn()
        {
            // • Beräkna ett slumptal mellan 2 och 12 (räckvidden för ett tärningskast med två tärningar)
            // LRG ger anledning att skapa ett  Tärningsobjekt(Die) med ett faceValue attribut.
            // Att beräkna ett nytt slumptal innebär att ändra information i Die, så • Expert medför att Die skall kunna kasta sig själv(generera nytt slumptal)

            var fv = _die.FaceValue;
            _die.Roll();
            fv = _die.FaceValue;

            // Beräkna nästa ruta
            // Förflytta pjäsen från den gamla rutan till den nya
        }


    }

    public class Die
    {
        public int FaceValue { get; private set; }

        // Varför inte låta ”roll” returnera sitt eget värde?
        // Skulle strida mot CQS-principen
        public void Roll()
        {
            FaceValue = new Random().Next(2, 12);
        }

    }
}
