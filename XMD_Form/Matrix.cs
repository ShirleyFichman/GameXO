using System;
using System.Collections.Generic;
using System.Text;

namespace XMD_Form
{
    /// <summary>
    /// Contains all the methods relating to the matrix 
    /// </summary>/
    public class Matrix
    {
        private ePawn[,] m_Board;

        /// <summary>
        /// The constructor init the board according to the size 
        /// </summary>/
        public Matrix(int i_Size)
        {
            m_Board = new ePawn[i_Size, i_Size];
            for (int i = 0; i < i_Size; i++)
            {
                for (int j = 0; j < i_Size; j++)
                {
                    m_Board[i, j] = ePawn.empty;
                }
            }
        }

        /// <summary>
        /// Returns true if succeed, false if spot is taken. assums getting row and col numbers and not index.
        /// </summary>/
        public bool AddMove(int i_Row, int i_Column, int i_Pawn)
        {
            bool answer = false;

            if (m_Board[i_Row - 1, i_Column - 1] == 0)
            {
                m_Board[i_Row - 1, i_Column - 1] = (ePawn)i_Pawn;
                answer = true;
            }

            return answer;
        }

        /// <summary>
        /// Make the given place empty again
        /// </summary>/
        public void RemoveMove(int i_Row, int i_Column)
        {
            m_Board[i_Row - 1, i_Column - 1] = ePawn.empty;
        }

        /// <summary>
        /// Returnes which pawn this place has (including empty)
        /// </summary>/
        public char GetSingleCell(int i_Row, int i_Column)
        {
            char answer;

            if (Board[i_Row - 1, i_Column - 1] == 0)
            {
                answer = ' ';
            }
            else
            {
                answer = char.Parse(Enum.GetName(typeof(ePawn), Board[i_Row - 1, i_Column - 1]));
            }

            return answer;
        }

        /// <summary>
        /// Returnes the board size in char
        /// </summary>/
        public char GetBoardSizeInChar()
        {
            return (char)(m_Board.GetLength(0) + 48);
        }

        /// <summary>
        /// Returnes if the new placing makes the player to lose
        /// </summary>/
        public bool CheckIfLost(int i_Player, int i_Row, int i_Col)
        {
            bool isLost = false;

            if (checkRowForSequence(i_Player, i_Row) || checkColumnForSequence(i_Player, i_Col))
            {
                isLost = true;
            }
            else if (i_Row == i_Col)
            {
                if (checkDiagonalForSequence(i_Player))
                {
                    isLost = true;
                }
            }

            if (m_Board.GetLength(0) - i_Col + 1 == i_Row)
            {
                if (checkAntiDiagonalForSequence(i_Player))
                {
                    isLost = true;
                }
            }

            return isLost;
        }

        /// <summary>
        /// Checks if the row is full
        /// </summary>/
        private bool checkRowForSequence(int i_PlayerPawn, int i_Row)
        {
            bool answer = true;

            for (int i = 0; i < m_Board.GetLength(0) && answer; i++)
            {
                if (m_Board[i_Row - 1, i] != (ePawn)i_PlayerPawn)
                {
                    answer = false;
                }
            }

            return answer;
        }

        /// <summary>
        /// Checks if the column is full
        /// </summary>/
        private bool checkColumnForSequence(int i_PlayerPawn, int i_Col)
        {
            bool answer = true;

            for (int i = 0; i < m_Board.GetLength(0) && answer; i++)
            {
                if (m_Board[i, i_Col - 1] != (ePawn)i_PlayerPawn)
                {
                    answer = false;
                }
            }

            return answer;
        }

        /// <summary>
        /// Checks if the diagonal is full
        /// </summary>/
        private bool checkDiagonalForSequence(int i_PlayerPawn)
        {
            bool answer = true;

            for (int i = 0; i < m_Board.GetLength(0) && answer; i++)
            {
                if (m_Board[i, i] != (ePawn)i_PlayerPawn)
                {
                    answer = false;
                }
            }

            return answer;
        }

        /// <summary>
        /// Checks if the other diagonal is full
        /// </summary>/
        private bool checkAntiDiagonalForSequence(int i_PlayerPawn)
        {
            bool answer = true;

            for (int i = 0; i < m_Board.GetLength(0) && answer; i++)
            {
                if (m_Board[i, m_Board.GetLength(0) - 1 - i] != (ePawn)i_PlayerPawn)
                {
                    answer = false;
                }
            }

            return answer;
        }

        public ePawn[,] Board
        {
            get => m_Board;
            set => m_Board = value;
        }
    }
}
