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
            Assert.IsNull(_rock.BeatsRock());
            Assert.IsNull(_paper.BeatsPaper());
            Assert.IsNull(_scissor.BeatsScissor());
        }


        [Test]
        public void PlayerCanInputMove()
        {
            var player = new Player {GameMove = _rock};
            Assert.AreEqual(new Rock(), player.GameMove);
        }

        [Test]
        public void PlayerGetsCorrectInputMove()
        {
            var player = new Player {GameMove = _scissor};
            Assert.AreNotEqual(new Rock(), player.GameMove);
        }

        [Test]
        public void PlayerWithRandomMoves()
        {
            var moves = new List<IGameMove>();

            var list = Enumerable.Range(0, 10).ToList();
            list.ForEach(i => moves.Add(AiPlayer.Create().GameMove));
            
            Assert.Contains(_rock, moves);
            Assert.Contains(_scissor, moves);
            Assert.Contains(_paper, moves);

        }


        [Test]
        public void KeepRunnigScore()
        {
            var player1 = new Player {GameMove = _paper};
            var player2 = new Player{GameMove = _rock};

            player1.Vs(player2);

            Assert.AreEqual(1, player1.GetScore());
            //Assert.AreEqual(0, player2.GetScore());
        }
    }

    public static class AiPlayer
    {
        private static readonly IGameMove[] AvailableMoves = {new Paper(), new Rock(), new Scissor()};
        private static readonly Random Random = new Random();
        
        public static Player Create()
        {
            var next = Random.Next(0, AvailableMoves.Length);
            return new Player{GameMove = AvailableMoves[next]};
        }
    }

    public class Player
    {
        private int _score;
        public IGameMove GameMove { get; set; }

        public int GetScore()
        {
            return  _score;
        }

        public void Vs(Player player2)
        {
            var res = GameMove.Beats(player2.GameMove);
            if (res.GetValueOrDefault())
            {
                _score = _score + 1;
            }
        }
    }


    public interface IGameMove
    {
        bool? BeatsPaper();
        bool? BeatsRock();
        bool? BeatsScissor();
        bool? Beats(IGameMove move);
    }

    public class Scissor : IGameMove, IEquatable<Scissor>
    {
        public bool? BeatsPaper()
        {
            return true;
        }

        public bool? BeatsRock()
        {
            return false;
        }

        public bool? BeatsScissor()
        {
            return null;
        }

        public bool? Beats(IGameMove move)
        {
            return !move.BeatsScissor();
        }

        public bool Equals(Scissor other)
        {
            return true;
        }
    }


    public class Paper : IGameMove, IEquatable<Paper>
    {
        public bool? BeatsRock()
        {
            return true;
        }

        public bool? BeatsScissor()
        {
            return false;
        }

        public bool? Beats(IGameMove move)
        {
            return !move.BeatsPaper();
        }

        public bool? BeatsPaper()
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
        public bool? BeatsScissor()
        {
            return true;
        }

        public bool? Beats(IGameMove move)
        {
            return !move.BeatsRock();
        }

        public bool? BeatsPaper()
        {
            return false;
        }

        public bool? BeatsRock()
        {
            return null;
        }

        public bool Equals(Rock other)
        {
            return true;
        }
    }
}