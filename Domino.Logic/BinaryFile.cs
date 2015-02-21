using Domino.Logic.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Domino.Logic
{
    public class BinaryFile : IDatabase
    {
        public BinaryReader CounterReader;
        public BinaryWriter CounterWriter;
        public BinaryReader GameReader;
        public BinaryWriter GameWriter;
        public List<PlayerStatistics> Statistics;
        private FileStream _streamCounter;
        private FileStream _streamGame;

        public BinaryFile()
        {
            Statistics = new List<PlayerStatistics>();
            const string fileGameName = "Games.txt";
            const string filePlayerCounter = "Counter.txt";
            InitGameFile(fileGameName);
            InitCounterFile(filePlayerCounter);
        }

        public void Save(List<PlayerGameStatistics> players)
        {
            if (IsEmpty())
            {
                InitCounterToAmountPlayer(players.Count);
                foreach (PlayerGameStatistics t in players)
                {
                    GameWriter.Write(t.PlayerName);
                    if (t.IsWinner)
                        WriteWhenPlayerWin(GameWriter);
                    else
                        WriteWhenPlayerLose(GameWriter);
                }
            }
            else
            {
                FillAllPlayersStatistics();
                for (int i = 0; i < players.Count; i++)
                {
                    PlayerStatistics playerStatistics = FindPlayer(players[i].PlayerName);
                    if (playerStatistics != null)
                    {
                        UpdateStatistics(players[i].IsWinner, playerStatistics);
                    }
                    else
                    {
                        Statistics.Add(players[i].GetInitialPlayerStatistics());
                        AddNewPlayerCounterFile();
                    }
                }

                WriteUpdatedStatitics(GameWriter);
            }

            GameWriter.Flush();
            _streamGame.Flush();
            CounterWriter.Flush();
            _streamCounter.Flush();
        }

        public PlayerStatistics GetPlayerStatistics(string playerName)
        {
            Statistics.Clear();
            FillAllPlayersStatistics();
            return FindPlayer(playerName);
        }

        public List<PlayerStatistics> GetAllPlayerStatistics()
        {
            Statistics.Clear();
            FillAllPlayersStatistics();
            return Statistics;
        }

        private void AddNewPlayerCounterFile()
        {
            int amountPlayer = GetAmountPlayers();
            amountPlayer += 1;
            _streamCounter.Position = 0;
            CounterWriter.Write(amountPlayer);
        }

        private void InitGameFile(string fileGameName)
        {
            _streamGame = new FileStream(fileGameName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            GameWriter = new BinaryWriter(_streamGame);
            GameReader = new BinaryReader(_streamGame);
        }

        private void InitCounterFile(string filePlayerCounter)
        {
            _streamCounter = new FileStream(filePlayerCounter, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            CounterWriter = new BinaryWriter(_streamCounter);
            CounterReader = new BinaryReader(_streamCounter);
        }

        private PlayerStatistics FindPlayer(string playerName)
        {
            for (int i = 0; i < Statistics.Count; i++)
            {
                if (playerName == Statistics[i].PlayerName)
                    return Statistics[i];
            }
            return null;
        }

        private void InitCounterToAmountPlayer(int count)
        {
            CounterWriter.Write(count);
        }

        private void FillAllPlayersStatistics()
        {
            int amountPlayersOnFile = GetAmountPlayers();
            _streamGame.Position = 0;
            for (int i = 0; i < amountPlayersOnFile; i++)
            {
                Statistics.Add(FillStatistics(GameReader));
            }
        }

        private int GetAmountPlayers()
        {
            _streamCounter.Position = 0;
            return CounterReader.ReadInt32();
        }

        public void Close()
        {
            _streamGame.Close();
            _streamCounter.Close();
            GameWriter.Close();
            GameReader.Close();
            CounterReader.Close();
            CounterWriter.Close();
        }

        private void WriteUpdatedStatitics(BinaryWriter writer)
        {
            _streamGame.SetLength(0);
            _streamGame.Flush();
            foreach (PlayerStatistics t in Statistics)
            {
                writer.Write(t.PlayerName);
                writer.Write(t.Wins);
                writer.Write(t.Losses);
            }
        }

        public void AddToStatiticsList(BinaryReader reader, string playerName, bool gano)
        {
            PlayerStatistics statistics = FillStatistics(reader);
            UpdateStatistics(gano, statistics);
            Statistics.Add(statistics);
        }

        private static void UpdateStatistics(bool isWinner, PlayerStatistics statistics)
        {
            if (isWinner)
                statistics.Wins++;
            else
                statistics.Losses++;
        }

        private void WriteWhenPlayerLose(BinaryWriter writer)
        {
            writer.Write(0);
            writer.Write(1);
        }

        private void WriteWhenPlayerWin(BinaryWriter writer)
        {
            writer.Write(1);
            writer.Write(0);
        }

        private PlayerStatistics FillStatistics(BinaryReader reader)
        {
            string playerName = reader.ReadString();
            int amountPlayerWins = reader.ReadInt32();
            int amountPlayerLosses = reader.ReadInt32();
            return new PlayerStatistics(playerName, amountPlayerWins, amountPlayerLosses);
        }

        public bool IsEmpty()
        {
            return _streamGame.Length == 0;
        }
    }
}