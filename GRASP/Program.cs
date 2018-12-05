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
          
            //  Main är mitt UI-lager. Alla övriga klasser är mitt applikationslager. 
            var game = new MonopolyGame();
            var james = new Player("James",new Piece("Dog",new Square("Startruta",0)));
            var linda = new  Player("Linda",new Piece("Horse", new Square("Startruta", 0)));
            game.Players.Add(james);
            game.Players.Add(linda);    
            game.PlayGame();
          
        }
    }

    // MonopolGame är en klass som är min Controller. En Controller avgör HUR UI-lagret kopplas till applikationslogik-lagret.
    // Ett vanligt val för Controller är klassen som är en rot-klass/objekt, dvs den klass/objekt som representerar så många andra klasser...
    ///...i applikationslagret som möjligt. MonopolyGame är en sådan klass.  
    public class MonopolyGame
    {
        // I föreläsning står: MonopolyGame är ett slags rot-objekt som innesluter de flesta andra domänobjekten.
        public List<Player> Players { get; set; }
        public List<Piece> Pieces { get;}
        public Board Board { get;}
        public Die Die { get;}
       

        // När vi instansierar ett Game instansierar vi listan Players, annars kan vi ej fylla den från UI. 
        // När vi instansierar ett Game borde vi också ha ett antal fördefinierade spelpjäser. De är alltid samma och därför fylls de i applikatoinslagret.
        // Player väljer sedan ett av dessa innan spelstart.
        public MonopolyGame()
        {
            Players = new List<Player>();
            //Pieces = new List<Piece> {new Piece("Dog"), new Piece("Hat"), new Piece("Cat"),new Piece("Fish")};
            Board = new Board();
            Die = new Die();
        }

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
        private List<Square> Squares;

        public Board()
        {
            Squares = new List<Square>
            {
                new Square("Ruta 1",1), new Square("Ruta 2",2), new Square("Ruta 3",3),new Square("Ruta 4",4),new Square("Ruta 5",5),
                new Square("Ruta 6",6),new Square("Ruta 7",7), new Square("Ruta 8",8), new Square("Ruta 9",9), new Square("Ruta 10", 10),
                new Square("Ruta 11", 11), new Square("Ruta 12", 12), new Square("Ruta 13",13), new Square("Ruta 14",14)
            };


        }
                    
        // Board har kunskap om alla Squares. Därför ska också Board-klassen ha denna metod.
        public List<Square> GetAllSquares()
        {
            return Squares;
        }

        // Board har kunskap om alla Squares. Därför ska också Board-klassen ha denna metod.
        public Square GetSquare(int oldLocation, int faceValue)
        {
            int newLocation = oldLocation + faceValue;

            return Squares.Where(a => a.Location == newLocation).Single();
            
        }
        
            
    }
    public class Square
    {
        public string Name { get; }
        public int Location { get; set; }

        public Square(string name, int location)
        {
            this.Name = name;
            this.Location = location;
        }
        
    }

    public class Piece
    {
        public string Name { get;}
        // och pjäsen sin ruta (square)
        public Square Square { get; set; }


        public Piece(string name, Square square)
        {
            this.Name = name;
            this.Square = square;
        }

        //public Square GetLocation(i)
        //{

        //}

    }

    public class Player
    {
        // Enligt LRG bör spelaren (player) känn till sin pjäs(piece) 
        public string Name { get;}
        public Piece Piece { get; set; }

        public Player(string name, Piece piece)
        {
            this.Name = name;
            this.Piece = piece;
        }

        private Die _die = new Die();

        // Denna metod ska innehålla logik för:
        //  1. Beräkna ett slumptal mellan 2 och 12 (räckvidden för ett tärningskast med två tärningar)
        // 2. Beräkna nästa ruta
        // 3. // Förflytta pjäsen från den gamla rutan till den nya
        public void TakeTurn()
        {
            #region Steg 1
            var fv = _die.FaceValue;
            _die.Roll();
            fv = _die.FaceValue; 


            #endregion
        }

    }

    public class Die
    {
        
        public int FaceValue { get; private set; }

        public Die()
        {
            // Default-värdet för en int är 0. Undviker Null-exception
            FaceValue = 0;
        }

        // Varför inte låta ”roll” returnera sitt eget värde?
        // Skulle strida mot CQS-principen
        public void Roll()
        {
            FaceValue = new Random().Next(2, 12);
        }

    }
}
