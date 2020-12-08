using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc2020
{
    /// <summary>
    /// Day 4: <see href="https://adventofcode.com/2020/day/4">Passport Processing</see>
    /// </summary>
    public sealed class Day4 : Day
    {
        private readonly List<Passport> _passports;

        public Day4() : base(4)
        {
            _passports = new List<Passport>();

            var a = new List<string>();
            foreach (var line in Input)
            {
                if (line == "")
                {
                    _passports.Add(Passport.Parse(a));
                    a.Clear();
                    continue;
                }

                a.Add(line);
            }

            if (a.Any()) _passports.Add(Passport.Parse(a));
        }

        public override string Part1()
        {
            return $"{_passports.Count(p => p.IsValid)}";
        }

        public override string Part2()
        {
            return $"{_passports.Count(p => p.ExtendedValidation())}";
        }

        private class Passport
        {
            private string _byr;
            private string _cid;
            private string _ecl;
            private string _eyr;
            private string _hcl;
            private string _hgt;
            private string _iyr;
            private string _pid;

            public bool IsValid =>
                _byr != null &&
                _iyr != null &&
                _eyr != null &&
                _hgt != null &&
                _hcl != null &&
                _ecl != null &&
                _pid != null;

            public bool ExtendedValidation()
            {
                if (!IsValid) return false;

                // birth year
                if (int.TryParse(_byr, out var byr))
                {
                    if (byr < 1920 || byr > 2002)
                        return false;
                }
                else
                {
                    return false;
                }

                // issuance year
                if (int.TryParse(_iyr, out var iyr))
                {
                    if (iyr < 2010 || iyr > 2020)
                        return false;
                }
                else
                {
                    return false;
                }

                // expiration year
                if (int.TryParse(_eyr, out var eyr))
                {
                    if (eyr < 2020 || eyr > 2030)
                        return false;
                }
                else
                {
                    return false;
                }

                // height
                if (_hgt.EndsWith("cm"))
                {
                    var h = _hgt.Substring(0, 3);
                    if (int.TryParse(h, out var hgt))
                    {
                        if (hgt < 150 || hgt > 193)
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (_hgt.EndsWith("in"))
                {
                    var h = _hgt.Substring(0, 2);
                    if (int.TryParse(h, out var hgt))
                    {
                        if (hgt < 59 || hgt > 76)
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                // hair color
                if (!Regex.IsMatch(_hcl, "#[0-9a-f]{6}"))
                    return false;

                // eye color
                if (!new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(_ecl))
                    return false;

                // passport id
                if (_pid.Length != 9)
                    return false;

                return true;
            }

            public static Passport Parse(IEnumerable<string> list)
            {
                var passport = new Passport();
                foreach (var entry in string.Join(' ', list).Split(' ', StringSplitOptions.TrimEntries))
                {
                    var spl = entry.Split(':', 2);
                    switch (spl[0])
                    {
                        case "byr":
                            passport._byr = spl[1];
                            break;
                        case "iyr":
                            passport._iyr = spl[1];
                            break;
                        case "eyr":
                            passport._eyr = spl[1];
                            break;
                        case "hgt":
                            passport._hgt = spl[1];
                            break;
                        case "hcl":
                            passport._hcl = spl[1];
                            break;
                        case "ecl":
                            passport._ecl = spl[1];
                            break;
                        case "pid":
                            passport._pid = spl[1];
                            break;
                        case "cid":
                            passport._cid = spl[1];
                            break;
                    }
                }

                return passport;
            }
        }
    }
}