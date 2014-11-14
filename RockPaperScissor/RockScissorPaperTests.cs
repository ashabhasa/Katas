using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RockPaperScissor
{
    [TestFixture]
    public class RockScissorPaperTests
    {
        private Rock _rock;
        private Scissor _scissor;
        private Paper _paper;

        [SetUp]
        public void Setup()
        {
             _rock = new Rock();
             _scissor = new Scissor();
             _paper = new Paper();
        }

        [Test]
        public void RockBeatsScissorTest()
        {
            Assert.IsTrue(_rock.Beats(_scissor).Value);
            Assert.IsFalse(_scissor.Beats(_rock).Value);
        }

        [Test]
        public void ScissorsBeatPaperTest()
        {
            Assert.IsTrue(_scissor.Beats(_paper).Value);
            Assert.IsFalse(_paper.Beats(_scissor).Value);
        }


        [Test]
        public void PaperBeatsRock()
        {
            Assert.IsTrue(_paper.Beats(_rock).Value);
            Assert.IsFalse(_rock.Beats(_paper).Value);
        }
        
        [Test]
        public void SameMoveIsDraw()
        {
            Assert.IsNull(_rock.Beats(new Rock()));
            Assert.IsNull(_paper.Beats(new Paper()));
            Assert.IsNull(_scissor.Beats(new Scissor()));
        }


        [Test]
        public void PlayerCanInputMove()
        {
            var player1 = new Player(new Rock());
            Assert.AreEqual(new Rock(), player1.GetMove());
        }

        [Test]
        public void PlayerGetsCorrectInputMove()
        {
            var player2 = new Player(new Scissor());
            Assert.AreNotEqual(new Rock(), player2.GetMove());
        }

        [Test]
        public void PlayerWithRandomMoves()
        {
            var moves = new List<IGameMove>();

            var list = Enumerable.Range(0, 10).ToList();
            list.ForEach(i => moves.Add(AiPlayer.Create().GetMove()));
            
            Assert.Contains(new Rock(), moves);
            Assert.Contains(new Scissor(), moves);
            Assert.Contains(new Paper(), moves);

        }
    }

    public static class AiPlayer
    {
        private static readonly IGameMove[] AvailableMoves = {new Paper(), new Rock(), new Scissor()};
        private static readonly Random Random = new Random();
        
        public static Player Create()
        {
            var next = Random.Next(0, AvailableMoves.Length);
            return new Player(AvailableMoves[next]);
        }
    }

    public class Player
    {
        private readonly IGameMove _gMove;

        public Player(IGameMove gMove)
        {
            _gMove = gMove;
        }

        public IGameMove GetMove()
        {
            return _gMove;
        }
    }


    public interface IGameMove
    {
        bool? Beats(Paper paper);
        bool? Beats(Rock rock);
        bool? Beats(Scissor scissor);
    }

    public class Scissor : IGameMove, IEquatable<Scissor>
    {
        public bool? Beats(Paper paper)
        {
            return true;
        }

        public bool? Beats(Rock rock)
        {
            return false;
        }

        public bool? Beats(Scissor scissor)
        {
            return null;
        }

        public bool Equals(Scissor other)
        {
            return true;
        }
    }


    public class Paper : IGameMove, IEquatable<Paper>
    {
        public bool? Beats(Rock rock)
        {
            return true;
        }

        public bool? Beats(Scissor scissor)
        {
            return false;
        }

        public bool? Beats(Paper paper)
        {
            return null;
        }

        public bool Equals(Paper other)
        {
            return true;
        }
    }

    public class Rock : IGameMove, IEquatable<Rock>
    {
        public bool? Beats(Scissor scissor)
        {
            return true;
        }

        public bool? Beats(Paper paper)
        {
            return false;
        }

        public bool? Beats(Rock rock)
        {
            return null;
        }

        public bool Equals(Rock other)
        {
            return true;
        }
    }
}