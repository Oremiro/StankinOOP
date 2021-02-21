using System;

namespace Lab2
{
    public class Coordinate : ICoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// +
        /// </summary>
        /// <param name="coordinate1"></param>
        /// <param name="coordinate2"></param>
        /// <returns></returns>
        public static Coordinate operator +(Coordinate coordinate1, Coordinate coordinate2)
        {
            return new Coordinate(
                x: coordinate1.X + coordinate2.X,
                y: coordinate1.Y + coordinate2.Y);
        }

        /// <summary>
        /// -
        /// </summary>
        /// <param name="coordinate1"></param>
        /// <param name="coordinate2"></param>
        /// <returns></returns>
        public static Coordinate operator -(Coordinate coordinate1, Coordinate coordinate2)
        {
            return new Coordinate(
                x: coordinate1.X - coordinate2.X,
                y: coordinate1.Y - coordinate2.Y);
        }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="coordinate1"></param>
        /// <param name="coordinate2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool operator ==(Coordinate coordinate1, Coordinate coordinate2)
        {
            return
                (coordinate1?.X == coordinate2?.X) &&
                (coordinate1?.Y == coordinate2?.Y);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="coordinate1"></param>
        /// <param name="coordinate2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool operator !=(Coordinate coordinate1, Coordinate coordinate2)
        {
            return !(coordinate1 == coordinate2);
        }

        /// <summary>
        /// В c# << является битовой операцией сдвига влево, соотвественно я переопределю ToString
        /// << 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var stringMessageTemplate = $"Coordinate <x: {this.X}, y: {this.Y}>";
            return stringMessageTemplate;
        }

        //Методы ниже не необходимы для решения задачи, но должны быть переопределены, т.к. мы изменили операции сравнения.

        public bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinate) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}