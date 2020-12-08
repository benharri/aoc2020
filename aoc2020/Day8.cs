using System.Linq;

namespace aoc2020
{
    /// <summary>
    /// Day 8: <see href="https://adventofcode.com/2020/day/8">Handheld Halting</see>
    /// </summary>
    public sealed class Day8 : Day
    {
        private readonly (string instruction, int value)[] _instructions;
        private int _accumulator;
        private int _currentInstruction;

        public Day8() : base(8)
        {
            _instructions = Input.Select(ParseLine).ToArray();
        }

        private static (string, int) ParseLine(string line)
        {
            var spl = line.Split(' ', 2);
            return (spl[0], int.Parse(spl[1]));
        }

        private bool Halts()
        {
            _accumulator = 0;
            _currentInstruction = 0;
            var visited = new bool[_instructions.Length + 1];

            while (!visited[_currentInstruction] && _currentInstruction < _instructions.Length)
            {
                visited[_currentInstruction] = true;

                switch (_instructions[_currentInstruction].instruction)
                {
                    case "acc":
                        _accumulator += _instructions[_currentInstruction].value;
                        break;
                    case "jmp":
                        _currentInstruction += _instructions[_currentInstruction].value;
                        continue;
                }

                _currentInstruction++;
            }

            return _currentInstruction == _instructions.Length;
        }

        public override string Part1()
        {
            Halts();
            return $"{_accumulator}";
        }

        public override string Part2()
        {
            for (var i = 0; i < _instructions.Length; i++)
                // swap each nop and jmp and check if the program halts
                if (_instructions[i].instruction == "nop")
                {
                    _instructions[i].instruction = "jmp";
                    if (Halts()) break;
                    _instructions[i].instruction = "nop";
                }
                else if (_instructions[i].instruction == "jmp")
                {
                    _instructions[i].instruction = "nop";
                    if (Halts()) break;
                    _instructions[i].instruction = "jmp";
                }

            return $"{_accumulator}";
        }
    }
}