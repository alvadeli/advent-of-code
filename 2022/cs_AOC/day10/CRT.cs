using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day10
{
    public class CRT
    {
        private int _cycles = 0;
        private int _currentRow = 0;

        private Sprite _sprite = new Sprite() {Position =1 };
        private string[] _crtImageRows = new string[6] { "", "", "", "", "", "" };

        public string GetImage(string text)
        {
            string[] instructions = File.ReadAllLines(text);
  
            foreach (string instruction in instructions)
            {
                string[] parts = instruction.Split(' ');

                switch (parts[0])
                {
                    case "addx":
                        for (int i = 0; i < 2; i++)
                        {
                            _cycles += 1;
                            if (_currentRow >= _crtImageRows.Length) return string.Join(Environment.NewLine, _crtImageRows);
                            DrawPixel();
                            if (_cycles % 40 == 0) _currentRow++;
                        }
                        _sprite.Position += int.Parse(parts[1]);
                        break;

                    case "noop":
                        _cycles += 1;
                        if (_currentRow >= _crtImageRows.Length) return string.Join(Environment.NewLine, _crtImageRows);
                        DrawPixel();
                        if (_cycles % 40 == 0) _currentRow++;
                        break;
                }

            }

            return string.Join("\n", _crtImageRows);
        }

        private void DrawPixel()
        {
            if (_sprite.IsInSprite(_crtImageRows[_currentRow].Length))
            {
                _crtImageRows[_currentRow] += "#";
                return;
            }
            _crtImageRows[_currentRow] += ".";
        }
    }
}
