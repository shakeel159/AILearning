using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace simple_neural_network
{
    class NeuralNetWork
    {

        private Random _radomObj;

        public NeuralNetWork(int synapseMatrixColumns, int synapseMatrixLines)
        {
            SynapseMatrixColumns = synapseMatrixColumns;
            SynapseMatrixLines = synapseMatrixLines;

            _Init();
        }

        public int SynapseMatrixColumns { get; }
        public int SynapseMatrixLines { get; }
        public double[,] SynapsesMatrix { get; private set; }

        /// <summary>
        /// Initialize the ramdom object and the matrix of ramdon weights
        /// </summary>
        private void _Init()
        {
            // make sure that for every instance of the neural network we are geting the same radom values
            _radomObj = new Random(1);
            _GenerateSynapsesMatrix();
        }

        /// <summary>
        /// Generate our matrix with the weight of the synapses
        /// </summary>
        private void _GenerateSynapsesMatrix()
        {
            SynapsesMatrix = new double[SynapseMatrixLines, SynapseMatrixColumns];

            for (var i = 0; i < SynapseMatrixLines; i++)
            {
                for (var j = 0; j < SynapseMatrixColumns; j++)
                {
                    SynapsesMatrix[i, j] = (2 * _radomObj.NextDouble()) - 1;
                }
            }
        }

        /// <summary>
        /// Calculate the sigmoid of a value
        /// </summary>
        /// <returns></returns>
        private double[,] _CalculateSigmoid(double[,] matrix)
        {

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var value = matrix[i, j];
                    matrix[i, j] = 1 / (1 + Math.Exp(value * -1));
                }
            }
            return matrix;
        }

        /// <summary>
        /// Calculate the sigmoid derivative of a value
        /// </summary>
        /// <returns></returns>
        private double[,] _CalculateSigmoidDerivative(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var value = matrix[i, j];
                    matrix[i, j] = value * (1 - value);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Will return the outputs give the set of the inputs
        /// </summary>
        public double[,] Think(double[,] inputMatrix)
        {
            var productOfTheInputsAndWeights = MatrixDotProduct(inputMatrix, SynapsesMatrix);

            return _CalculateSigmoid(productOfTheInputsAndWeights);

        }

        /// <summary>
        /// Train the neural network to achieve the output matrix values
        /// </summary>
        public void Train(double[,] trainInputMatrix, double[,] trainOutputMatrix, int interactions)
        {
            // we run all the interactions
            for (var i = 0; i < interactions; i++)
            {
                // calculate the output
                var output = Think(trainInputMatrix);

                // calculate the error
                var error = MatrixSubstract(trainOutputMatrix, output);
                var curSigmoidDerivative = _CalculateSigmoidDerivative(output);
                var error_SigmoidDerivative = MatrixProduct(error, curSigmoidDerivative);

                // calculate the adjustment :) 
                var adjustment = MatrixDotProduct(MatrixTranspose(trainInputMatrix), error_SigmoidDerivative);

                SynapsesMatrix = MatrixSum(SynapsesMatrix, adjustment);
            }
        }

        /// <summary>
        /// Transpose a matrix
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixTranspose(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Sum one matrix with another
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixSum(double[,] matrixa, double[,] matrixb)
        {
            var rowsA = matrixa.GetLength(0);
            var colsA = matrixa.GetLength(1);

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int u = 0; u < colsA; u++)
                {
                    result[i, u] = matrixa[i, u] + matrixb[i, u];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtract one matrix from another
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixSubstract(double[,] matrixa, double[,] matrixb)
        {
            var rowsA = matrixa.GetLength(0);
            var colsA = matrixa.GetLength(1);

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int u = 0; u < colsA; u++)
                {
                    result[i, u] = matrixa[i, u] - matrixb[i, u];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplication of a matrix
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixProduct(double[,] matrixa, double[,] matrixb)
        {
            var rowsA = matrixa.GetLength(0);
            var colsA = matrixa.GetLength(1);

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int u = 0; u < colsA; u++)
                {
                    result[i, u] = matrixa[i, u] * matrixb[i, u];
                }
            }

            return result;
        }

        /// <summary>
        /// Dot Multiplication of a matrix
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixDotProduct(double[,] matrixa, double[,] matrixb)
        {

            var rowsA = matrixa.GetLength(0);
            var colsA = matrixa.GetLength(1);

            var rowsB = matrixb.GetLength(0);
            var colsB = matrixb.GetLength(1);

            if (colsA != rowsB)
                throw new Exception("Matrices dimensions don't fit.");

            var result = new double[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < rowsB; k++)
                        result[i, j] += matrixa[i, k] * matrixb[k, j];
                }
            }
            return result;
        }

    }


    class Program
    {
        static void PrintMatrix(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        //MY CODE STARTS HERE
        static void Gear(int hasHelmet, int hasChasplate, int hadShield, int hasSword)
        {

            bool Helmet = false;
            bool Chasplate = false;
            bool Shield = false;
            bool Sword = false;

            if (hasHelmet == 1)
            {
                Helmet = true;
            }
            else if (hasHelmet == 0) { Helmet = false; }
            if (hasChasplate == 1)
            {
                Chasplate = true;


            }
            else if (hasChasplate == 0) { Chasplate = false; }
            if (hadShield == 1)
            {
                Shield = true;
            }
            else if (hadShield == 0) { Shield = false; }
            if (hasSword == 1)
            {
                Sword = true;
            }
            else if (hasSword == 0) { Sword = false; }

            Console.WriteLine("HeadGear: " + Helmet + "\nBodyGear: " + Chasplate + "\nSheild: " + Shield + "\nWeapon: " + Sword);
        }

        static void Main(string[] args)
        {
            int headGear = 1;
            int cheastPlate = 1;
            int Shield = 1;
            int Wapon = 1;
            

            //

            //Battle ANN
            var BattleAnn = new NeuralNetWork(1, 2);
            //Console.WriteLine("Synaptic weights before training:");
            //PrintMatrix(BattleAnn.SynapsesMatrix);
            var battleInputs = new double[,] { { 0, 1 }, { 1, 0 } }; // player win or lose
            var battleOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 0, 1 } }); //player dies or goes to next room
            BattleAnn.Train(battleInputs, battleOutputs, 10000);
            //Console.WriteLine("\nSynaptic weights after training:");
            //PrintMatrix(BattleAnn.SynapsesMatrix);
            var battleOutput = BattleAnn.Think(new double[,] { { 1, 0} });
            //Console.WriteLine("\nConsidering new problem [ 0, 1] => :");
            //PrintMatrix(battleOutput);

            //PlayerHealth ANN
            var PlayerHealthANN = new NeuralNetWork(1, 4);
            //Console.WriteLine("Synaptic weights before training:");
            //PrintMatrix(PlayerHealthANN.SynapsesMatrix);
            var healthInputs = new double[,] { { 0, 0, 0, 0 }, { 0, 0, 1, 1 }, { 0, 1, 1, 0 }, { 1, 1, 1, 1 }, { 1, 1, 1, 0 }, { 1, 0, 0, 1 } };
            var healthOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 0, 1, 0, 1, 0, 1 } });
            PlayerHealthANN.Train(healthInputs, healthOutputs, 10000);
            //Console.WriteLine("\nSynaptic weights after training:");
            //PrintMatrix(PlayerHealthANN.SynapsesMatrix);
            // testing neural networks against a new problem 
            var playerhealthOutput = PlayerHealthANN.Think(new double[,] { { headGear, cheastPlate, Shield, Wapon } });
            //Console.WriteLine("\nConsidering new problem [ 1, 1, 1, 1] => :");
            //PrintMatrix(playerhealthOutput);

            //GoblinHealth ANN
            var GoblinHealth = new NeuralNetWork(1, 4);
            //Console.WriteLine("Synaptic weights before training:");
            //PrintMatrix(GoblinHealth.SynapsesMatrix);
            var GoblinHealthInputs = new double[,] { { 1, 1, 1, 1 }, { 1, 1, 0, 0 }, { 1, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 1 }, { 0, 1, 1, 0 } };
            var GoblinHealthOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 0, 1, 0, 1, 0, 1 } });
            GoblinHealth.Train(GoblinHealthInputs, GoblinHealthOutputs, 10000);
            //Console.WriteLine("\nSynaptic weights after training:");
            //PrintMatrix(GoblinHealth.SynapsesMatrix);
            //// testing neural networks against a new problem 
            var GoblinHealthOutput = GoblinHealth.Think(new double[,] { { playerhealthOutput[0,0], playerhealthOutput[0, 0], playerhealthOutput[0, 0], playerhealthOutput[0, 0] } });
            //Console.WriteLine("\nConsidering new Goblen [ 1, 1, 1, 1] => :");
            //PrintMatrix(GoblinHealthOutput);

            // next step create Mosnter Health ANN
            // take play health output and monster health output and create ANN that uses both as inputs
            int player_initialHealth = 100;
            int player_ActualOutPut = 0;
            int newPlayer_ActualOutPut = 0;
            int player_Location = 0;
            int room = 0;
            int goblin_initialhealth = 0;
            int PlayerWins = 0;
            int goblinWins = 0;
            int goblinLevel = 1;
            //Printing Players GEAR
            Gear(headGear, cheastPlate, Shield, Wapon);
            Break();

            //goblin_initialhealth = CalGoblinHealth(GoblinHealthOutput, playerhealthOutput, goblin_initialhealth);

            int[] maze = new int[] { 0, 1, 0, 1, 0, 1, 1 };
            for (player_Location = 0; player_Location < maze.Length; player_Location++)
            {
                player_ActualOutPut = CalPlayerHealth(playerhealthOutput, player_initialHealth, player_ActualOutPut);
                int enemies_Present = maze[player_Location]; 
                if(enemies_Present == 1)
                {
                    //RUN BTTLE ANN HERE and return if player loses
                    Console.Write("\nroom: " + player_Location + " with " + enemies_Present + " enemies present");
                    Console.WriteLine("\nplayer health: " + player_ActualOutPut);
                    goblin_initialhealth = CalGoblinHealth(GoblinHealthOutput, playerhealthOutput, goblin_initialhealth, goblinLevel);
                    Break();
                    //IF player health is greater then goblin // PLayer wins
                    Random r = new Random();
                    PlayerWins = BattleResults(player_ActualOutPut, goblin_initialhealth, PlayerWins);
                    if(PlayerWins == 0)
                    {
                        player_initialHealth = 0;
                        player_ActualOutPut = 0;
                        Console.WriteLine("GAMEOVER");
                    }
                    else if(PlayerWins == 1)
                    {

                        if (goblinLevel == 1)
                        {
                            headGear = 0;
                            player_initialHealth -= 10;
                        }
                        else if (goblinLevel == 2)
                        {
                            Shield = 0;
                            player_initialHealth -= 15;
                        }
                        else if (goblinLevel == 3)
                        {
                            cheastPlate = 0;
                            player_initialHealth -= 20;
                        }
                        Gear(headGear, cheastPlate, Shield, Wapon);
                        goblinLevel++;
                        playerhealthOutput = PlayerHealthANN.Think(new double[,] { { headGear, cheastPlate, Shield, Wapon } });
                        newPlayer_ActualOutPut = CalPlayerHealth(playerhealthOutput, player_initialHealth, player_ActualOutPut);
                        player_ActualOutPut = newPlayer_ActualOutPut;
                        //player_ActualOutPut -= r.Next(15, 35);
                        enemies_Present--;
                        Break();
                    }

                }
                Console.Write("room: " + player_Location + " with " + enemies_Present + " enemies present\n");
            }
            //PRINT MODIFIED HEALTH
            CalPlayerHealth(playerhealthOutput, player_initialHealth, player_ActualOutPut);

            Console.Read();

        }
        static int CalPlayerHealth(double[,] playerhealthOutput, int health, int NewHealth)
        {

            int rowLength = playerhealthOutput.GetLength(0);
            int colLength = playerhealthOutput.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    int temp = ((int)(playerhealthOutput[i, j] * health) + health);
                    Console.Write(string.Format("player health: " + "{0} ", temp));
                    //Console.Write(string.Format("\n\nplayer health: " + "{0} ", playerhealthOutput[i, j] * health));
                    NewHealth = temp;
                }
                Console.Write(Environment.NewLine);
            }
            return NewHealth;


        }
        static int CalGoblinHealth(double[,] GoblinHealthOutput, double[,] playerhealthOutput, int returnHealth, int goblinLevel)
        {
            Random r = new Random();
            int rowLength = GoblinHealthOutput.GetLength(0);
            int colLength = GoblinHealthOutput.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    int temp = ((int)(playerhealthOutput[i, j] * 100 + r.Next(0, 75)));
                    //int temp = ((int)(playerhealthOutput[i, j] * 100));
                    Console.Write(string.Format("goblin health: " + "{0} ", temp));
                    //Console.Write(string.Format("\n\nplayer health: " + "{0} ", playerhealthOutput[i, j] * health));
                    returnHealth = temp;
                }
                Console.Write(Environment.NewLine);
            }
            return returnHealth;
        }
        static int BattleResults(int player_ActualOutPut, int GoblinHealthOutput, int winState)
        {
            if (player_ActualOutPut > GoblinHealthOutput)
            {
                Console.WriteLine("Player has Slain an enemy");
                return winState = 1;
                
            }
            else
            {
                Console.WriteLine("Player was Slain by enemy");
                return winState = 0;
            }
        }

        static void CheckPlayerhealth()
        {
            Console.WriteLine("Player Health: ");
        }
        static void PlayerHealth(int health)
        {
            
            Console.WriteLine("layer health: " + health + "");
        }
        static void Break()
        {
            Console.WriteLine("\n");
        }

    }
}
