using System.Linq.Expressions;

namespace day11
{
    public static class PlayerParser
    {
        const string Operation = "Operation: new =";
        const string Test = "Test: divisible by ";
        const string TestTrueAction = "If true: throw to ";
        const string TestFalseAction = "If false: throw to ";
        const string StartingItems = "Starting items: ";

        public static Player CreateFromText(string dataBlock)
        {
            string[] playerInfos = dataBlock.Split("\r\n");

            string name = playerInfos[0].Replace(":", "");
            var items = new List<long>();
            var itemInfo = playerInfos[1].Trim().Replace(StartingItems, "").Split(", ");


            foreach (var item in itemInfo)
            {
                if (long.TryParse(item, out long value))
                {
                    items.Add(value);
                }
            }

            string opExpression = playerInfos[2].Trim().Replace(Operation, "");
            var operation = CreateFunction(opExpression);
            int divisor = int.Parse(playerInfos[3].Trim().Replace(Test, ""));
            string firstRecipient = playerInfos[4].Trim().Replace(TestTrueAction, "");
            string secondRecipient = playerInfos[5].Trim().Replace(TestFalseAction, "");


            return new Player(operation, divisor, firstRecipient, secondRecipient, name, items);

        }

        public static Func<long, long> CreateFunction(string expression)
        {
            var parts = expression.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            ParameterExpression old = Expression.Parameter(typeof(long), "old");
            Expression operand;
            long value;
            if (long.TryParse(parts[0], out value) || long.TryParse(parts[2], out value))
            {
                operand = Expression.Constant(value);
            }
            else
            {
                operand = old;
            }

            BinaryExpression operation;
            switch (parts[1])
            {
                case "+":
                    operation = Expression.AddChecked(old, operand);
                    break;
                case "-":
                    operation = Expression.SubtractChecked(old, operand);
                    break;
                case "*":
                    operation = Expression.MultiplyChecked(old, operand);
                    break;
                case "/":
                    operation = Expression.Divide(old, operand);
                    break;
                default:
                    throw new ArgumentException($"Invalid operator {parts[1]}. Supported operators are +, -, *, and /.");
            }

            var lambda = Expression.Lambda<Func<long, long>>(operation, old);
            return lambda.Compile();
        }
    }
}
