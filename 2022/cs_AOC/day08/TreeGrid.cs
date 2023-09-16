
namespace day08
{

    public class TreeGrid
    {
        private const int CornerTrees = 4;
        private readonly Matrix _trees;



        private TreeGrid(Matrix trees)
        {
            _trees = trees;          
        }

        public static TreeGrid CreateFromTxt(string file)
        {
            string[] lines = File.ReadAllLines(file);

            int rows = lines.Length;
            int columns = lines[0].Length;

            var trees = new Matrix(rows, columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    trees[i, j] = int.Parse(lines[i][j].ToString());
                }
            }

            return new TreeGrid(trees);
        }


        public int GetVisibleTrees()
        {
            int edgeTrees = (_trees.RowCount * 2 + _trees.ColumnCount * 2) - CornerTrees;

            int visibleTrees = 0;
            for (int i = 1; i < _trees.RowCount - 1; i++)
            {
                var row = _trees.GetRow(i);
                for (int j = 1; j < _trees.ColumnCount - 1; j++)
                {

                    var left = row.Take(j);
                    var right = row.TakeLast(row.Length - j - 1);
                    bool visibleHorizontal = left.Max() < _trees[i, j] || right.Max() < _trees[i, j];

                    var column = _trees.GetColumn(j);
                    var top = column.Take(i);
                    var bottom = column.TakeLast(column.Length - i - 1);
                    bool visibleVertical = top.Max() < _trees[i, j] || bottom.Max() < _trees[i, j];

                    if (visibleVertical || visibleHorizontal) visibleTrees++;
                }
            }

            return visibleTrees + edgeTrees;
        }

        public int GetScenicScore() 
        {
            int finalScore = 0;

            for (int i = 0; i < _trees.RowCount; i++)
            {
                var row = _trees.GetRow(i);
                for (int j = 0; j < _trees.ColumnCount; j++)
                {
                    var leftView = row.Take(j).Reverse();
                    int leftScore = CalculateViewScore(leftView, row[j]);

                    var rightView = row.TakeLast(row.Length - j - 1);
                    int rightScore = CalculateViewScore(rightView, row[j]);

                    var column = _trees.GetColumn(j);
                    var topView = column.Take(i).Reverse();
                    int topScore = CalculateViewScore(topView, column[i]);

                    var bottomView = column.TakeLast(column.Length - i - 1);
                    int bottomScore = CalculateViewScore(bottomView, column[i]);

                    int currentTreeScore = leftScore* rightScore * topScore * bottomScore;

                    finalScore = currentTreeScore > finalScore ? currentTreeScore : finalScore;
                }
            }



            return finalScore;
        }

        private static int CalculateViewScore(IEnumerable<int> neighbourTrees,int treeHeight )
        {
            int score = 0;
            foreach (var tree in neighbourTrees)
            {
                if (tree >= treeHeight)
                {
                    score++;
                    return score;
                }
                score++;
            }
            return score;
        }
    }

}